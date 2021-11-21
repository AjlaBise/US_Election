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
          <div key={dataEntry.id} className="electrateDiv">
            <p style={{ color: "white" }}>{dataEntry.name}</p>
            <div className="readData">
              <Table striped bordered hover>
                <thead>
                  <tr>
                    <th style={{ paddingLeft: "20px" }}>Name</th>
                    <th style={{ paddingLeft: "20px" }}>Votes</th>
                    <th style={{ paddingLeft: "20px" }}>Parcentage</th>
                    <th style={{ paddingLeft: "20px" }}>Error</th>
                  </tr>
                </thead>
                {data.map((dataVotes) => {
                  if (dataEntry.id === dataVotes.electorateId) {
                    return (
                      <>
                        <tbody>
                          <tr>
                            <td
                              style={{
                                paddingLeft: "20px",
                                paddingTop: "10px",
                              }}
                            >
                              {dataVotes.candidateName}
                            </td>
                            <td
                              style={{
                                paddingLeft: "20px",
                                paddingTop: "10px",
                              }}
                            >
                              {dataVotes.numberOfVotes}
                            </td>
                            <td
                              style={{
                                paddingLeft: "20px",
                                paddingTop: "10px",
                              }}
                            >
                              15878
                            </td>
                            <td
                              style={{
                                paddingLeft: "20px",
                                paddingTop: "10px",
                              }}
                            >
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
