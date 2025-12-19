import { Link, useNavigate } from "react-router-dom";
import { useContext } from "react";
import { AuthContext } from "../auth/AuthContext";
import "../styles/SellerDashboard.css";

export default function SellerDashboard() {
    const {logout, user} = useContext(AuthContext);
    const navigate = useNavigate();

    const handleLogout = () => {
        logout();
        navigate("/login");
    };

    return(
        <div className="seller-container">
            <div className="top-bar-seller">
                <div className="top-bar-seller-left">
                    <h2 className="seller-title">Seller Dashboard</h2>
                    <p className="welcome-text-seller">
                        Logged in as <strong>{user?.username}</strong>
                    </p>
                </div>
                <button className="logout-btn-seller" onClick={handleLogout}>
                    Logout
                </button>
            </div>

            <div className="seller-buttons">
                <Link to="/seller/pets" className="seller-btn">
                    View Available Pets
                </Link>
            </div>
        </div>
    );
}