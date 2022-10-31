import { useState } from "react";


const NurseComponent = (props) => {
  const [data,setData]=useState({"NurseId":0,"Name":"","Email":"","MobileNo":0,"Fees":0});


  async function handleAdd(event){
    event.preventDefault();
   console.log(data);
  const response = await fetch(
    process.env.REACT_APP_API + "/Nurse",
    {
      method: "POSt",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data)

    }
  )
  console.log(response);
  props.handleNewNurse();

  }


    return (
      <form class="row g-3 needs-validation" novalidate>
        <div className='control-group'>
          <div className='form-control'>
            <label htmlFor='name'>Nurse Id</label>
            <input type='number' id='nurseId' value={data.NurseId} onChange={(e)=>setData({...data,NurseId:parseInt(e.target.value)})}/>
          </div>
          <div className='form-control'>
            <label htmlFor='name'>Name</label>
            <input type='text' id='name' value={data.Name} onChange={(e)=>setData({...data,Name:e.target.value})}/>
          </div>
        </div>
        <div className='form-control'>
          <label htmlFor='name'>E-Mail Address</label>
          <input type='text' id='mail' value={data.Email} onChange={(e)=>setData({...data,Email:e.target.value})}/>
        </div>
        <div className='form-control'>
          <label htmlFor='name'>Number</label>
          <input type='number' id='mobile' value={data.MobileNo} onChange={(e)=>setData({...data,MobileNo:parseInt(e.target.value)})}/>
        </div>
        <div className='form-control'>
          <label htmlFor='name'>Fees</label>
          <input type='number' id='fees' value={data.Fees} onChange={(e)=>setData({...data,Fees:parseInt(e.target.value)})}/>
        </div>
        <div className='form-actions'>
          <button onClick={handleAdd}>Add</button>
        </div>
      </form>
    );
  };
  
  export default NurseComponent;