import api from "./axiosClient";

const invoiceApi = {
    getAll : () => api.get("/invoice/all"),
    getBtId: (id) => api.get(`/invoice/${id}`)
};

export default invoiceApi;