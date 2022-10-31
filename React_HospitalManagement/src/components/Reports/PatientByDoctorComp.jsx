import React, { useState, useEffect } from "react";

const PatientByDoctorComp = () => {
  const [alldoctor, Setalldoctor] = useState([]);
  const [selectedDoctor, SetSelectedDoctor] = useState("");
  const [patientByDoctor, SetpatientByDoctor] = useState([]);

  async function ListPatientByDoctor(evt) {
    SetSelectedDoctor(evt.target.value);
    console.log("changed");
    console.log(evt.target.value);

    console.log(evt.target.value + "new");
    const patres = await fetch(
      process.env.REACT_APP_API +
        "/Patient/PatientByDoctorId/" +
        evt.target.value
    );
    const patlist = await patres.json();
    SetpatientByDoctor(patlist);
    console.log(patlist);
  }
  async function getAllDoctors() {
    const response = await fetch(process.env.REACT_APP_API + "/Doctor");
    const doctorsdata = await response.json();
    Setalldoctor(doctorsdata);
  }

  useEffect(() => {
    getAllDoctors();
  }, []);
  return (
    <div>
      <h3>List Patient By Doctor</h3>
      <select
        className="form-control"
        onChange={(evt) => ListPatientByDoctor(evt)}
      >
        {alldoctor.map((doc, idx) => {
          return (
            <option key={idx} value={doc.DoctorId}>
              {doc.Name}
            </option>
          );
        })}
      </select>
      <table className="table table-hover table-dark">
        <thead>
          <tr>
            <td>selectedDoctor</td>
            <td>PatientId</td>
            <td>FirstName</td>
            <td>LastName</td>
            <td>IsAdmitted</td>
            <td>Gender</td>
          </tr>
        </thead>
        <tbody>
          {patientByDoctor.length === 0 ? (
            <div className="container">
              <strong>No Data to Display</strong>
            </div>
          ) : (
            patientByDoctor.map((e, index) => {
              console.log(e.IsAdmitted,"hi");
              return (
                <tr key={index}>
                  <td>{selectedDoctor}</td>
                  <td>{e.PatientId}</td>
                  <td>{e.FirstName}</td>
                  <td>{e.LastName}</td>
                  <td>{e.IsAdmitted.toString()}</td>
            
                  <td>{e.Gender}</td>
                </tr>
              );
            })
          )}
        </tbody>
      </table>
    </div>
  );
};

export default PatientByDoctorComp;
