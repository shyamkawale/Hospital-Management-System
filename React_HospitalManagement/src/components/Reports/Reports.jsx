import React, { useState, useEffect } from "react";
import DoctorBySpecComp from "./DoctorBySpecComp";
import DoctorByTypeComp from "./DoctorByTypeComp";
import PatientByDoctorComp from "./PatientByDoctorComp";
import PatientByWardComp from "./PatientByWardComp";

const Reports = () => {
  const [isDoctorBySpecReport, SetisDoctorBySpecReport] = useState(false);
  const seeDoctorBySpec = () => {
    SetisDoctorBySpecReport(true);
    SetisDoctorByTypeReport(false);
    SetisPatientByDoctorReport(false);
    SetisPatientByWardReport(false);
  };
  const [isDoctorByTypeReport, SetisDoctorByTypeReport] = useState(false);
  const seeDoctorByType = () => {
    SetisDoctorByTypeReport(true);
    SetisDoctorBySpecReport(false);
    SetisPatientByDoctorReport(false);
    SetisPatientByWardReport(false);
  };
  const [isPatientByDoctorReport, SetisPatientByDoctorReport] = useState(false);
  const seePatientByDoctor = () => {
    SetisPatientByDoctorReport(true);
    SetisDoctorByTypeReport(false);
    SetisDoctorBySpecReport(false);
    SetisPatientByWardReport(false);
  };
  const [isPatientByWardReport, SetisPatientByWardReport] = useState(false);
  const seePatientByWard = () => {
    SetisPatientByWardReport(true);
    SetisPatientByDoctorReport(false);
    SetisDoctorByTypeReport(false);
    SetisDoctorBySpecReport(false);
  };
  return (
    <>
      <button onClick={seeDoctorBySpec}>
        List Doctor based on specialisation
      </button>
      <button onClick={seeDoctorByType}>List Doctor based on Type</button>
      <button onClick={seePatientByDoctor}>List Patient based on Doctor</button>
      <button onClick={seePatientByWard}>List Patient based on Ward</button>
      {isDoctorByTypeReport === true && <DoctorByTypeComp />}
      {isDoctorBySpecReport === true && <DoctorBySpecComp />}
      {isPatientByDoctorReport === true && <PatientByDoctorComp />}
      {isPatientByWardReport === true && <PatientByWardComp />}
    </>
  );
};

export default Reports;
