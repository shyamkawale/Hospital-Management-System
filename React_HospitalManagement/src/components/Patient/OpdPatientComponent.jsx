import { useState, useEffect } from "react";
import ModalComponent from "./ModalComponent";

const OpdPatientComponent = () => {
  const [data, setData] = useState({
    PatientId: 0,
    FirstName: "",
    LastName: "",
    MiddleName: "",
    Email: "",
    MobileNo: 0,
    Address: "",
    isAdmitted: false,
    AgeType: null,
    DateOfBirth: 0,
    Gender: "",
    RoomId: null,
    BillId: parseInt(Math.random() * 1000 + 1),
    AssignedDoctorId: null,
  });
  const [Admitted, setisAdmitted] = useState(false);
  const [modal, setModal] = useState(false);
  const [roomList, SetroomList] = useState([]);
  const [doctorList, SetdoctorList] = useState([]);

  const handleAdmit = (e) => {
    e.preventDefault();

    setData({ ...data, isAdmitted: !Admitted });
    if (!Admitted) {
      e.target.style.backgroundColor = "green";
    } else {
      e.target.style.backgroundColor = "#240370";
    }
    setisAdmitted((current) => !current);
  };

  async function handleAPIPatient() {
    const response2 = await fetch(process.env.REACT_APP_API + "/Patient", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(data),
    });
  }
  async function getRooms() {
    const response = await fetch(process.env.REACT_APP_API + "/Room");
    const data = await response.json();
    SetroomList(data);
  }
  async function getDoctors() {
    const response = await fetch(process.env.REACT_APP_API + "/Doctor");
    const data = await response.json();
    SetdoctorList(data);
  }

  useEffect(() => {
    getRooms();
    getDoctors();
  }, []);

  async function handleAddOPD(event) {
    event.preventDefault();
    // let uniqueValue=new Date().valueOf();
    // setData({...data,BillId:uniqueValue})
    setTimeout(console.log(data), 5000);
    setModal(true);
    const response1 = await fetch(process.env.REACT_APP_API + "/Bill", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        BillId: data.BillId,
        OPD_Fees: 0,
        Doctor_Fees: 0,
        Other_Fees: 0,
        Medicine_Fees: 0,
        IPD_Advance_Fees: 0,
        Total_Fees: 0,
        CanteenCharges: 0,
        RoomCharges: 0,
      }),
    });
    handleAPIPatient();
  }

  async function handleAddIPD(event) {
    event.preventDefault();
    // let uniqueValue=new Date().valueOf();
    // setData({...data,BillId:uniqueValue})
    setTimeout(console.log(data), 5000);
    setModal(true);
    const response1 = await fetch(process.env.REACT_APP_API + "/Bill", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        BillId: data.BillId,
        OPD_Fees: 0,
        Doctor_Fees: 500,
        Other_Fees: 0,
        Medicine_Fees: 0,
        IPD_Advance_Fees: 200,
        Total_Fees: 0,
        CanteenCharges: 0,
        RoomCharges: 0,
      }),
    });

    handleAPIPatient();
    // console.log(response);
    // props.handleNewDoc();
  }

  const handleCalculate = (e) => {
    e.preventDefault();
    console.log(data);
  };

  const handleIPD = (e) => {
    e.preventDefault();

    console.log(data);
  };
  return (
    <div>
      {modal && (
        <ModalComponent
          setModal={setModal}
          BillId={data.BillId}
          DoctorId={data.DoctorId}
          RoomId={data.RoomId}
          IPD={data.isAdmitted}
        />
      )}

      <form>
        <div className="control-group">
          <div className="form-control">
            <label htmlFor="name">Patient Id</label>
            <input
              type="number"
              id="PatientId"
              value={data.PatientId}
              onChange={(e) =>
                setData({ ...data, PatientId: parseInt(e.target.value) })
              }
            />
          </div>
          <div className="form-control">
            <label htmlFor="name">First Name</label>
            <input
              type="text"
              id="firstname"
              value={data.FirstName}
              onChange={(e) => setData({ ...data, FirstName: e.target.value })}
            />
          </div>
          <div className="form-control">
            <label htmlFor="name">Middle Name</label>
            <input
              type="text"
              id="middlename"
              value={data.MiddleName}
              onChange={(e) => setData({ ...data, MiddleName: e.target.value })}
            />
          </div>
          <div className="form-control">
            <label htmlFor="name">Last Name</label>
            <input
              type="text"
              id="lastname"
              value={data.LastName}
              onChange={(e) => setData({ ...data, LastName: e.target.value })}
            />
          </div>
        </div>
        <div className="form-control">
          <label htmlFor="name">E-Mail Address</label>
          <input
            type="text"
            id="mail"
            value={data.Email}
            onChange={(e) => setData({ ...data, Email: e.target.value })}
          />
        </div>
        <div className="form-control">
          <label htmlFor="name">Mobile Number</label>
          <input
            type="number"
            id="mobile"
            value={data.MobileNo}
            onChange={(e) =>
              setData({ ...data, MobileNo: parseInt(e.target.value) })
            }
          />
        </div>
        <div className="form-control">
          <label htmlFor="name">Address</label>
          <input
            type="text"
            id="address"
            value={data.Address}
            onChange={(e) => setData({ ...data, Address: e.target.value })}
          />
        </div>
        <div className="form-control">
          <label htmlFor="name">DOB</label>
          <input
            type="text"
            id="dob"
            value={data.DateOfBirth}
            onChange={(e) => setData({ ...data, DateOfBirth: e.target.value })}
          />
        </div>
        <div className="form-control">
          <label htmlFor="name">Gender</label>
          <input
            type="text"
            id="gender"
            value={data.Gender}
            onChange={(e) => setData({ ...data, Gender: e.target.value })}
          />
        </div>
        {/* <div className='form-control'>
            <label htmlFor='name'>Age Type</label>
            <input type='text' id='age' value={data.AgeType} onChange={(e)=>setData({...data,AgeType:e.target.value})}/>
          </div> */}
        <div>
          <div>
            <label>Age Type: </label>
            <select
              onChange={(e) => setData({ ...data, AgeType: e.target.value })}
            >
              <option value="Major">Major</option>
              <option value="Minor">Minor</option>
              {/* <option value="103">103</option>
            <option value="111">111</option>
            <option value="1022">1022</option> */}
            </select>
          </div>

          <button onClick={(e) => handleAdmit(e)}>Admit To IPD</button>
        </div>
        <div>
          {Admitted ? (
            <div>
              {/* <div className='form-control'>
         <label htmlFor='name'>Room Id</label>
         <input type='text' id='roomid' value={data.RoomId} onChange={(e)=>setData({...data,RoomId:e.target.value})}/>
       </div> */}
              {/* <div className='form-control'>
         <label htmlFor='name'>Bill Id</label>
         <input type='text' id='billid' value={data.BillId} onChange={(e)=>setData({...data,BillId:e.target.value})}/>
       </div> */}
              {/* <div className='form-control'>
         <label htmlFor='name'>Doctor Assigned</label>
         <input type='text' id='doctorAssigned' value={data.AssignedDoctor} onChange={(e)=>setData({...data,AssignedDoctor:e.target.value})}/>
       </div> */}
              <div>
                <label>Room Id: </label>
                <select
                  onChange={(e) =>
                    setData({ ...data, RoomId: parseInt(e.target.value) })
                  }
                >
                  {roomList.map((e, idx) => {
                    // console.log(e);
                    return (
                      <option key={idx} value={e.RoomId}>
                        {e.Name}
                      </option>
                    );
                  })}
                  {/* <option value="111">111</option>
            <option value="1022">1022</option> */}
                </select>
              </div>
              <div>
                <label>Doctor Assigned: </label>
                <select
                  onChange={(e) =>
                    setData({
                      ...data,
                      AssignedDoctorId: parseInt(e.target.value),
                    })
                  }
                >
                  {doctorList.map((e, idx) => {
                    // console.log(e);
                    return (
                      <option key={idx} value={e.DoctorId}>
                        {e.Name}
                      </option>
                    );
                  })}
                </select>
              </div>

              <button onClick={(e) => handleAddIPD(e)}>Add IPD Patient</button>
            </div>
          ) : (
            <button onClick={(e) => handleAddOPD(e)}>Add OPD Patient</button>
          )}
        </div>
      </form>
    </div>
  );
};

export default OpdPatientComponent;
