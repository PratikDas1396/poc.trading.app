import axios from "axios";
import { API_URI } from "../constant";
// import { rootStore } from '../store';

const API = axios.create({
  baseURL: API_URI,
  timeout: 30000,
  headers: {},
});

const configHeaders = {
  "Content-Type": "application/json",
  credentials: "same-origin",
};

API.interceptors.request.use((request) => {
  if (!request.headers["Authorization"] && localStorage.getItem("token"))
    request.headers["Authorization"] = `Bearer ${localStorage.getItem(
      "token"
    )}`;

  return request;
});

API.interceptors.response.use(function (response) {
  console.log("response.data?.isError", response.data?.isError);
  if (response.data?.isError) {
    throw response.data;
  }
  return response;
});

Object.keys(configHeaders).forEach((key) => {
  API.defaults.headers.common[key] = configHeaders[key];
});

export default API;
