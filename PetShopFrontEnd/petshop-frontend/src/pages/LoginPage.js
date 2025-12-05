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
    const navigate = useNavigate();

    const handleLogin = async () => {
        try{
            const res = await api.post("/auth/login", {username,password});
            login(res.data.token);

            const payload = jwtDecode(res.data.token);
            const role = payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
            if(role === "Manager"){
                console.log("Token: ", res.data.token);
                console.log("Role decoded: ", role);
                console.log("Login completed.");
                navigate("/manager");
            }else if(role === "Seller"){
                console.log("Token: ", res.data.token);
                console.log("Role decoded: ", role);
                console.log("Login completed.");
                navigate("/seller");
            }

        } catch{
           setError("Invalid username or password");
        }
    };

    return (
        <div className="login-container">
            <div className="login-box">
                <h2 className="login-title">Pet-Shop Login</h2>

                {error && <div className="login-error">{error}</div>}

                <input
                    className="login-input"
                    placeholder="Username"
                    onChange={e => setUsername(e.target.value)}
                />
                <input
                    className="login-input"
                    type="password"
                    placeholder="Password"
                    onChange={ e => setPassword(e.target.value)}
                />

                <button className="login-button" onClick={handleLogin}>Login</button>
            </div>
        </div>
    );
}