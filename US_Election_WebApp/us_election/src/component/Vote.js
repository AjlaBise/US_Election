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
                    <th>Name</th>
                    <th>Votes</th>
                    <th>Parcentage</th>
                    <th>Error</th>
                  </tr>
                </thead>
                {data.map((dataVotes) => {
                  if (dataEntry.id === dataVotes.electorateId) {
                    console.log("dataa", dataVotes);
                    return (
                      <>
                        <tbody>
                          <tr>
                            <td>{dataVotes.candidateName}</td>
                            <td>{dataVotes.numberOfVotes}</td>
                            <td>sum</td>
                            <td>{dataVotes.overrideFile ? "Error" : "-"}</td>
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
