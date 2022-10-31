import React, { useEffect, useState } from "react";
import "./Modal.css";

const ModalComponent = (props) => {
  const [data, setData] = useState({
    BillId: props.BillId,
    OPD_Fees: 500,
    Doctor_Fees: 100,
    Other_Fees: 0,
    Medicine_Fees: 0,
    IPD_Advance_Fees: 0,
    Total_Fees: 0,
    CanteenCharges: 0,
    RoomCharges: 0,
  });
  const [roomcharge, SetRoomCharge] = useState(0);
  const [doctorcharge, SetdoctorCharge] = useState(0);

  async function handleAddOPD(event) {
    event.preventDefault();
    // let uniqueValue=new Date().valueOf();
    // setData({...data,BillId:uniqueValue})
    setTimeout(console.log(data), 5000);
    props.setModal(false);

    // setModal(true);
    const response1 = await fetch(
      `${process.env.REACT_APP_API}/Bill/${props.BillId}`,
      {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      }
    );
  }

  async function getRoomCharge() {
    const response = await fetch(process.env.REACT_APP_API + "/Room/"+props.RoomId);
    const data = await response.json();
    SetRoomCharge(data.Charge);

  }
  async function getDoctorCharge() {
    const response = await fetch(process.env.REACT_APP_API + "/Doctor/"+props.DoctorId);
    const data = await response.json();
    SetdoctorCharge(data.Fees);

  }
  useEffect(() => {
    getRoomCharge();
    getDoctorCharge();
    // getDoctorCharge();
  }, []);
  return (
    <div className="modalBackground">
      <div className="modalContainer">
        <div className="titleCloseBtn"></div>
        <div className="title">
          <h1>Patient has been added</h1>
        </div>
        <div className="body">
          <p>Your Bill has been generated . You BillId is</p>
          <br></br>
          <div>{props.BillId}</div>
        </div>
        {!props.IPD ? (
          <div>
            <div className="body">
              <label htmlFor="name">OPD Fees</label>
              <input type="number" id="OPD_Fees" value={500} readOnly />
            </div>
            <div className="body">
              <label htmlFor="name">Doctor Fees</label>
              <input type="number" id="Doctor_Fees" value={100} readOnly />
            </div>
            <div className="body">
              <label htmlFor="name">Other Charges </label>
              <input
                type="number"
                id="Other_Fees"
                onChange={(e) =>
                  setData({ ...data, Other_Fees: e.target.value })
                }
              />
            </div>
          </div>
        ) : (
          <div>
            <div className="body">
              <label htmlFor="name">IPD Advance</label>
              <input
                type="number"
                id="IPD_Advance_Fees"
                onChange={(e) =>
                  setData({ ...data, IPD_Advance_Fees: e.target.value ,OPD_Fees:0})
                }
              />
            </div>
            <div className="body">
              <label htmlFor="name">Doctor Fees</label>
              <input
                type="number"
                id="Doctor_Fees"
                value={doctorcharge}
                readOnly
              />
            </div>
            <div className="body">
              <label htmlFor="name">Room Charge</label>
              <input
                type="number"
                id="Room"
                value={roomcharge}
                readOnly
              />
            </div>
            <div className="body">
              <label htmlFor="name">Other Charges </label>
              <input
                type="number"
                id="Other_Fees"
                onChange={(e) =>
                  setData({ ...data, Other_Fees: e.target.value,Doctor_Fees:doctorcharge ,RoomCharges:roomcharge})
                }
              />
            </div>
          </div>
        )}

        <div className="footer">
          <button onClick={(e) => handleAddOPD(e)} id="cancelBtn">
            Continue
          </button>
        </div>
      </div>
    </div>
  );
};

export default ModalComponent;
