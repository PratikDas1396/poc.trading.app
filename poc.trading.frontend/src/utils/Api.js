import axios from "axios";
import { API_BASE_URL } from "../constant";

export const authGetApi = async ({ url }) => {
  const config = {
    headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
  };
  try {
    const res = await axios.get(`${API_BASE_URL}${url}`, config);
    return res.data;
  } catch (err) {
    console.log({ err });
  }
};

export const authPostApi = async ({ url, payload }) => {
  const config = {
    headers: { Authorization: `Bearer ${localStorage.getItem("token")}` },
  };
  try {
    const res = await axios.post(`${API_BASE_URL}${url}`, payload, config);
    return res.data;
  } catch (err) {
    console.log({ err });
  }
};

export const getApi = async ({ url }) => {
  try {
    const res = await axios.get(`${API_BASE_URL}${url}`);
    return res.data;
  } catch (err) {
    console.log({ err });
  }
};

export const postApi = async ({ url, payload }) => {
  try {
    const res = await axios.post(`${API_BASE_URL}${url}`, payload);
    return res.data;
  } catch (err) {
    console.log({ err });
  }
};
