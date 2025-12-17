import { useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import healthRecordApi from "../api/healthRecordApi";
import BackButton from "../components/BackButton";
import "../styles/AddHealthRecordPage.css";

export default function AddHealthRecordPage(){
    const { id } = useParams();
    const navigate = useNavigate();

    const [recordType, setRecordType] = useState(0);
    const [description, setDescription] = useState("");
    const [notes, setNotes] = useState("");
    const [date, setDate] = useState("");
    const [message, setMessage] = useState("");
    const [messageType, setMessageType] = useState("");

    const handleSubmit = async (e) => {
        e.preventDefault();

        if(!date || !description){
            setMessage("Date and description are required.");
            setMessageType("error");
            return;
        }

        const newRecord = {
            petId: id,
            date: date,
            recordType: recordType,
            description: description,
            notes: notes,
        };

        try{
            await healthRecordApi.addRecord(newRecord);
            setMessage("Health record added successfully.");
            setMessageType("success");
            setTimeout(() => {                
                navigate(`/pet/${id}`);
            }, 1000);
        }catch (err){
            console.error("Failed to add record", err);
            setMessage("Error while adding health record.");
            setMessageType("error");
        }
    };

    return(
        <div className="add-record-container">
            <h2>Add Health Record</h2>
            <BackButton to={`/pet/${id}`} label="← Back to Details" />

            {message && <div className={`message-box ${messageType}`}>{message}</div>}

            <form className="record-form" onSubmit={handleSubmit}>
                <label>Date</label>
                <input
                    type="date"
                    value={date}
                    onChange={(e) => setDate(e.target.value)}
                    required
                />

                <label>Record Type</label>
                <select
                    value={recordType}
                    onChange={(e) => setRecordType(Number(e.target.value))}
                    required
                >
                    <option value="0">Checkup</option>
                    <option value="1">Vaccination</option>
                    <option value="2">Surgery</option>
                    <option value="3">Therapy</option>
                    <option value="4">Note</option>
                </select>

                <label>Description</label>
                <textarea
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    required
                />

                <label>Notes (optional)</label>
                <textarea
                    value={notes}
                    onChange={(e) => setNotes(e.target.value)}
                />

                <button className="save-btn" type="submit">
                    Save Record
                </button>
            </form>
        </div>
    );
}