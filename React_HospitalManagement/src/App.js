import StaffComponent from "./components/staff/StaffComponent";
import OpdPatientComponent from "./components/Patient/OpdPatientComponent";
import PatientListComponent from "./components/Patient/PatientListComponent";
import ShowRoomWardComponent from "./components/RoomWard/ShowRoomWardComponent";
import { useState } from "react";
import IPDPatientsList from "./components/IPDPatientsList/IPDPatientsList";
import Reports from "./components/Reports/Reports";

function App() {
  const [shownStaff, setshownStaff] = useState(false);
  const [shownPatient, setShownPatient] = useState(false);
  const [showWardRoom, setShowWardRoom] = useState(false);
  const [showIPDDetails, setDetails] = useState(false);
  const [showReports,setReport]=useState(false);

  const handleDetails = () => {
    setShownPatient(false);
    setshownStaff(false);
    setShowWardRoom(false);
    setDetails((c) => !c);
  };
  const handleWardRoom = () => {
    setShownPatient(false);
    setshownStaff(false);
    setDetails(false);
    setShowWardRoom((current) => !current);
  };

  const handleStaff = () => {
    setShownPatient(false);
    setShowWardRoom(false);
    setDetails(false);

    setshownStaff((current) => !current);
  };

  const handlePatient = () => {
    setshownStaff(false);
    setShowWardRoom(false);
    setDetails(false);

    setShownPatient((current) => !current);
  };

  const handleReport=()=>{
    setshownStaff(false);
    setShowWardRoom(false);
    setDetails(false);
    setShownPatient(false);
setReport(c=>!c);

  }

  return (
    <div className="container">
        <div className="row">
        
      <button  className="btn btn-success" onClick={handleStaff}>Staff</button>
    

      <button className="btn btn-success"  onClick={handlePatient}>Patient</button>


      <button className="btn btn-success"  onClick={handleWardRoom}>Ward/Room</button>
   

      <button className="btn btn-success"  onClick={handleDetails}>IPD Patient Details</button>


      <button className="btn btn-success"  onClick={handleReport}>Reports</button>

      </div>

      <div>
        {shownStaff && <StaffComponent />}

        {shownPatient && <PatientListComponent />}

        {showWardRoom && <ShowRoomWardComponent />}

        {showIPDDetails && <IPDPatientsList />}
        {showReports && <Reports/>}
      </div>
    </div>
  );
}

export default App;
