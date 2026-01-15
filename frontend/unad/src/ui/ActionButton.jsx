import React from "react";
import "../css/ui.css";

function ActionButton({ type, isActive = false, content = "" }) {
  return (
    <button className="ui-button" disabled={isActive} type={type}>
      <div className={isActive ? "button-text-disabled" : "button-text"}>
        <span>{content}</span>
      </div>
      <div className={isActive ? "loader-btn" : "loader-btn-disabled"}></div>
    </button>
  );
}

export default ActionButton;
