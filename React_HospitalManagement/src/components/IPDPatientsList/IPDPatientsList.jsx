import React, { useEffect, useState } from "react";
import AddFoodForm from "./AddFoodForm";
import AddMedicineForm from "./AddMedicineForm";
import DischargedPatient from "./Dischargedpatient";

const IPDPatientsList = () => {
  const [IPDPatients, SetIPDPatient] = useState([]);
  const [Patient, setPatient] = useState({});
  const [IsAddingMedicine, SetIsAddingMedicine] = useState(false);
  const [IsAddingFood, SetIsAddingFood] = useState(false);
  const [IsDischarged, SetIsDischarged] = useState(false);

  async function loadData() {
    const response = await fetch(
      process.env.REACT_APP_API + "/Patient/PatientsByCategory/IPD"
    );
    const data = await response.json();
    // SetIPDPatient(data);
    console.log(data);
    console.log(data.length);
    for (var i = 0; i < data.length; i++) {
      var billId = data[i].BillId;
      const response = await fetch(
        process.env.REACT_APP_API + "/Bill/" + billId
      );
      const billData = await response.json();
      var total_bill_value = billData.Total_Fees;
      console.log(data[i].FirstName + " => " + total_bill_value);
      data[i]["Total_bill"] = total_bill_value;
    }
    SetIPDPatient(data);
  }
  // async function findBillTotalMoney() {
  //   console.log("skadjflk");
  //   for (var i = 0; i < IPDPatients.length(); i++) {
  //     var billId = IPDPatients[i].BillId;
  //     const response = await fetch(
  //       process.env.REACT_APP_API + "/Bill/" + billId
  //     );
  //     const billData = await response.json();
  //     var total_bill_value = billData.Total_Fees;
  //     console.log(IPDPatients[i].FirstName + " => " + total_bill_value);
  //     IPDPatients[i]["Total_bill"] = total_bill_value;
  //     SetIPDPatient(IPDPatients);
  //   }
  // }
  useEffect(() => {
    loadData();
    // findBillTotalMoney();
  }, [IsDischarged]);
  // console.log(IPDPatients);
  return (
    <div className="app">
      <p>PatientIPDS</p>

      <table className="table table-hover table-dark" >
        <thead>
          <tr>
          <td>Name</td>
          <td>IsAdmitted</td>
          <td>Doctor Id</td>
          <td>Bill Id</td>
          <td>RoomId</td>
          <td>Total Bill</td>
          </tr>
        </thead>
        <tbody>
          {IPDPatients === undefined ||
          IPDPatients === null ||
          IPDPatients.length === 0 ? (
            <div className="container">
              <strong>No Data to Display</strong>
            </div>
          ) : (
            IPDPatients.map((e, index) => {
              // console.log(e);
              return (
                <tr key={index}>
                  <td>{e.FirstName}</td>
                  <td>{e.IsAdmitted}</td>
                  <td>{e.AssignedDoctorId}</td>
                  <td>{e.BillId}</td>
                  <td>{e.RoomId}</td>
                  <td>{e.Total_bill}</td>
                  <td>
                    <button className="btn btn-primary"
                      type="button"
                      onClick={() => {
                        SetIsAddingMedicine(true);
                        SetIsAddingFood(false);
                        SetIsDischarged(false);
                        setPatient(e);
                        console.log(e);
                      }}
                    >
                      Add Medicine
                    </button>
                  </td>
                  <td>
                    <button className="btn btn-primary"
                      type="button"
                      onClick={() => {
                        SetIsAddingFood(true);
                        SetIsAddingMedicine(false);
                        SetIsDischarged(false);
                        setPatient(e);
                        console.log(e);
                      }}
                    >
                      Add Food
                    </button>
                  </td>
                  <td>
                    <button className="btn btn-primary"
                      type="button"
                      onClick={() => {
                        SetIsDischarged(true);
                        SetIsAddingFood(false);
                        SetIsAddingMedicine(false);
                        setPatient(e);
                        console.log(e);
                      }}
                    >
                      Discharge
                    </button>
                  </td>
                </tr>
              );
            })
          )}
        </tbody>
      </table>
      {IsAddingMedicine === true && <AddMedicineForm patient={Patient} />}
      {IsAddingFood === true && <AddFoodForm patient={Patient} />}
      {IsDischarged === true && (
        <DischargedPatient patient={Patient} isDis={SetIsDischarged} />
      )}
      {/* <AddMedicineForm patient={Patient} />} */}
    </div>
  );
};

export default IPDPatientsList;
