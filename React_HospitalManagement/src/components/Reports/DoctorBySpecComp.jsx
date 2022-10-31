import React, { useState, useEffect } from "react";

const DoctorBySpecComp = () => {
  var specialisationList = ["Heart", "Brain", "General"];
  const [doctorBySpec, SetdoctorBySpec] = useState([]);

  async function ListDoctorBySpecialisation(evt) {
    console.log("changed");
    console.log(evt.target.value);
    if (specialisationList.includes(evt.target.value)) {
      console.log(evt.target.value + "new");
      const doctorres = await fetch(
        process.env.REACT_APP_API + "/Doctor/DoctorBySpec/" + evt.target.value
      );
      const doctorList = await doctorres.json();
      SetdoctorBySpec(doctorList);
      console.log(doctorList);
    }
  }
  return (
    <div>
      <h3>List Doctor By Specialisation</h3>
      <select
        className="form-control"
        onChange={(evt) => ListDoctorBySpecialisation(evt)}
      >
        {specialisationList.map((spec, idx) => {
          // console.log(e);
          return (
            <option key={idx} value={spec}>
              {spec}
            </option>
          );
        })}
      </select>
      <table className="table table-hover table-dark">
        <thead>
        <tr>
            <td>
DoctorId
            </td>
            <td>
            Name
            </td>
            <td>
            Email
            </td>
            <td>Specialization</td>
                  <td>Fees</td>
                  <td>Type</td>
          </tr>

        </thead>
        <tbody>
          {doctorBySpec.length === 0 ? (
            <div className="container">
              <strong>No Data to Display</strong>
            </div>
          ) : (
            doctorBySpec.map((e, index) => {
              return (
                <tr key={index}>
                  <td>{e.DoctorId}</td>
                  <td>{e.Name}</td>
                  <td>{e.Email}</td>
                  <td>{e.Specialization}</td>
                  <td>{e.Fees}</td>
                  <td>{e.Type}</td>
                </tr>
              );
            })
          )}
        </tbody>
      </table>
    </div>
  );
};
export default DoctorBySpecComp;
