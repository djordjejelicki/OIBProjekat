import { useEffect, useState } from "react";
import "../styles/SellConfirmModal.css";

export default function SellConfirmModal({pet, onConfirm, onClose}){
    const [seconds, setSeconds] = useState(5);

    useEffect(() => {
        if( seconds === 0) return;

        const timer = setTimeout(() => {
            setSeconds(prev => prev - 1)
        }, 1000);

        return () => clearTimeout(timer);

    }, [seconds]);

    return(
        <div className="modal-backdrop">
            <div className="modal-box">
                <h3>Confirm Pet Sale</h3>
                <img
                    src={`https://localhost:7071${pet.imageUrl}`}
                    alt={pet.name}
                    className="modal-pet-image"
                />
                <p><strong>Name:</strong> {pet.name}</p>
                <p><strong>Price:</strong> {pet.price} €</p>
                <div className="modal-actions">
                    <button className="cancel-btn" onClick={onClose}>
                        Cancel
                    </button>
                    <button
                        className="confirm-btn"
                        onClick={onConfirm}
                        disabled={seconds > 0}
                    >
                        {seconds > 0 ? `Sell (${seconds})` : "Sell"}
                    </button>
                </div>
            </div>
        </div>
    );
}