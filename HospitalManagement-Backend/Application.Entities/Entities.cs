using Application.Entities.Base;

namespace Application.Entities
{
    public class Doctor : Entity
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MobileNo { get; set; }
        public string Specialization { get; set; }
        public decimal Fees { get; set; }
        public string Type { get; set; } //Employee or Visiting
    }
    public class Patient : Entity
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string AgeType { get; set; } //Major or Minor
        public bool IsAdmitted { get; set; }
        public int? AssignedDoctorId { get; set; } = null; //changes
        public int? BillId { get; set; } = null;
        public int? RoomId { get; set; } = null;
    }
    public class Bill: Entity
    {
        public int BillId { get; set; }
        public decimal? OPD_Fees { get; set; } = null;
        public decimal? Doctor_Fees { get; set; } = null;
        public decimal? Other_Fees { get; set; } = null;
        public decimal? MedicineCharges { get; set; } = null;
        public decimal? CanteenCharges { get; set; } = null;
        public decimal? IPD_Advance_Fees { get; set; } = null;
        public decimal? RoomCharges { get; set; } = null;
        public decimal? Total_Fees { get; set; } = null;
    }
    public class Room: Entity
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Charge { get; set; }
        public int WardId { get; set; }
    }
    public class Wardboy: Entity
    {
        public int WardboyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MobileNo { get; set; }
        public int WardId { get; set; }
    }
    public class Nurse : Entity
    {
        public int NurseId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MobileNo { get; set; }
        public decimal Fees { get; set; }
    }
    public class Ward: Entity
    {
        public int WardId { get; set; }
        public string Name { get; set; }
    }
    public class MedicineStore: Entity
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    public class Canteen: Entity
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }  
    }
    public class MedicineBill: Entity
    {
        public int MedicineBillId { get; set; }
        public int BillId { get; set; }
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
    public class CanteenBill: Entity
    {
        public int CanteenBillId { get; set; }
        public int BillId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}