import { Link, useNavigate } from "react-router-dom";
import { useContext } from "react";
import { AuthContext } from "../auth/AuthContext";
import "../styles/SellerDashboard.css";

export default function SellerDashboard() {
    const {logout} = useContext(AuthContext);
    const navigate = useNavigate();

    const handleLogout = () => {
        logout();
        navigate("/login");
    };

    return(
        <div className="seller-container">
            <div className="top-bar-seller">
                <h2 className="seller-title">Seller Dashboard</h2>
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