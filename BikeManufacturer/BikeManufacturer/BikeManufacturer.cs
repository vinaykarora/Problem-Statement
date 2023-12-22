// See https://aka.ms/new-console-template for more information
class BikeManufacturer
{
    private readonly Inventory _inventory;
    private readonly IBikeBuilder _builder;
    private readonly int Seats = 1;
    private readonly int Pedals = 2;
    private readonly int Wheels = 2;
    private readonly int Frames = 2;
    private readonly int Tubes = 2;

    public BikeManufacturer(Inventory inventory, IBikeBuilder builder)
    {
        _inventory = inventory;
        _builder = builder;
    }

    public IBike GetBike()
    {
        return _builder.Build();
    }

    public void ConstructBike()
    {
        if (!CanAssembleBike(_inventory))
        {
            Console.WriteLine("Insufficient inventory to assemble a bike.");
            return;
        }

        _builder
            .WithModel("Mountain Bike")
            .WithColor("Red")
            .WithGearSystem(true)
            .WithSuspension("Best Mountain Bike suspension")
            .WithSeat()
            .WithPedal()
            .WithWheels();
        ReduceTheInventory(_inventory);
        return;
    }

    public int CalculateMaxBundles()
    {
        if (!CanAssembleBike(_inventory))
        {
            Console.WriteLine("Insufficient inventory to assemble a bike.");
            return 0;
        }

        var inventory = new Inventory(_inventory);
        return CalculateMaxBundles(inventory);
    }

    private int CalculateMaxBundles(Inventory inventory)
    {
        int assembledBikes = 0;
        while (CanAssembleBike(inventory))
        {
            assembledBikes++;
            ReduceTheInventory(inventory);
        }

        return assembledBikes;
    }

    private void ReduceTheInventory(Inventory inventory)
    {
        // Reduce the inventory count after assembling a bike
        inventory
            .ReduceSeats(Seats)
            .ReducePedals(Pedals)
            .ReduceWheels(Wheels);
    }

    private bool CanAssembleBike(Inventory inventory)
    {
        return inventory.Seats >= Seats
            && inventory.Pedals >= Pedals
            && inventory.Wheels >= Wheels
            && inventory.Frames >= Frames
            && inventory.Tubes >= Tubes;
    }
}