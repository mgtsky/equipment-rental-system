using APBDlab2._1.Models;
using APBDlab2._1.Services;

class Program
{
    static void Main()
    {
        var service = new RentalService();

        var student = new Student("Jan", "Kowalski");
        var laptop = new Laptop("Dell", 16, "i7");

        service.RentEquipment(student, laptop, 1);

        try
        {
            service.RentEquipment(student, laptop, 1);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        var rental = service.GetActiveRentals(student).First();
        service.ReturnEquipment(rental);
    }
}