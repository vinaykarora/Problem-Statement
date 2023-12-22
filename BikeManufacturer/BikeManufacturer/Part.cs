// See https://aka.ms/new-console-template for more information
class Seat
{
    public int Count { get; set; }
}

class Pedal
{
    public int Count { get; set; }
}

class Wheel
{
    public int Count { get; set; }
    public Frame Frame { get; set; }
    public Tube Tube { get; set; }
}

class Frame
{
    public int Count { get; set; }
}

class Tube
{
    public int Count { get; set; }
}