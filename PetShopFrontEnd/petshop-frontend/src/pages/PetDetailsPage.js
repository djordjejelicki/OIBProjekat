import { useEffect, useState, useContext } from "react";
import { Link, useParams } from "react-router-dom";
import petApi from "../api/petApi";
import healthRecordApi from "../api/healthRecordApi";
import { AuthContext } from "../auth/AuthContext";
import BackButton from "../components/BackButton";
import "../styles/PetDetailsPage.css";

export default function PetDetailsPage(){
    const { id } = useParams();
    const { user } = useContext(AuthContext);

    const [pet, setPet] = useState(null);
    const [records, setRecords] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");
    const backRoute = user?.role === "Manager" ? "/manager/pets" : "/seller/pets";

    useEffect(() =>{
        const loadPet = async () => {
            try{
                const res = await petApi.getPetById(id);
                setPet(res.data);
            }catch(err){
                console.error("Failed to load pet:", err);
                setError("Error loading pet details");               
            }finally{
                setLoading(false);
            }
        }
    
        const loadRecords = async () => {
            try{
                const res = await healthRecordApi.getByPetId(id);
                setRecords(res.data);
            }catch(err){
                console.error("Failed to load health records: ", err);
                setRecords([]);
            }
        }
        loadPet();
        loadRecords();
    },[id]);

    if(loading) return <div>Loading...</div>;
    if(error){
        return(
            <div className="error-box">
                <p>{error}</p>
                <BackButton to={backRoute} label="← Back" />
            </div>
        );
    }
    
    return(
       <div className="pet-details-container">
            <h2>{pet.name} — Details</h2>
            <BackButton to={backRoute} label="← Back"/>
            <div className="pet-info-box">
                <img
                    src={`https://localhost:7071${pet.imageUrl}`}
                    alt={pet.name}
                    className="pet-big-image"
                />

                <div className="pet-info-text">
                    <p><strong>Latin Name:</strong> {pet.latinName}</p>
                    <p><strong>Type:</strong> {pet.type}</p>
                    <p><strong>Price:</strong> {pet.price} €</p>
                    <p><strong>Sold:</strong> {pet.sold ? "Yes" : "No"}</p>
                </div>
            </div>

            <h3>Health Records</h3>

            <table className="records-table">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Type</th>
                        <th>Description</th>
                        <th>Notes</th>
                        <th>By</th>
                    </tr>
                </thead>
                <tbody>
                    {records.length === 0 && (
                        <tr>
                            <td colSpan="5">No records yet.</td>
                        </tr>
                    )}

                    {records.map(r => (
                        <tr key={r.id}>
                            <td>{r.date.split("T")[0]}</td>
                            <td>{r.recordType}</td>
                            <td>{r.description}</td>
                            <td>{r.notes || "-"}</td>
                            <td>{r.recordedBy}</td>
                        </tr>
                    ))}
                </tbody>
            </table>

            {user?.role === "Manager" && (
              <Link to={`/pet/${id}/add-record`} className="add-record-link-btn">
                + Add Health Record
              </Link>
            )}
        </div> 
    );
}