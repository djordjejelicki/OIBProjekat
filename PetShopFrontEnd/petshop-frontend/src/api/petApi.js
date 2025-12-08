import api from "./axiosClient";

const petApi = {
    addPet: (petData) => api.post("/pet", petData),
    getAllPets: () => api.get("/pet/all"),
    getAvailablePets: () => api.get("/pet/available")
};

export default petApi;