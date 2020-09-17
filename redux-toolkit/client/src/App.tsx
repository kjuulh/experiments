import React from "react";
import "./App.scss";
import Axios from "axios";
const addTo = (className: string, suffix: string) => `${className}--${suffix}`;

const ShowContent = ({ message, status }: { message: any; status: string }) => {
  const mainClass = "app__content";
  return message || status ? (
    <div className={`${mainClass} ${addTo(mainClass, status)}`}>
      {JSON.stringify(message)}
    </div>
  ) : null;
};

const App = () => {
  const [status, setStatus] = React.useState("");
  const [message, setMessage] = React.useState();

  const callApi = () => {
    setStatus("pending");
    Axios.get("http://localhost:8000/")
      .then((resp) => {
        setStatus("resolved");
        setMessage(resp.data);
      })
      .catch((err) => {
        setStatus("rejected");
        setMessage(err);
      });
  };

  return (
    <div className="app">
      <div className="app__header" onClick={callApi}>
        Call api
      </div>
      <ShowContent message={message} status={status} />
    </div>
  );
};

export default App;
