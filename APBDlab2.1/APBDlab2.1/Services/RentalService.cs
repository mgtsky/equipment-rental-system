using APBDlab2._1.Models;

namespace APBDlab2._1.Services;



public class RentalService
{
    private List<Rental> rentals = new List<Rental>();

    public void RentEquipment(User user, Equipment equipment, int days)
    {
        if (!equipment.IsAvailable)
            throw new Exception("Equipment not available");

        int active = rentals.Count(r => r.User == user && r.ReturnDate == null);

        if (active >= user.MaxRentals())
            throw new Exception("User exceeded limit");

        var rental = new Rental(user, equipment, days);
        rentals.Add(rental);
        equipment.IsAvailable = false;
    }

    public void ReturnEquipment(Rental rental)
    {
        rental.Return();
        Console.WriteLine($"Penalty: {rental.CalculatePenalty()}");
    }

    public List<Rental> GetActiveRentals(User user)
    {
        return rentals.Where(r => r.User == user && r.ReturnDate == null).ToList();
    }

    public List<Rental> GetOverdue()
    {
        return rentals.Where(r => r.ReturnDate == null && DateTime.Now > r.DueDate).ToList();
    }
}