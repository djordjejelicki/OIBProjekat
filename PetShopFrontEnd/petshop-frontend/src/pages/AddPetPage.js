import { useRef, useState } from "react";
import petApi from "../api/petApi";
import BackButton from "../components/BackButton";
import "../styles/AddPetPage.css";

export default function AddPetPage(){
    const [latinName, setLatinName] = useState("");
    const [name, setName] = useState("");
    const [type, setType] = useState("0");
    const [price, setPrice] = useState("");
    const [message, setMessage] = useState("");
    const [messageType, setMessageType] = useState("");
    const [imageFile, setImageFile] = useState(null);
    const fileInputRef = useRef(null);

    const handleSubmit = async (e) => {
        e.preventDefault();

        if(!latinName || !name || !price){
            setMessage("All fields are required");
            setMessageType("error");
            return;
        }

       const formData = new FormData();
       formData.append("latinName",latinName);
       formData.append("name",name);
       formData.append("type", type);
       formData.append("price", price);
       if(imageFile){
        formData.append("image", imageFile);
       }

        try{
            await petApi.addPet(formData);
            setMessage("Pet successfully added!");
            setMessageType("success");
            setLatinName("");
            setName("");
            setPrice("");
            setType("0");
            setImageFile(null);
            if(fileInputRef.current){
                fileInputRef.current.value = "";
            }
        }catch(err){
            if (err.response && err.response.data) 
            {
                setMessage("Error: " + err.response.data);
            } 
            else 
            {
                setMessage("Unexpected error occurred.");
            }

            setMessageType("error");
            setLatinName("");
            setName("");
            setPrice("");
            setType("0");
            setImageFile(null);
            if(fileInputRef.current){
                fileInputRef.current.value = "";
            }
        }
    };

    return(
        <div className="add-pet-container">
            <h2>Add New Pet</h2>
            <BackButton to="/manager" label="← Back to Menu"/>

            {message && <div className={`message-box ${messageType}`}>{message}</div>}

            <form onSubmit={handleSubmit} className="pet-form">
                <label>Latin Name</label>
                <input
                    type="text"
                    value={latinName}
                    onChange={(e) => {setLatinName(e.target.value);
                                      setMessage("");}}
                />
                <label>Name</label>
                <input
                    type="text"
                    value={name}
                    onChange={(e) => {setName(e.target.value);
                                      setMessage("");}}
                />
                <label>Type</label>
                <select value={type} onChange={(e) => {setType(e.target.value);
                                                       setMessage("");}}>
                    <option value="0">Mammal</option>
                    <option value="1">Reptile</option>
                    <option value="2">Rodent</option>
                </select>
                <label>Price</label>
                <input
                    type="number"
                    step="0.01"
                    value={price}
                    onChange={(e) => {setPrice(e.target.value);
                                      setMessage("");}}
                />
                <label>Image (Optional)</label>
                <input
                    type="file"
                    accept="image/*"
                    ref={fileInputRef}
                    onChange={(e) => setImageFile(e.target.files[0])}
                />
                <button type="submit" className="submit-btn">Add Pet</button>

            </form>
        </div>
    );
}