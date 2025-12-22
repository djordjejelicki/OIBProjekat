import { useEffect, useState } from "react";
import invoiceApi from "../api/invoiceApi";
import BackButton from "../components/BackButton"
import { Link } from "react-router-dom";
import { formatDateTime } from "../utils/formatDateTime";
import "../styles/InvoicePage.css";

export default function InvoicePage() {
    const [invoices, setInvoices] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {    
        loadInvoices();
    }, []);
    
    const loadInvoices = async () => {
        try{
            const res = await invoiceApi.getAll();
            setInvoices(res.data);
        }catch(err){
            console.error("Error loading invoices: ",err);
        }finally{
            setLoading(false);
        }
    };

    if(loading) return <div className="loading">Loading invoices</div>;

    return(
        <div className="invoice-container">
            <h2>All Invoices</h2>
            <BackButton to="/manager" />

            <table className="invoice-table">
                <thead>
                    <tr>
                        <th>Date & Time</th>
                        <th>Seller</th>
                        <th>Total Amount (€)</th>
                    </tr>
                </thead>

                <tbody>
                    {invoices.map((inv) => (
                        <tr key={inv.id}>
                            <td>{formatDateTime(inv.dateTime)}</td>
                            <td>{inv.sellerName}</td>
                            <td>{inv.totalAmount}</td>
                            <td>
                                <Link className="details-btn" to={`/manager/invoices/${inv.id}`}>
                                    View Details
                                </Link>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}