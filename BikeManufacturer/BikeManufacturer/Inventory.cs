// See https://aka.ms/new-console-template for more information
class Inventory
{
    public int Seats { get; private set; }
    public int Pedals { get; private set; }
    public int Wheels { get; private set; }
    public int Frames { get; private set; }
    public int Tubes { get; private set; }

    public Inventory(int seats, int pedals, int wheels, int frames, int tubes)
    {
        Seats = seats;
        Pedals = pedals;
        Wheels = wheels;
        Frames = frames;
        Tubes = tubes;
    }

    public Inventory(Inventory inventory)
    {
        Seats = inventory.Seats;
        Pedals = inventory.Pedals;
        Wheels = inventory.Wheels;
        Frames = inventory.Frames;
        Tubes = inventory.Tubes;
    }

    internal Inventory ReduceSeats(int count)
    {
        Seats -= count;
        return this;
    }
    internal Inventory ReduceWheels(int count)
    {
        Wheels -= count;
        Frames -= count;
        Tubes -= count;
        return this;
    }

    internal Inventory ReducePedals(int count)
    {
        Pedals -= count;
        return this;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Currently inventory at store.");
        Console.WriteLine();

        Console.WriteLine($"Seats: {Seats}");
        Console.WriteLine($"Pedals: {Pedals}");
        Console.WriteLine($"Wheels: {Wheels}, Frames: {Frames}, Tubes: {Tubes}");

        Console.WriteLine();
    }
}