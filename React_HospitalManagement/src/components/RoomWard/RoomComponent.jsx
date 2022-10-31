import { useState } from "react";

const RoomComponent=()=>{

    const [data,setData]=useState({'RoomId':null,'Name':"",'IsAvailable':true,'Charge':null,'WardId':null});

   
  async function handleAddRoom(event){
    event.preventDefault();
//    console.log(data);
  const response = await fetch(
    process.env.REACT_APP_API + "/Room",
    {
      method: "POSt",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data)

    }
  )
  // console.log(response);
//   props.handleNewDoc();
}




    return(

       
        <form>
        <div className='control-group'>
          <div className='form-control'>
            <label htmlFor='RoomId'>RoomId</label>
            <input type='number' id='RoomId' onChange={(e)=>setData({...data,RoomId:parseInt(e.target.value)})}/>
          </div>
          <div className='form-control'>
            <label htmlFor='name'>Name</label>
            <input type='text' id='name' onChange={(e)=>setData({...data,Name:e.target.value})} />
          </div>
          <div className='form-control'>
            <label htmlFor='IsAvailablee'>Availablity</label>
            <input type='boolean' id='IsAvailable' 
            onChange={(e)=>setData({...data,IsAvailable:true})}
             />
          </div>
          <div className='form-control'>
            <label htmlFor='charge'>Charge</label>
            <input type='number' id='charge' onChange={(e)=>setData({...data,Charge:parseInt(e.target.value)})}/>
          </div>
          {/* <div className='form-control'>
            <label htmlFor='WardId'>WardId</label>
            <input type='number' id='WardId' onChange={(e)=>setData({...data,WardId:parseInt(e.target.value)})}/>
          </div> */}
          <div>
          <label>
          WardId:  </label>
          <select  onChange={(e)=>setData({...data,WardId:parseInt(e.target.value)})}>
            <option value='1'>WardA</option>
            <option value="2">WardB</option>
            <option value="3">WardC</option>
            <option value="4">WardD</option>
            <option value="5">WardE</option>

          </select>
      
        </div>

          <button onClick={handleAddRoom}>Add New Ward</button>
        </div>
      </form>
    )

};

export default RoomComponent;