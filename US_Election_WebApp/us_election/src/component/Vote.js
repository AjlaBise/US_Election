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
                    <th style={{ paddingLeft: "35px" }}>Name</th>
                    <th style={{ paddingLeft: "35px" }}>Votes</th>
                    <th style={{ paddingLeft: "35px" }}>Parcentage</th>
                    <th style={{ paddingLeft: "35px" }}>Error</th>
                  </tr>
                </thead>
                {data.map((dataVotes) => {
                  if (dataEntry.id === dataVotes.electorateId) {
                    return (
                      <>
                        <tbody>
                          <tr>
                            <td style={{ paddingLeft: "35px" }}>
                              {dataVotes.candidateId}
                            </td>
                            <td style={{ paddingLeft: "35px" }}>
                              {dataVotes.numberOfVotes}
                            </td>
                            <td style={{ paddingLeft: "35px" }}>sum</td>
                            <td style={{ paddingLeft: "35px" }}>
                              {dataVotes.overrideFile ? "Error" : "-"}
                            </td>
                          </tr>
                        </tbody>
                      </>
                    );
                  }
                })}
              </Table>
            </div>
          </div>
        );
      })}
    </div>
  );
};

export default Vote;
