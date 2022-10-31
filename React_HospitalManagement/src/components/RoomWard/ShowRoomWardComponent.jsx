import { useState } from "react";
import RoomComponent from "./RoomComponent";
import WardComponent from "./WardComponent";
import ListComponent from "../ReusableComponent/ListComponent";



const ShowRoomWardComponent=()=>{

    const [wardData,setWardData]=useState([]);
    const [roomData,setRoomData]=useState([]);
    const [wardList,setWardList]=useState(false);
    const [roomList,setRoomList]=useState(false);
    const [wardForm,setWardForm]=useState(false);
    const [roomForm,setRoomForm]=useState(false);



    const addNewWard=()=>{
        setWardForm(current=>!current);
        setRoomForm(false);
    }

    const addNewRoom=()=>{
        setWardForm(false);
        setRoomForm(c=>!c);
    }


    async function Roomlist(){
    
        const response = await fetch(process.env.REACT_APP_API+"/Room");
        const data = await response.json();
        setRoomData(data);
        // console.log(data);
        // console.log(docData);
        setWardList(false);
        setRoomForm(false)
        setRoomList(c=>!c);

        }

        async function Wardlist(){
    
            const response = await fetch(process.env.REACT_APP_API+"/Ward");
            const data = await response.json();
            setWardData(data);
            // console.log(data);
            // console.log(docData);
            setRoomList(false);
            setWardForm(false);
            setWardList(current=>!current);
            
            }

    

    return (
        <div>
            <button onClick={Wardlist} >
                Ward List
            </button>
            <button   onClick={Roomlist}>
                Room List
            </button>
            {wardList && 
            <div>
                <div>
                <button onClick={addNewWard} >Add New Ward</button>
                </div>
                {!wardForm &&
                <div>
                    <table  border={1} cellPadding={10}>
                        <thead>
                            <tr>
                            {wardData[0] &&
                            Object.keys(wardData[0]).map((header,index)=>(
                               <th key={index}>{header}</th>
                            ))
                         }

                            </tr>
                        </thead>
                        <tbody>
                <ListComponent data={wardData}/>
                </tbody>
                </table>
                </div>}
                </div> 
             }


{roomList && 
            <div>
                <div>
                <button onClick={addNewRoom} >Add New Room</button>
                </div>
                {!roomForm &&
                <div>
                    <table  border={1} cellPadding={10}>
                        <thead>
                            <tr>
                            {roomData[0] &&
                            Object.keys(roomData[0]).map((header,index)=>(
                               <th key={index}>{header}</th>
                            ))
                         }

                            </tr>
                        </thead>
                        <tbody>
                <ListComponent data={roomData}/>
                </tbody>
                </table>
                </div>}
                </div> 
             }
            {wardForm && <WardComponent/>}

         
             {roomForm && <RoomComponent/>}
        </div>
    )

};

export default ShowRoomWardComponent;