// Domain/Entities/Company.cs
using System;

namespace Domain.Entities
{
    public class Company
    {
        public Guid UniqueID { get; set; } = Guid.NewGuid();
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string Alias { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Pincode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PANNo { get; set; }
        public string GSTNo { get; set; }
        public string EmailID { get; set; }
        public string Website { get; set; }
        public bool IsActive { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public long? CompanyLogoId { get; set; }
        public int? CurrencyID { get; set; }
        public string CompanyCode { get; set; }
        public string StateName { get; set; }
        public string PhoneNo { get; set; }
        public Company()
        {
            CreatedDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
            IsActive = true;
            
        }
    }
}
