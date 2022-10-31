import { useState } from "react";

const DoctorComponent = (props) => {
  
  const [data,setData]=useState({"DoctorId":0,"Name":"","Email":"","MobileNo":0,"Specialization":"","Fees":0,"Type":""});

  async function handleAdd(event){
    event.preventDefault();
   console.log(data);
  const response = await fetch(
    process.env.REACT_APP_API + "/Doctor",
    {
      method: "POSt",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data)

    }
  )
  // console.log(response);
  props.handleNewDoc();

  }

    return (
      <form className="row g-3 needs-validation">
          {/* <div class="col-md-4">
    <label for="validationCustom01" className="form-label">First name</label>
    <input type="text" className="form-control" id="validationCustom01" value="Mark" required/>
    <div class="valid-feedback">
      Looks good!
    </div> */}
  {/* </div> */}
        <div className='control-group'>
          
          <div className='form-control'>
            <label className="control-label col-sm-2" htmlFor='name'>Doctor Id</label>
            <input type='number' id='docId' value={data.DoctorId} onChange={(e)=>setData({...data,DoctorId:parseInt(e.target.value)})} required/>
          </div>
          <div className="form-control">
            <label className="control-label col-sm-2" For="validationCustom01" >Name</label>
            <input type='text' id="validationCustom01" value={data.Name} onChange={(e)=>setData({...data,Name:e.target.value})} required/>
          </div>
        </div>
        <div className='form-control'>
          <label className="control-label col-sm-2"  htmlFor='name'>E-Mail Address</label>
          <input type='text' id='mail' value={data.Email} onChange={(e)=>setData({...data,Email:e.target.value})} required/>
        </div>
        <div className='form-control'>
          <label htmlFor='name'>Mobile Number</label>
          <input type='number' id='mobile' value={data.MobileNo} onChange={(e)=>setData({...data,MobileNo:parseInt(e.target.value)})} required/>
        </div>
        <div className='form-control'>
          <label htmlFor='name'>Specialization</label>
          <input type='text' id='specialization' value={data.Specialization} onChange={(e)=>setData({...data,Specialization:e.target.value})} required/>
        </div>
        <div className='form-control'>
          <label htmlFor='name'>Fees</label>
          <input type='number' id='fees' value={data.Fees} onChange={(e)=>setData({...data,Fees:parseInt(e.target.value)})} required/>
        </div>
        <div className='form-control'>
          <label htmlFor='name'>Type</label>
          <input type='text' id='type' value={data.Type} onChange={(e)=>setData({...data,Type:e.target.value})} required/>
        </div>
        <div >
          <button className="btn btn-primary" onClick={handleAdd}>Add</button>
        </div>
      </form>
    );
  };
  
  export default DoctorComponent;