// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome, Bike Manufacturing World!");

var initialInventory = new Inventory(10, 60, 60, 3, 35);
initialInventory.DisplayInfo();

IBikeBuilder bikeBuilder = new BikeBuilder();
BikeManufacturer manufacturer = new(initialInventory, bikeBuilder);

var maxBundles = manufacturer.CalculateMaxBundles();
Console.WriteLine($"Maximum number of finished bundles of bikes that can be build: {maxBundles}");
manufacturer.ConstructBike();
var bike = manufacturer.GetBike();
bike.DisplayInfo();

initialInventory.DisplayInfo();