// See https://aka.ms/new-console-template for more information

interface IBike
{
    string Color { get; set; }
    bool GearSystem { get; set; }
    string Model { get; set; }
    Pedal Pedals { get; set; }
    Seat Seat { get; set; }
    string Suspension { get; set; }
    Wheel Wheel { get; set; }
    void DisplayInfo();
}

class Bike : IBike
{
    public string Model { get; set; } = "2023";
    public string Color { get; set; } = "White";
    public bool GearSystem { get; set; } = true;
    public string Suspension { get; set; } = "Hydrolic";
    public Seat Seat { get; set; }
    public Pedal Pedals { get; set; }
    public Wheel Wheel { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine("Here is the bike details:");
        Console.WriteLine();
        Console.WriteLine($"Bike: {Color} {Model}");
        Console.WriteLine($"Gear System: {(GearSystem ? "Included" : "Not Included")}");
        Console.WriteLine($"Suspension: {Suspension}");
        Console.WriteLine($"Seats: {Seat.Count}, Pedals: {Pedals.Count}, Wheels: {Wheel.Count}");
        Console.WriteLine();
    }
}
