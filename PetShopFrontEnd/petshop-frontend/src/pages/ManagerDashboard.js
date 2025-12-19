import { Link, useNavigate } from "react-router-dom";
import { useContext } from "react";
import {AuthContext} from "../auth/AuthContext";
import "../styles/ManagerDashboard.css";

export default function ManagerDashboard(){
    const {logout, user} = useContext(AuthContext);
    const navigate = useNavigate();


    const handleLogout = () => {
        logout();
        navigate("/login");
    }

    return(
        <div className="manager-container">
            <div className="top-bar-manager">
                <div className="top-bar-manager-left">
                    <h2 className="manager-title">Manager Dashboard</h2>
                    <p className="welcome-text-manager">
                        Logged in as <strong>{user?.username}</strong>
                    </p>
                </div>
                <button className="logout-btn" onClick={handleLogout}>Logout</button>
            </div>

            <div className="manager-buttons">
                <Link to="/manager/add-pet" className="manager-btn">Add New Pet</Link>
                <Link to="/manager/pets" className="manager-btn">View All Pets</Link>
                <Link to="/manager/invoices" className="manager-btn">View Invoices</Link>
            </div>
        </div>
    );
}