namespace MedicalRecordManagement.Models.Domain
{
    public class BaseModel
    {
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeletionDate { get; set; }

    }
}
