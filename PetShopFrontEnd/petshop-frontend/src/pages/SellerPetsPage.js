import { useEffect, useState } from "react";
import petApi from "../api/petApi";
import sellApi from "../api/sellApi";
import BackButton from "../components/BackButton";
import InvoiceModal from "../components/InvoiceModal";
import "../styles/SellerPetsPage.css";
import { Link } from "react-router-dom";

export default function SellerPetsPage() {
    console.log("SellerPetsPage mounted");
    const [pets, setPets] = useState([]);
    const [loading, setLoading] = useState(true);
    const [soldInvoice, setSoldInvoice] = useState(null);
    const [showInvoiceModal, setShowInvoiceModal] = useState(false);

    useEffect(() => {
        loadAvailable();
    },[]);

    const loadAvailable = async () => {
        try{
            const res = await petApi.getAvailablePets();
            setPets(res.data);
        }catch(err){
            console.error("Error loading availble pets:", err);
        }finally{
            setLoading(false);
        }
    };

    const handleSell = async (id,petName) => {
        
        const confirmed = window.confirm(
            `Are you sure you want to sell "${petName}"?`
        );
        
        if (!confirmed) return;

        try{
            const res = await sellApi.sellPet(id);
            setSoldInvoice(res.data);
            setShowInvoiceModal(true);
            await loadAvailable();
        }catch(err){
            console.error("Error selling pet:", err);
            alert("Error while selling pet.");
        }
    };

    if(loading) return <div className="loading">Loading available pets</div>;

    return(
        <div className="seller-pets-container">
            <h2>Available Pets</h2>
            <BackButton to="/seller" label="← Back to Seller Menu" />

            <table className="seller-pets-table">
                <thead>
                    <tr>
                        <th>Latin Name</th>
                        <th>Name</th>
                        <th>Type</th>
                        <th>Price (€)</th>
                        <th>Details</th>
                        <th>Image</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {pets.map((p) => (
                        <tr key={p.id}>
                            <td>{p.latinName}</td>
                            <td>{p.name}</td>
                            <td>
                               {p.type}
                            </td>
                            <td>{p.price}</td>
                            <td>
                                <Link to={`/pet/${p.id}`} className="details-btn">
                                    View
                                </Link>
                            </td>
                            <td>
                                {p.imageUrl && (
                                    <img
                                        src={`https://localhost:7071${p.imageUrl}`}
                                        alt={p.name}
                                        className="pet-thumbnail"
                                    />
                                )}
                            </td>
                            <td>
                                <button
                                    className="sell-btn"
                                    onClick={() => handleSell(p.id,p.name)}
                                >
                                    Sell
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        {showInvoiceModal && (
            <InvoiceModal
            invoice={soldInvoice}
            onClose={() => {
                setShowInvoiceModal(false);
                setSoldInvoice(null);
            }}
            />
        )}
        </div>
    );
}