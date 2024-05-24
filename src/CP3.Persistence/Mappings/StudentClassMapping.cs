using CP3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CP3.Persistence.Mappings
{
    internal class StudentClassMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("CP3_TB_Turmas");

            builder.HasKey(a => a.StudentClassId);

            builder.Property(a => a.Name)
                .IsRequired();
        }
    }
}
