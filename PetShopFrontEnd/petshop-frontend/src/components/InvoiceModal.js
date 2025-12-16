import "../styles/InvoiceModal.css"

export default function InvoiceModal({invoice, onClose}){
    if(!invoice) return null;

    return(
        <div className="modal-backdrop">
            <div className="modal-box">
                <h3>Sale completed ✅</h3>

                <p><strong>Seller:</strong> {invoice.sellerName}</p>
                <p><strong>Date:</strong> {invoice.dateTime.split("T")[0]}</p>
                <p><strong>Total amount:</strong> €{invoice.totalAmount}</p>

                <button className="modal-btn" onClick={onClose}>
                    OK
                </button>
            </div>
        </div>
    );
}