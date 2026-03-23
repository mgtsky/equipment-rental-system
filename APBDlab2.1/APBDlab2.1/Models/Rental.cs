namespace APBDlab2._1.Models;

public class Rental
{
    public User User { get; }
    public Equipment Equipment { get; }
    public DateTime RentDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }

    public Rental(User user, Equipment equipment, int days)
    {
        User = user;
        Equipment = equipment;
        RentDate = DateTime.Now;
        DueDate = RentDate.AddDays(days);
    }

    public void Return()
    {
        ReturnDate = DateTime.Now;
        Equipment.IsAvailable = true;
    }

    public bool IsLate()
    {
        return ReturnDate.HasValue && ReturnDate > DueDate;
    }

    public double CalculatePenalty()
    {
        if (!IsLate()) return 0;
        int daysLate = (ReturnDate.Value - DueDate).Days;
        return daysLate * 5;
    }
}