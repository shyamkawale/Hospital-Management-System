import React, { useEffect, useState } from "react";

const AddMedicineForm = (props) => {
  const [MedicineList, SetMedicineList] = useState([]);
  const [SelecetedMedicineId, SetSelecetedMedicineId] = useState(0);
  const [SelecetedMedicinePrice, SetSelecetedMedicinePrice] = useState(0);
  const [Quantity, SetQuantity] = useState(0);
  const [message, SetMessage] = useState("");
  async function getMedicineFromStore() {
    const response = await fetch(process.env.REACT_APP_API + "/MedicineStore");
    const medicinesdata = await response.json();
    SetMedicineList(medicinesdata);
    console.log(medicinesdata);
  }
  useEffect(() => {
    getMedicineFromStore();
  }, []);

  const selectkiya = (medicineId) => {
    SetSelecetedMedicineId(medicineId);
    for (var j = 0; j < MedicineList.length; j++) {
      console.log(MedicineList[j].MedicineId + " => " + medicineId);
      if (MedicineList[j].MedicineId === parseInt(medicineId)) {
        SetSelecetedMedicinePrice(MedicineList[j].Price);
      }
    }
  };

  async function submitMedicine(event) {
    event.preventDefault();
    try {
      // var warddata3 = {
      //   WardId: 124,
      //   Name: "wardnew",
      // };
      // const wardresponse = await fetch(process.env.REACT_APP_API + "/Ward", {
      //   method: "POST",
      //   headers: {
      //     "Content-Type": "application/json",
      //   },
      //   body: JSON.stringify(warddata3),
      // });
      // console.log(data);
      const medicinebillres = await fetch(
        process.env.REACT_APP_API + "/MedicineBill"
      );
      const allbill = await medicinebillres.json();
      var allbillids = [];
      for (let i = 0; i < allbill.length; i++) {
        allbillids[0] = allbill.BillId;
      }

      console.log();
      var randomid = parseInt(Math.random() * 1000) + 1;
      while (allbillids.includes(randomid)) {
        randomid = parseInt(Math.random() * 1000) + 1;
      }

      var medicinebillobject = {
        MedicineBillId: randomid,
        BillId: parseInt(props.patient.BillId),
        MedicineId: parseInt(SelecetedMedicineId),
        Quantity: parseInt(Quantity),
        TotalPrice: parseFloat(SelecetedMedicinePrice * Quantity),
      };
      const response = await fetch(
        process.env.REACT_APP_API + "/MedicineBill",
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(medicinebillobject),
        }
      );

      const billresponse = await fetch(
        process.env.REACT_APP_API + "/Bill/" + props.patient.BillId
      );
      const billdata = await billresponse.json();
      // console.log(billdata);
      // console.log(billdata.Total_Fees);
      billdata.MedicineCharges =
        billdata.MedicineCharges + SelecetedMedicinePrice * Quantity;
      // billdata.Total_Fees =
      //   billdata.Total_Fees + SelecetedMedicinePrice * Quantity;

      // console.log(billdata.Total_Fees);
      console.log(billdata);
      const putresponse = await fetch(
        process.env.REACT_APP_API + "/Bill/" + props.patient.BillId,
        {
          method: "PUT",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(billdata),
        }
      );
      SetMessage("Successfully added medicine");
    } catch (error) {
      SetMessage("Some error ocured while adding medicine");
    }
  }

  return (
    <>
      <p>Add Medicine</p>
      <div>
        <table className="table table-hover table-dark" >
          <thead>
            <tr>
              <td>
                Patient Id
              </td>
              <td>
              <label>Name :</label>
           </td>
           <td>
              <p>MedicineList</p>
              </td>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>
                {props.patient.PatientId}
              </td>
              <td>
              <p>{props.patient.FirstName}</p>
              </td>
              <td>
              <select
                className="form-control"
                onChange={(evt) => selectkiya(evt.target.value)}
              >
                {MedicineList.map((e, idx) => {
                  // console.log(e);
                  return (
                    <option key={idx} value={e.MedicineId}>
                      {e.Name}
                    </option>
                  );
                })}
              </select>
              </td>
            </tr>
          </tbody>
        </table>
        {SelecetedMedicineId != 0 && (
          <p>Id Of Selected Medicine: {SelecetedMedicineId}</p>
        )}
        {SelecetedMedicineId != 0 && (
          <p>Price Of Selected Medicine: {SelecetedMedicinePrice}</p>
        )}
        <p>Select Quantity</p>
        {SelecetedMedicineId != 0 && (
          <input
            type="number"
            onChange={(evt) => SetQuantity(evt.target.value)}
          />
        )}
        {SelecetedMedicineId != 0 && (
          <p>TotalPrice: {Quantity * SelecetedMedicinePrice}</p>
        )}

        {Quantity != 0 && <button className="btn btn-primary" onClick={submitMedicine}>Submit</button>}
        {message != "" && <p color="red">{message}</p>}
      </div>
    </>
  );
};

export default AddMedicineForm;
