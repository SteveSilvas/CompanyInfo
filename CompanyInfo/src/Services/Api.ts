import axios from "axios";

const localURL = "https://localhost:7142/";

const api = axios.create({
    baseURL: localURL});

export default api;