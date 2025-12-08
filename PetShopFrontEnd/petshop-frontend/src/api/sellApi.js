import api from "./axiosClient";

const sellApi = {
    sellPet: (petId) => api.post(`/sell/${petId}`)
};

export default sellApi;