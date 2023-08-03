using MedicalRecordManagement.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MedicalRecordManagement.Data
{
    public class MedicalRecordMabagementDbContext : DbContext
    {
        public MedicalRecordMabagementDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        { 
        }

        public  DbSet<User> Users { get; set; }
        public  DbSet<MedicalRecord> MedicalRecords { get; set; }
    }
}
