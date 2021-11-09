namespace ConsoleApp2
{
    public abstract class Student
    {
        public Student()
        {

        }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Major { get; set; }
        public abstract void TakeClass();
    }
}