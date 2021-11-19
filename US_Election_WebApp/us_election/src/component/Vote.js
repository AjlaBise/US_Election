import React, { useEffect, useState } from "react";
import axios from "axios";
import Table from "react-bootstrap/Table";

import "./Home.css";

const Vote = () => {
  const [data, setData] = useState([]);
  const [dataElectorate, setDataElectorate] = useState([]);

  useEffect(() => {
    getDataFrom();
    getElectorate();
  }, []);

  const getElectorate = () => {
    axios
      .get(`https://localhost:5001/api/ElectorateControler/getElectorate`)
      .then((res) => {
        setDataElectorate(res.data);
        console.log(res);
      });
  };

  const getDataFrom = () => {
    axios.get(`https://localhost:5001/api/Vote/getVotes`).then((res) => {
      setData(res.data);
      console.log(res);
    });
  };

  return (
    <div className="uploadDiv">
      {dataElectorate.map((dataEntry) => {
        return (
          <div
            key={dataEntry.id}
            style={{
              width: "100%",
              display: "flex",
              alignItems: "center",
              justifyContent: "center",
              flexDirection: "column",
            }}
          >
            <p style={{ color: "white" }}>{dataEntry.name}</p>
            <div className="readData">
              <Table striped bordered hover>
                <thead>
                  <tr>
                    <th>#</th>
                    <th>Name</th>
                    <th>Votes</th>
                    <th>Parcentage</th>
                    <th>Error</th>
                  </tr>
                </thead>
                <tbody>
                  <tr>
                    <td>1</td>
                    <td>Mark</td>
                    <td>Otto</td>
                    <td>@mdo</td>
                  </tr>
                  <tr>
                    <td>2</td>
                    <td>Jacob</td>
                    <td>Thornton</td>
                    <td>@fat</td>
                  </tr>
                  <tr>
                    <td>3</td>
                    <td colSpan="2">Larry the Bird</td>
                    <td>@twitter</td>
                  </tr>
                </tbody>
              </Table>
            </div>
          </div>
        );
      })}
    </div>
  );
};

export default Vote;
