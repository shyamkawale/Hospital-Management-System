import { useEffect, useState } from "react";
import ListComponent from "../ReusableComponent/ListComponent";
import OpdPatientComponent from "./OpdPatientComponent";

const PatientListComponent=()=>{

    const [patientData,setPatientData]=useState([])
    const [addNewPatient,setAddNewPatient]=useState(false);
    const [showList,setShowList]=useState(true);

    const handleNewPatient=()=>{
        setShowList(false);
        setAddNewPatient(current=>!current);

    }

    useEffect(()=>{
        PatientList();}
        ,[]);

    async function  PatientList(){
    
        const response = await fetch(process.env.REACT_APP_API+"/Patient");
        const data = await response.json();
        setPatientData(data);
        // console.log(data);
        // console.log(docData);
        }

        return(
    <div className="app">
            
              {showList && <div>  <button onClick={handleNewPatient}>Add New Patient</button>
<table className="table table-hover table-dark">
    <thead >
        <tr>
        {patientData[0] &&
                            Object.keys(patientData[0]).map((header,index)=>(
                               <th key={index}>{header}</th>
                            ))
                         }

        </tr>
    </thead>
    <tbody>
     <ListComponent data={patientData}></ListComponent>
    </tbody>
</table> 
</div>}
{addNewPatient && <OpdPatientComponent/>}
</div>
        )
};

export default PatientListComponent;