import api from "./axiosClient";

const invoiceApi = {
    getAll : () => api.get("/invoice/all")
};

export default invoiceApi;