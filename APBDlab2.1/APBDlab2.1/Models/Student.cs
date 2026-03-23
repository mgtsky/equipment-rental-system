namespace APBDlab2._1.Models;

public class Student : User
{
    public Student(string firstName, string lastName)
        : base(firstName, lastName) { }

    public override int MaxRentals() => 2;
}