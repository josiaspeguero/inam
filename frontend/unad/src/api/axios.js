import axios from "axios";

const baseUrl = "http://localhost:5135";

export const iniciarSesion = async (usuario) => {
  const response = await axios.post(
    `${baseUrl}/api/estudiantes/iniciar-sesion`,
    usuario
  );
  return response;
};
