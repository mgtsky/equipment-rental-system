namespace APBDlab2._1.Models;

public class Laptop : Equipment
{
    public int Ram { get; set; }
    public string Processor { get; set; }

    public Laptop(string name, int ram, string processor)
        : base(name)
    {
        Ram = ram;
        Processor = processor;
    }
}