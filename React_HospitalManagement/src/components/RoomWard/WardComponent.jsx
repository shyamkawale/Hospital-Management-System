import { useState } from "react";


const WardComponent=()=>{

    const [data,setData]=useState({'WardId':null,'Name':""});

   
  async function handleAddWard(event){
    event.preventDefault();
    var warddata3 = {
      WardId :data.WardId,
      Name : data.Name
      };
//    console.log(data);
  const response = await fetch(
   
    process.env.REACT_APP_API + "/Ward",
    {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(warddata3)

    }
  )
  console.log(response);
//   props.handleNewDoc();
}




    return(

       
        <form>
        <div className='control-group'>
          <div className='form-control'>
            <label htmlFor='wardId'>WardId</label>
            <input type='number' id='wardId' value={data.WardId} onChange={(e)=>setData({...data,WardId:parseInt(e.target.value)})}/>
          </div>
          <div className='form-control'>
            <label htmlFor='name'>Name</label>
            <input type='text' id='name' value={data.Name} onChange={(e)=>setData({...data,Name:e.target.value})} />
          </div>
          <button onClick={handleAddWard}>Add New Ward</button>
        </div>
      </form>
    )

};

export default WardComponent;