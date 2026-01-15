import React, { useState } from "react";
import { Link } from "react-router-dom";
import ActionButton from "../ui/ActionButton";
import "../css/auth.css";
import { FaLinkedin } from "react-icons/fa";

function AuthPage() {
  const [usuario, setUsuario] = useState({
    Correo: "",
    Contrasena: "",
  });
  const [isSubmiting, setSubmit] = useState(false);

  const inputHandleChange = (e) => {
    const { name, value } = e.target;
    setUsuario({
      ...usuario,
      [name]: value,
    });
  };
  return (
    <div>
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
            <Link to="https://www.linkedin.com/in/josias-peguero/" className="linkedin-button">
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
            <form>
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
