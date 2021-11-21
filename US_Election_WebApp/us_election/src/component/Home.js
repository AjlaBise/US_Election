import React, { useState } from "react";
import axios from "axios";

import "./Home.css";

const Home = () => {
  const [file, setFile] = useState();

  const saveFile = (e) => {
    setFile(e.target.files[0]);
  };

  const uploadFile = async (e) => {
    const formData = new FormData();
    formData.append("formFile", file);

    try {
      const res = await axios.post(
        `https://localhost:5001/api/Vote/postVotes`,
        formData
      );
      setFile(res.data);
    } catch (ex) {
      console.log(ex);
    }
  };

  const checkExstension = () => {
    const extension = file.name.split(".")[1];
    if (extension !== "csv") alert("Please select correct format of the file!");
  };

  return (
    <div>
      <p>Presidential election results</p>
      <div className="box">
        <span>&bull; &bull; &bull;</span>
      </div>
      <div className="uploadDiv">
        <input className="uploadInput" type="file" onChange={saveFile} />
        <button
          disabled={!file}
          className="uploadBtn"
          type="submit"
          onClick={() => {
            checkExstension();
            uploadFile();
            window.location.reload(true);
          }}
          value="upload"
        >
          Upload
        </button>
      </div>
    </div>
  );
};

export default Home;
