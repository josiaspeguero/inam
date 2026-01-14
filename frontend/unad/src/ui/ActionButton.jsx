import React from "react";
import "../css/ui.css";

function ActionButton({ type, isActive = false, content = "" }) {
  return (
    <button className="ui-button">
      <div className="button-text">
        <span>{content}</span>
      </div>
      <div className="button-animation"></div>
    </button>
  );
}

export default ActionButton;
