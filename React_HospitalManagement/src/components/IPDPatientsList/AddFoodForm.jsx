import React, { UseState, UseEffect, useEffect, useState } from "react";

const AddFoodForm = (props) => {
  const [FoodList, SetFoodList] = useState([]);
  const [SelecetedFoodId, SetSelecetedFoodId] = useState(0);
  const [SelecetedFoodPrice, SetSelecetedFoodPrice] = useState(0);
  const [Quantity, SetQuantity] = useState(0);
  const [message, SetMessage] = useState("");
  async function getFoodFromStore() {
    const response = await fetch(process.env.REACT_APP_API + "/Canteen");
    const foodsdata = await response.json();
    SetFoodList(foodsdata);
    console.log(foodsdata);
  }
  useEffect(() => {
    getFoodFromStore();
  }, []);

  const selectkiya = (foodId) => {
    SetSelecetedFoodId(foodId);
    for (var j = 0; j < FoodList.length; j++) {
      console.log(FoodList[j].FoodId + " => " + foodId);
      if (FoodList[j].FoodId === parseInt(foodId)) {
        SetSelecetedFoodPrice(FoodList[j].Price);
      }
    }
  };

  async function submitFood(event) {
    event.preventDefault();
    try {
      const foodbillres = await fetch(
        process.env.REACT_APP_API + "/CanteenBill"
      );
      const allbill = await foodbillres.json();
      var allbillids = [];
      for (let i = 0; i < allbill.length; i++) {
        allbillids[0] = allbill.BillId;
      }

      console.log();
      var randomid = parseInt(Math.random() * 1000) + 1;
      while (allbillids.includes(randomid)) {
        randomid = parseInt(Math.random() * 1000) + 1;
      }

      var foodbillobject = {
        CanteenBillId: randomid,
        BillId: parseInt(props.patient.BillId),
        FoodId: parseInt(SelecetedFoodId),
        Quantity: parseInt(Quantity),
        TotalPrice: parseFloat(SelecetedFoodPrice * Quantity),
      };
      const response = await fetch(process.env.REACT_APP_API + "/CanteenBill", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(foodbillobject),
      });

      const billresponse = await fetch(
        process.env.REACT_APP_API + "/Bill/" + props.patient.BillId
      );
      const billdata = await billresponse.json();
      // console.log(billdata);
      // console.log(billdata.Total_Fees);
      billdata.CanteenCharges =
        billdata.CanteenCharges + SelecetedFoodPrice * Quantity;
      // billdata.Total_Fees =
      //   billdata.Total_Fees + SelecetedFoodPrice * Quantity;

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
      SetMessage("Successfully added food");
    } catch (error) {
      SetMessage("Some error ocured while adding food");
    }
  }

  return (
    <>
      <p>Add Food</p>
      <table className="table table-hover table-dark" >
<tr>
  <td>
    Patient Id
  </td>
  <td>
  <label>Name</label>

  </td>
<td>
<p>FoodList</p>

</td>
</tr>
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
          {FoodList.map((e, idx) => {
            // console.log(e);
            return (
              <option key={idx} value={e.FoodId}>
                {e.Name}
              </option>
            );
          })}
        </select>
</td>

</tr>


      </table>
      <div>
     
        {SelecetedFoodId != 0 && <p>Id Of Selected Food: {SelecetedFoodId}</p>}
        {SelecetedFoodId != 0 && (
          <p>Price Of Selected Food: {SelecetedFoodPrice}</p>
        )}
        <p>Select Quantity</p>
        {SelecetedFoodId != 0 && (
          <input
            type="number"
            onChange={(evt) => SetQuantity(evt.target.value)}
          />
        )}
        {SelecetedFoodId != 0 && (
          <p>TotalPrice: {Quantity * SelecetedFoodPrice}</p>
        )}

        {Quantity != 0 && <button className="btn btn-primary" onClick={submitFood}>Submit</button>}
        {message != "" && <p color="red">{message}</p>}
      </div>
    </>
  );
};

export default AddFoodForm;
