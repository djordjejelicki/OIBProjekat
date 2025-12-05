import { useContext } from "react";
import { AuthContext } from "../auth/AuthContext";
import { useNavigate } from "react-router-dom";

export default function SellerDashboar(){
    const {logout} = useContext(AuthContext);
    const navigate = useNavigate();
    
    return (
        <div style={{ padding: 40 }}>
            <h2>Seller Dashboard</h2>

            <button
                onClick={() => {
                    logout();
                    navigate("/login");
                }}
                style={{
                    background: "#e74c3c",
                    color: "white",
                    border: "none",
                    padding: "8px 18px",
                    borderRadius: "6px",
                    marginTop: "20px",
                    cursor: "pointer"
                }}
            >
                Logout
            </button>
        </div>
    );
}