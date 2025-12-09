import api from "./axiosClient";

const petApi = {
    addPet: (formData) => api.post("/pet", formData,{
        headers:{
            "Content-Type" : "multipart/form-data"
        }
    }),
    getAllPets: () => api.get("/pet/all"),
    getAvailablePets: () => api.get("/pet/available"),
    getPetById: (id) => api.get(`/pet/${id}`)
};

export default petApi;