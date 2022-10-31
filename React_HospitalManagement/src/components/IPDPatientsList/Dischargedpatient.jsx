import React, { useEffect, useState } from "react";
const DischargedPatient = (props) => {
  const [Bill, SetBill] = useState([]);
  const [tempBill, SettempBill] = useState([]);
  const [isSeeMedicineBill, SetisSeeMedicineBill] = useState(false);
  const [MedicineBill, SetMedicineBill] = useState([]);
  const [isSeeCanteenBill, SetisSeeCanteenBill] = useState(false);
  const [CanteenBill, SetCanteenBill] = useState([]);
  async function getBill() {
    const response = await fetch(
      process.env.REACT_APP_API + "/Bill/" + props.patient.BillId
    );
    const billData = await response.json();
    SetBill(billData);
    SettempBill(billData);
  }
  console.log(Bill);
  // const onNoOfDaysChanged = (evt) => {
  //   var days = evt.target.value;
  //   // SetNoOfDays(days);
  //   SetBill((prevState) => {
  //     return {
  //       ...prevState,
  //       RoomCharges: tempBill.RoomCharges * days,
  //       Doctor_Fees: tempBill.Doctor_Fees * days,
  //       Total_Fees: tempBill.Doctor_Fees * days,
  //       // tempBill.Total_Fees +
  //       // tempBill.RoomCharges * (days - 1) +
  //       // tempBill.Doctor_Fees * (days - 1),
  //     };
  //   });
  // };
  async function dischargeKarDo() {
    const deleteMedicineBillsresponse = await fetch(
      process.env.REACT_APP_API +
        "/MedicineBill/DeleteMedicineBillsByBillId/" +
        props.patient.BillId,
      {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
        },
      }
    );
    const deleteCanteenBillsresponse = await fetch(
      process.env.REACT_APP_API +
        "/CanteenBill/DeleteCanteenBillsByBillId/" +
        props.patient.BillId,
      {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
        },
      }
    );
    const deleteBillsresponse = await fetch(
      process.env.REACT_APP_API + "/Bill/" + props.patient.BillId,
      {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
        },
      }
    );
    const deletePatientsresponse = await fetch(
      process.env.REACT_APP_API + "/Patient/" + props.patient.PatientId,
      {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
        },
      }
    );
    props.isDis(false);
  }
  async function seeMedicineBillDetails() {
    const response = await fetch(
      process.env.REACT_APP_API +
        "/MedicineBill/MedicineBillsByBillId/" +
        props.patient.BillId
    );
    const medicineBillData = await response.json();
    SetMedicineBill(medicineBillData);
    SetisSeeMedicineBill(true);
  }
  async function seeCanteenBillDetails() {
    const response = await fetch(
      process.env.REACT_APP_API +
        "/CanteenBill/CanteenBillsByBillId/" +
        props.patient.BillId
    );
    const canteenBillData = await response.json();
    SetCanteenBill(canteenBillData);
    SetisSeeCanteenBill(true);
  }
  useEffect(() => {
    getBill();
  }, [props]);
  // console.log(Bill);
  return (
    <div>
      <p>Discharged Patient Name: {props.patient.FirstName}</p>
      <p>Review Bill</p>
      <p>Enter No of Days Patient stayed In hospital</p>
      <input
        type="number"
        onChange={(evt) => {
          SetBill((prevState) => {
            return {
              ...prevState,
              RoomCharges: tempBill.RoomCharges * evt.target.value,
              Doctor_Fees: tempBill.Doctor_Fees * evt.target.value,
              Total_Fees:
                tempBill.Total_Fees +
                tempBill.RoomCharges * (evt.target.value - 1) +
                tempBill.Doctor_Fees * (evt.target.value - 1),
            };
          });
        }}
      />
      <table border={1}>
        <thead>
          <tr>
            <td>BillId</td>
            <td>OPD_Fees</td>
            <td>Doctor_Fees</td>
            <td>Other_Fees</td>
            <td>MedicineCharges</td>
            <td>CanteenCharges</td>
            <td>IPD_Advance_Fees</td>
            <td>RoomCharges</td>
            <td>Total_Fees</td>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>{Bill.BillId}</td>
            <td>{Bill.OPD_Fees}</td>
            <td>{Bill.Doctor_Fees}</td>
            <td>{Bill.Other_Fees}</td>
            <td>{Bill.MedicineCharges}</td>
            <td>{Bill.CanteenCharges}</td>
            <td>{Bill.IPD_Advance_Fees}</td>
            <td>{Bill.RoomCharges}</td>
            <td>{Bill.Total_Fees}</td>
          </tr>
        </tbody>
      </table>
      <button onClick={seeMedicineBillDetails}>See Medicine Details</button>
      {isSeeMedicineBill === true && (
        <>
          <table>
            <tbody>
              {MedicineBill.map((e, index) => {
                // console.log(e);
                return (
                  <tr key={index}>
                    <td>{e.MedicineBillId}</td>
                    <td>{e.MedicineId}</td>
                    <td>{e.Quantity}</td>
                    <td>{e.TotalPrice}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </>
      )}
      <button onClick={seeCanteenBillDetails}>See Canteen Details</button>
      {isSeeCanteenBill === true && (
        <>
          <table>
            <tbody>
              {CanteenBill.map((e, index) => {
                // console.log(e);
                return (
                  <tr key={index}>
                    <td>{e.CanteenBillId}</td>
                    <td>{e.FoodId}</td>
                    <td>{e.Quantity}</td>
                    <td>{e.TotalPrice}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </>
      )}
      <button onClick={() => {}}>Print Bill</button>
      <button onClick={dischargeKarDo}>Confirm and Discharge Patient</button>
    </div>
  );
};
export default DischargedPatient;
