import React, { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import ActionButton from "../ui/ActionButton";
import "../css/auth.css";
import { FaLinkedin } from "react-icons/fa";
import { iniciarSesion } from "../api/axios";
import { ToastContainer, toast } from "react-toastify";
import { AwaitFunction } from "../hooks/AwaitFunction";

function AuthPage() {
  const [usuario, setUsuario] = useState({
    Correo: "",
    Contrasena: "",
  });
  const [isSubmiting, setSubmit] = useState(false);

  const navigate = useNavigate();

  const inputHandleChange = (e) => {
    const { name, value } = e.target;
    setUsuario({
      ...usuario,
      [name]: value,
    });
  };

  const handleSubmit = async () => {
    setSubmit(true);
    try {
      const res = await iniciarSesion(usuario);
      await AwaitFunction(1500);
      if (res.status === 200) {
        setSubmit(false);
        toast.success("Bienvenido");
        navigate("/test");
        // Ejemplo: redirección posterior al login
        // navigate("/dashboard");
      } else if (res.status === 400) {
        toast.warning("Credenciales incorrectas");
      } else {
        toast.info("Respuesta inesperada del servidor");
      }
    } catch (error) {
      if (error.response) {
        // El servidor respondió con un status fuera de 2xx
        const status = error.response.status;

        if (status === 401) {
          toast.error("No autorizado");
        } else if (status === 500) {
          toast.error("Error interno del servidor");
        } else {
          toast.error("Error en la solicitud");
        }
      } else if (error.request) {
        // La petición se hizo pero no hubo respuesta
        toast.error("No se pudo conectar con el servidor");
      } else {
        // Error al configurar la petición
        toast.error("Error inesperado");
      }
    } finally {
      setSubmit(false);
    }
  };
  return (
    <div>
      <ToastContainer position="bottom-right" />
      <section className="auth-section">
        <div className="auth-header">
          <div className="auth-title">
            <hr />
            <h2>Acceder al sistema</h2>
            <hr />
          </div>
          <div className="auth-des">
            <p>Ingresa tus credenciales para iniciar sesion</p>
          </div>
          <div className="header-line"></div>
        </div>
        <div className="auth-form">
          <div className="info-section">
            <Link
              to="https://www.linkedin.com/in/josias-peguero/"
              className="linkedin-button"
            >
              <div className="icon">
                <FaLinkedin />
              </div>
              <div className="info-name">
                <p>Connect With Linkedin</p>
                <span>Josias Peguero</span>
              </div>
            </Link>

            <div className="response-time">
              <div className="response-item">
                <p>Response</p> <span>24h</span>
              </div>
              <div className="response-item">
                <p>Avalible</p> <span>mon - fri</span>
              </div>
            </div>
          </div>
          <div className="form-section">
            <form
              onSubmit={(e) => {
                e.preventDefault();
                handleSubmit();
              }}
            >
              <label htmlFor="">Usuarios</label>
              <input
                type="text"
                placeholder="Correo Institucional"
                name="Correo"
                onChange={inputHandleChange}
              />

              <label htmlFor="">Contrasena</label>
              <input
                type="text"
                placeholder="Pin de la Cuenta"
                name="Contrasena"
                onChange={inputHandleChange}
              />
              <ActionButton
                type="submit"
                content="Iniciar Sesion"
                isActive={isSubmiting}
              />
            </form>
          </div>
        </div>
      </section>
    </div>
  );
}

export default AuthPage;
