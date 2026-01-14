import axios from "axios";

const baseUrl = "";

const iniciarSesion = async (usuario) => {
  const response = await axios.post(`${baseUrl}/`, usuario);
  return response;
};
