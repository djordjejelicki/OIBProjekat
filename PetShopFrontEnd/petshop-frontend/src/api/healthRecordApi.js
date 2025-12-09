import api from "./axiosClient";

const healthRecordApi = {
    getByPetId: (petId) => api.get(`/healthrecord/${petId}`),
    addRecord: (data) => api.post("/healthrecord",data)
};

export default healthRecordApi;