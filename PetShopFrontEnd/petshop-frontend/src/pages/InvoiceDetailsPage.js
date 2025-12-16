import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import invoiceApi from "../api/invoiceApi";
import petApi from "../api/petApi";
import BackButton from "../components/BackButton";
import "../styles/InvoiceDetailsPage.css";

export default function InvoiceDetailsPage(){
    const {id} = useParams();
    const [invoice, setInvoice] = useState(null);
    const [pet, setPet] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const loadDetails = async () => {
            try{
                const invRes = await invoiceApi.getBtId(id);
                setInvoice(invRes.data);
        
                const petRes = await petApi.getPetById(invRes.data.petId);
                setPet(petRes.data);
            }catch(err){
                console.error("Error loading details:",err);
            }finally{
                setLoading(false);
            }
        };
        loadDetails();
    }, [id]);


    if(loading) return <div className="loading">Loading...</div>;

    return(
        <div className="invoice-details-container">
            <BackButton to="/manager/invoices" label="← Back to invoices" />

            <h2>Invoice Details</h2>

            <div className="invoice-card">
                <p><strong>Seller:</strong> {invoice.sellerName}</p>
                <p><strong>Date:</strong> {new Date(invoice.dateTime).toLocaleString()}</p>
                <p><strong>Total Amount:</strong> €{invoice.totalAmount}</p>
            </div>

            <div className="pet-card">
                <p><strong>Name:</strong> {pet.name}</p>
                <p><strong>Latin Name:</strong> {pet.latinName}</p>
                <p><strong>Type:</strong> 
                    {pet.type}
                </p>
                <p><strong>Original Price:</strong> €{pet.price}</p>
            </div>
            {pet.imageUrl && (
                <img
                    src={`https://localhost:7071${pet.imageUrl}`}
                    alt={pet.name}
                    className="pet-image-large"
                />
            )}
        </div>
    );
}