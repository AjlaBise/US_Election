import React, { useState } from "react";
import axios from "axios";

import "./Home.css";

const Home = () => {
  const [file, setFile] = useState();
  const [fileName, setFileName] = useState();

  const saveFile = (e) => {
    setFile(e.target.files[0]);
    setFileName(e.target.files[0].name);
  };

  const uploadFile = async (e) => {
    const formData = new FormData();
    formData.append("formFile", file);
    formData.append("fileName", "Votes");
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

  return (
    <div>
      <p>Presidential election results</p>
      <div className="box">
        <span>&bull; &bull; &bull;</span>
      </div>
      <div className="uploadDiv">
        <input className="uploadInput" type="file" onChange={saveFile} />
        <button
          className="uploadBtn"
          type="submit"
          onClick={uploadFile}
          value="upload"
        >
          Upload
        </button>
      </div>
    </div>
  );
};

export default Home;
