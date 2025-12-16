import React, {useState, useContext} from "react";
import api from "../api/axiosClient";
import { AuthContext } from "../auth/AuthContext";
import { useNavigate } from "react-router-dom";
import { jwtDecode } from "jwt-decode";
import "../styles/LoginPage.css";

export default function LoginPage() {
    const { login } = useContext(AuthContext);
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();

    const handleLogin = async () => {
        setLoading(true);
        try{
            const res = await api.post("/auth/login", {username,password});
            login(res.data.token);

            const payload = jwtDecode(res.data.token);
            const role = payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
            if(role === "Manager"){
                navigate("/manager");
            }else if(role === "Seller"){
                navigate("/seller");
            }

        }catch (err){           
           setUsername("");
           setPassword("");
           if(err.response && err.response.data){
            setError("Invalid username or password");
           }else{
            setError("Unable to login. Please try again.");
           }           
        }finally{
            setLoading(false);
        }
    };

    return (
        <div className="login-container">
            <div className="login-box">
                <h2 className="login-title">Pet-Shop Login</h2>

                {error && <div className="login-error">{error}</div>}

                <input
                    className="login-input"
                    value={username}
                    placeholder="Username"
                    onChange={e => {setUsername(e.target.value);
                                    setError("");
                    }}
                />
                <input
                    className="login-input"
                    value={password}
                    type="password"
                    placeholder="Password"
                    onChange={ e => {setPassword(e.target.value)
                                     setError("");
                    }}
                />

                <button className="login-button" disabled={loading} onClick={handleLogin}>
                    {loading ? "Logging in..." : "Login"}
                </button>
            </div>
        </div>
    );
}