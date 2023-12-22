internal interface IBikeBuilder
{
    BikeBuilder WithPedal();
    BikeBuilder WithSeat();
    BikeBuilder WithWheels();
    IBike Build();
    BikeBuilder WithColor(string color);
    BikeBuilder WithGearSystem(bool hasGears);
    BikeBuilder WithModel(string model);
    BikeBuilder WithSuspension(string suspensionType);
}

class BikeBuilder : IBikeBuilder
{
    private readonly Bike _bike;
    private readonly int Seats = 1;
    private readonly int Pedals = 2;
    private readonly int Wheels = 2;
    private readonly int Frames = 2;
    private readonly int Tubes = 2;

    public BikeBuilder()
    {
        _bike = new Bike();
    }

    public BikeBuilder WithModel(string model)
    {
        _bike.Model = model;
        return this;
    }

    public BikeBuilder WithColor(string color)
    {
        _bike.Color = color;
        return this;
    }

    public BikeBuilder WithGearSystem(bool hasGears)
    {
        _bike.GearSystem = hasGears;
        return this;
    }

    public BikeBuilder WithSuspension(string suspensionType)
    {
        _bike.Suspension = suspensionType;
        return this;
    }

    public BikeBuilder WithSeat()
    {
        _bike.Seat = new Seat { Count = Seats };
        return this;
    }

    public BikeBuilder WithWheels()
    {
        _bike.Wheel = new Wheel
        {
            Count = Wheels,
            Frame = new Frame { Count = Frames },
            Tube = new Tube { Count = Tubes }
        };
        return this;
    }

    public BikeBuilder WithPedal()
    {
        _bike.Pedals = new Pedal { Count = Pedals };
        return this;
    }

    public IBike Build()
    {
        if (_bike.Pedals == null)
        {
            throw new InvalidOperationException("Pedal must be set before building Bike.");
        }

        if (_bike.Wheel == null)
        {
            throw new InvalidOperationException("Wheel must be set before building Bike.");
        }

        if (_bike.Seat == null)
        {
            throw new InvalidOperationException("Seat must be set before building Bike.");
        }

        return _bike;
    }
}