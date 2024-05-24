namespace CP3.Models
{
    public class Student : Audit
    {
        public int StudentId { get; init; }

        public string Name { get; } = string.Empty;

        public string Email { get; init; } = string.Empty;

        public int Identification { get; init; }

        public int StudentClassId { get; init; }

        public StudentClass StudentClass { get; init; }
    }
}
