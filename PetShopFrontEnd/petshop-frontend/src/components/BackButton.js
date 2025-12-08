import { useNavigate } from "react-router-dom";
import "../styles/BackButton.css";

export default function BackButton({to = "/", label = "← Back"}){
    const navigate = useNavigate();

    return(
        <button
            type="button"
            className="back-btn"
            onClick={() => navigate(to)}
        >
            {label}
        </button>
    );
}