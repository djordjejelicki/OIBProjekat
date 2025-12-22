import { useEffect, useState } from "react";
import petApi from "../api/petApi";
import sellApi from "../api/sellApi";
import BackButton from "../components/BackButton";
import InvoiceModal from "../components/InvoiceModal";
import "../styles/SellerPetsPage.css";
import { Link } from "react-router-dom";
import SellConfirmModal from "../components/SellConfirmModal";

export default function SellerPetsPage() {
    
    const [pets, setPets] = useState([]);
    const [loading, setLoading] = useState(true);
    const [soldInvoice, setSoldInvoice] = useState(null);
    const [showInvoiceModal, setShowInvoiceModal] = useState(false);
    const [selectedPet, setSelectedPet] = useState(null)

    useEffect(() => {
        loadAvailable();
    },[]);

    const loadAvailable = async () => {
        try{
            const res = await petApi.getAvailablePets();
            setPets(res.data);
        }catch(err){
            console.error("Error loading availble pets: ", err);
        }finally{
            setLoading(false);
        }
    };

    const handleSell = async (id) => {
        try{
            const res = await sellApi.sellPet(id);
            setSoldInvoice(res.data);
            setShowInvoiceModal(true);
            await loadAvailable();
        }catch(err){
            console.error("Error selling pet:", err);
            alert("Error while selling pet: " + err.response.data);
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
                                    onClick={() => setSelectedPet(p)}
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
        {selectedPet && (
            <SellConfirmModal
                pet={selectedPet}
                onClose={() => setSelectedPet(null)}
                onConfirm={async () => {
                    await handleSell(selectedPet.id);
                    setSelectedPet(null);
                }}
            />
        )}
        </div>
    );
}