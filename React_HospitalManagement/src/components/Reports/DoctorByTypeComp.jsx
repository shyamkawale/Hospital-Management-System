import React, { useState, useEffect } from "react";

const DoctorByTypeComp = () => {
  var typeList = ["Visiting", "Employee"];
  const [doctorByType, SetdoctorByType] = useState([]);

  async function ListDoctorByType(evt) {
    console.log("changed");
    console.log(evt.target.value);
    if (typeList.includes(evt.target.value)) {
      console.log(evt.target.value + "new");
      const doctorres = await fetch(
        process.env.REACT_APP_API + "/Doctor/DoctorByType/" + evt.target.value
      );
      const doctorList = await doctorres.json();
      SetdoctorByType(doctorList);
      console.log(doctorList);
    }
  }
  return (
    <div>
      <h3>List Doctor By Type</h3>
      <select
        className="form-control"
        onChange={(evt) => ListDoctorByType(evt)}
      >
        {typeList.map((type, idx) => {
          // console.log(e);
          return (
            <option key={idx} value={type}>
              {type}
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
          {doctorByType.length === 0 ? (
            <div className="container">
              <strong>No Data to Display</strong>
            </div>
          ) : (
            doctorByType.map((e, index) => {
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
export default DoctorByTypeComp;
