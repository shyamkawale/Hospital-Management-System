create database HospitalManagement

use HospitalManagement

create table Doctor(
DoctorId int constraint doctor_doctorid_pk primary key,
Name varchar(20),
Email varchar(50),
MobileNo int,
Specialization varchar(20),
)



create table Wardboy(
WardboyId int constraint wardboy_wardboyid_pk primary key,
Name varchar(20),
Email varchar(50),
MobileNo int,
)

create table Nurse(
NurseId int constraint nurse_nurseid_pk primary key,
Name varchar(20),
Email varchar(50),
MobileNo int,
)
create table Bill(
BillId int constraint bill_billid_pk primary key,
OPD_Fees decimal(16,2),
Doctor_Fees decimal(16,2),
Other_Fees decimal(16,2),
Total_Fees decimal(16,2)
)
create table Room(
RoomId int constraint room_roomid_pk primary key,
Name varchar(20),
IsAvailable bit,
)

create table Patient(
PatientId int constraint patient_patientid_pk primary key,
FirstName varchar(20),
MiddleName varchar(20),
LastName varchar(20),
MobileNo int,
Email varchar(20),
Address varchar(50),
DateOfBirth datetime,
Gender varchar(10),
AgeType varchar(10),
IsAdmitted bit,
RoomId int,
BillId int,
AssignedDoctorId int,
constraint patient_billid_fk foreign key(BillId) references Bill(BillId),
constraint patient_assigneddoctorid_fk foreign key(AssignedDoctorId) references Doctor(DoctorId),
constraint patient_roomid_fk foreign key(RoomId) references Room(RoomId),
)

alter table Doctor add Fees decimal(16,2)
alter table Nurse add Fees decimal(16,2)
alter table Room add Charge decimal(16,2)

create table Ward(
WardId int constraint ward_wardid_pk primary key,
Name varchar(20),
)
alter table Room add WardId int
alter table Room add constraint room_wardId foreign key(WardId) references Ward(WardId)
alter table Wardboy add WardId int
alter table Wardboy add constraint wardboy_wardId foreign key(WardId) references Ward(WardId)

insert into Doctor values(101, 'Yash', 'yash@gmail.com', 1234, 'Heart', 500.00),
						(102, 'Nishant', 'nishant@gmail.com', 1499, 'Brain', 1000.00),
						(103, 'Siddhart', 'sidd@gmail.com', 3455, 'General', 350.00);

alter table Bill add MedicineCharges decimal(16,2)
alter table Bill add CanteenCharges decimal(16,2)

create table MedicineStore(
	MedicineId int constraint medicinedetails_medicineid_pk primary key,
	Name varchar(20),
	Price decimal(16,2),
)

create table MedicineBill(
	MedicineBillId int constraint medicinebill_medicinebillid_pk primary key,
	BillId int,
	MedicineId int,
	Quantity int,
	TotalPrice decimal(16,2),
	constraint medicinebill_billid_fk foreign key(BillId) references Bill(BillId),
	constraint medicinebill_medicineid_fk foreign key(MedicineId) references MedicineStore(MedicineId)
)


create table Canteen(
	FoodId int constraint canteen_foodid_pk primary key,
	Name varchar(20),
	Price decimal(16,2)
)

create table CanteenBill(
	CanteenBillId int constraint canteenbill_canteenbillid_pk primary key,
	BillId int,
	FoodId int,
	Quantity int,
	TotalPrice decimal(16,2),
	constraint canteenbill_billid_fk foreign key(BillId) references Bill(BillId),
	constraint canteenbill_foodid_fk foreign key(FoodId) references Canteen(FoodId)
)

alter table Doctor add Type varchar(20)

alter table Bill add RoomCharges decimal(16,2)
alter table Bill add IPD_Advance_Fees decimal(16,2)
alter table Bill add constraint total_fees_chk check(Total_Fees = OPD_Fees + Doctor_Fees + Other_Fees+ MedicineCharges+CanteenCharges+RoomCharges+IPD_Advance_Fees)

insert into Bill values (126, 1, 1, null, 5, null, null ,null, null);

select * from Doctor
select * from Wardboy
select * from Nurse
select * from Room
select * from Ward




select * from Patient
select * from MedicineStore

select * from MedicineBill


select * from Canteen
select * from Bill
select * from CanteenBill



delete from MedicineBill where MedicineBillId = 101

delete from Bill where BillId = 126

insert into Patient values(2010, 'Nitin','Aj','Kamat', 1234, 'nitin@gmail.com', 'Wardha2', '2000-01-01','male','major',0,1, 124, 1010)

Insert into Patient Values (1231, 'adsf', 'asfd','wre', 342, 'asf@afd.com', 'asdf', '09-09-2000 00:00:00', 'female', 'major', 'True', 1,124,101)
