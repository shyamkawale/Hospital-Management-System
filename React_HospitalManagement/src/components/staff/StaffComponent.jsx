import DoctorComponent from "./DoctorComponent";
import NurseComponent from "./NurseComponent";
import WardBoyComponent from "./WardBoyComponent";
import { useState } from "react";
import ListComponent from "../ReusableComponent/ListComponent";
// import '../node_modules/bootstrap/scss/forms/_form-control.scss';


const StaffComponent=()=>{

  const [docData,setDocData]=useState([])
  const [NurseData,setNurseData]=useState([])
  const [WardBoyData,setWardBoyData]=useState([])



  const [isDoctorCreate,setDoctorCreate]=useState(false);
  const [isNurseCreate,setNurseCreate]=useState(false);
  const [isWardBoyCreate,setWardBoyCreate]=useState(false);



    const [isDoctorShown,setDoctorShown]=useState(false);
    const [isNurseShown,setNurseShown]=useState(false);
    const [isWardBoyShown,setWardBoyShown]=useState(false);

    async function  doctorlist(){
    
      const response = await fetch(process.env.REACT_APP_API+"/Doctor");
      const data = await response.json();
      setDocData(data);
      // console.log(data);
      // console.log(docData);
      }

      async function  Nurselist(){
    
        const response = await fetch(process.env.REACT_APP_API+"/Nurse");
        const data = await response.json();
        setNurseData(data);
        // console.log(data);
        // console.log(docData);
        }

        async function  WardBoylist(){
    
          const response = await fetch(process.env.REACT_APP_API+"/WardBoy");
          const data = await response.json();
          setWardBoyData(data);
          // console.log(data);
          // console.log(docData);
          }
  
    const handleNurseList=()=>{
      Nurselist();
      setDoctorShown(false);
      setWardBoyShown(false);
      setNurseShown(current=>!current);
    }


    const handleDoctorList=()=>{
      doctorlist();
      setWardBoyShown(false);
      setNurseShown(false);
      setDoctorShown(current=>!current);
    
    }
    const handleWardBoyList=()=>{
      WardBoylist();
      setDoctorShown(false);
      setNurseShown(false);
      setWardBoyShown(current=>!current);
    }

    const handleNewDoc=()=>{
      setWardBoyShown(false);
      setNurseShown(false);
      setDoctorCreate(current=>!current);
    }

    const handleNewNurse=()=>{
      setWardBoyShown(false);
      setNurseCreate(current=>!current);
      setDoctorShown(false);
    }

    const handleNewWardBoy=()=>{
      setWardBoyCreate(current=>!current);
      setNurseShown(false);
      setDoctorShown(false);
    }


   return(
    <div className="app">
      <div className="row">

      <div className="col-sm">
      <button className="btn btn-outline-success" onClick={handleDoctorList}>
Doctor
      </button>
      </div>
      <div className="col-sm">

      <button className="btn btn-outline-success" onClick={handleNurseList}>
Nurse
      </button >
      </div>
      <div className="col-sm">

      <button className="btn btn-outline-success" onClick={handleWardBoyList}>
WardBoy

      </button>
      </div>

</div>

     { isDoctorShown &&
     <div>
      <button className="btn btn-primary" onClick={handleNewDoc}>Create

      </button>
      {!isDoctorCreate && <table className="table table-hover table-dark">
      <thead>
                    <tr>
                        {/* {docData[0] &&
                console.log(Object.keys(docData[0])[1])
                        } */}
                {/* { docData[0] && Object.keys(docData[0]).forEach(key=>key && <th >{key}</th>)
                        } */}
                         {docData[0] &&
                            Object.keys(docData[0]).map((header,index)=>(
                               <th key={index}>{header}</th>
                            ))
                         }
                    </tr>
                </thead>
                <tbody>

      <ListComponent data={docData}/>
      </tbody>
      </table>}
      </div>}
      


      { isWardBoyShown &&
     <div>
      <button className="btn btn-primary" onClick={handleNewWardBoy}>Create

      </button>
      {!isWardBoyCreate && <table className="table table-hover table-dark">
      <thead>
                    <tr>
                        {/* {docData[0] &&
                console.log(Object.keys(docData[0])[1])
                        } */}
                {/* { docData[0] && Object.keys(docData[0]).forEach(key=>key && <th >{key}</th>)
                        } */}
                         {docData[0] &&
                            Object.keys(WardBoyData[0]).map((header,index)=>(
                               <th key={index}>{header}</th>
                            ))
                         }
                    </tr>
                </thead>
                <tbody>

      <ListComponent data={WardBoyData}/>
      </tbody>
      </table>}
      </div>}










      { isNurseShown &&
     <div>
      <button className="btn btn-primary" onClick={handleNewNurse}>Create

      </button>
      {!isNurseCreate && <table className="table table-hover table-dark">
      <thead>
                    <tr>
                        {/* {docData[0] &&
                console.log(Object.keys(docData[0])[1])
                        } */}
                {/* { docData[0] && Object.keys(docData[0]).forEach(key=>key && <th >{key}</th>)
                        } */}
                         {NurseData[0] &&
                            Object.keys(NurseData[0]).map((header,index)=>(
                               <th key={index}>{header}</th>
                            ))
                         }
                    </tr>
                </thead>
                <tbody>

      <ListComponent data={NurseData}/>
      </tbody>
      </table>}
      </div>}








    {isNurseCreate && <NurseComponent handleNewNurse={handleNewNurse}/>}
    {isDoctorCreate && <DoctorComponent handleNewDoc={handleNewDoc}/>}
    {isWardBoyCreate && <WardBoyComponent handleNewWardBoy={handleNewWardBoy}/>}
    </div>
   );
}

export default StaffComponent;