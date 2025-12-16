import { useEffect, useState } from "react";
import petApi from "../api/petApi";
import BackButton from "../components/BackButton";
import "../styles/AllPetsPage.css";
import { Link } from "react-router-dom";

export default function AllPetsPage(){
    const [pets, setPets] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        loadPets();
    },[]);

    const loadPets = async () => {
        try{
            const res = await petApi.getAllPets();
            setPets(res.data);
        }catch (err){
            console.error("Error loading pets:",err);
        }finally{
            setLoading(false);
        }
    };

    if(loading) return <div className="loading">Loading pets...</div>;

    return(
        <div className="pets-container">
            <h2>All Pets</h2>
            <BackButton to="/manager" label="← Back to Menu" />

            <table className="pets-table">
                <thead>
                    <tr>
                        <th>Latin Name</th>
                        <th>Name</th>
                        <th>Type</th>
                        <th>Price (€)</th>
                        <th>Status</th>
                        <th>Details</th>
                        <th>Image</th>
                    </tr>
                </thead>

                <tbody>
                    {pets.map((pet) => (
                        <tr key={pet.id}>
                            <td>{pet.latinName}</td>
                            <td>{pet.name}</td>
                            <td>
                               {pet.type}
                            </td>
                            <td>{pet.price}</td>
                            <td className={pet.sold ? "sold" : "available"}>
                                {pet.sold ? "Sold" : "Available"}
                            </td>
                            <td>
                               <Link to={`/pet/${pet.id}`} className="details-btn">
                                    View
                               </Link>
                            </td>
                            <td>
                                {pet.imageUrl && (
                                    <img
                                        src={`https://localhost:7071${pet.imageUrl}`}
                                        alt={pet.name}
                                        className="pet-thumbnail"
                                    />
                                )}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}