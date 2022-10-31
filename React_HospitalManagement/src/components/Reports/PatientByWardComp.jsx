import React, { useState, useEffect } from "react";

const PatientByWardComp = () => {
  const [allward, Setallward] = useState([]);
  // const [allroomsinward, Setallroomsinward] = useState([]);
  const [selectedWard, SetSelectedWard] = useState("");
  const [patientByWard, SetpatientByWard] = useState([]);

  async function ListPatientByWard(wardid) {
    SetpatientByWard([]);
    SetSelectedWard(wardid);
    console.log("changed");
    console.log(wardid);
    const roomres = await fetch(
      process.env.REACT_APP_API + "/Room/RoomsByWard/" + wardid
    );
    const roomlist = await roomres.json();
    console.log(roomlist);
    // console.log(patlist);
    var patlisttemp = [];
    for (let i = 0; i < roomlist.length; i++) {
      const roomid = roomlist[i].RoomId;
      const patres = await fetch(
        process.env.REACT_APP_API + "/Patient/PatientByRoomId/" + roomid
      );
      const patlist = await patres.json();
      console.log("before");
      console.log(patlist);

      patlisttemp.push.apply(patlisttemp, patlist);

      console.log("in for" + roomid);
      console.log(patlist);
    }
    SetpatientByWard(patlisttemp);
  }
  async function getAllWards() {
    const response = await fetch(process.env.REACT_APP_API + "/Ward");
    const wardsdata = await response.json();
    Setallward(wardsdata);
  }

  useEffect(() => {
    getAllWards();
  }, []);
  return (
    <div>
      <h3>List Patient By Ward</h3>
      <select
        className="form-control"
        onChange={(evt) => ListPatientByWard(evt.target.value)}
      >
        {allward.map((ward, idx) => {
          return (
            <option key={idx} value={ward.WardId}>
              {ward.Name}
            </option>
          );
        })}
      </select>
      <table className="table table-hover table-dark">
      <thead>
          <tr>
            <td>selectedWard</td>
            <td>PatientId</td>
            <td>FirstName</td>
            <td>LastName</td>
            <td>IsAdmitted</td>
            <td>Gender</td>
          </tr>
        </thead>
        <tbody>
          {patientByWard.length === 0 ? (
            <div className="container">
              <strong>No Data to Display</strong>
            </div>
          ) : (
            patientByWard.map((e, index) => {
              return (
                <tr key={index}>
                  <td>{selectedWard}</td>
                  <td>{e.PatientId}</td>
                  <td>{e.FirstName}</td>
                  <td>{e.LastName}</td>
                  <td>{e.IsAdmitted}</td>
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

export default PatientByWardComp;
