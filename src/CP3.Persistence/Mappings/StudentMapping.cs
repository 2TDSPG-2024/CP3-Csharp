using CP3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CP3.Persistence.Mappings
{
    internal class StudentMapping : IEntityTypeConfiguration<Student>
    {    
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("CP3_TB_Alunos");

            builder.HasKey(a => a.StudentId);

            builder.Property(a => a.Name)
                .IsRequired();

            builder.Property(a => a.Email)
                .IsRequired();

            builder.HasOne(s => s.StudentClass) 
                .WithMany()                   
                .HasForeignKey(s => s.StudentClassId)  
                .OnDelete(DeleteBehavior.Cascade);  
        }
    }
}
