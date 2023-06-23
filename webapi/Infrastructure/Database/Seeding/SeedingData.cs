using System.Text.RegularExpressions;
using webapi.Infrastructure.Database.Models;

namespace webapi.Infrastructure.Database.Seeding
{
    public enum TrainComponentTypesEnum {
        Train = 1,
        Engine = 2,
        PassengerCar = 3,
        FreightCar = 4,
        Wheel = 5,
        Seat = 6,
        Window = 7,
        Door = 8,
        ControlPanel = 9,
        Light = 10,
        Brake = 11,
        Bolt = 12,
        Nut = 13,
        EngineHood = 14,
        Axle = 15,
        Piston = 16,
        Handrail = 17,
        Step = 18,
        Roof = 19,
        AirConditioner = 20,
        Flooring = 21,
        Mirror = 22,
        Horn = 23,
        Coupler = 24,
        Hinge = 25,
        Ladder = 26,
        Paint = 27,
        Decal = 28,
        Gauge = 29,
        Battery = 30,
        Radiator = 31,
    }
    public static class SeedingData
    {
        public static readonly TrainComponentType[] componentTypes = { };
        static SeedingData()
        {
            var tct = new List<TrainComponentType>();
            foreach (var item in Enum.GetValues(typeof(TrainComponentTypesEnum)).Cast<TrainComponentTypesEnum>())
            {
                var quantityItems = new TrainComponentTypesEnum[] {
                    TrainComponentTypesEnum.Wheel,
                    TrainComponentTypesEnum.Seat,
                    TrainComponentTypesEnum.Window,
                    TrainComponentTypesEnum.Door,
                    TrainComponentTypesEnum.ControlPanel,
                    TrainComponentTypesEnum.Light,
                    TrainComponentTypesEnum.Brake,
                    TrainComponentTypesEnum.Bolt,
                    TrainComponentTypesEnum.Nut,
                    TrainComponentTypesEnum.Handrail,
                    TrainComponentTypesEnum.Step,
                    TrainComponentTypesEnum.Mirror,
                    TrainComponentTypesEnum.Hinge,
                    TrainComponentTypesEnum.Ladder,
                    TrainComponentTypesEnum.Decal,
                    TrainComponentTypesEnum.Gauge,

                };
                var name = Regex.Replace(item.ToString(), "([A-Z])", " $1").Trim();
                tct.Add(new TrainComponentType { 
                    Id = (int)item,
                    Name = name,
                    CanAssignQuantity = quantityItems.Contains(item),
                    IsRoot = (int)item == 1
                });
                componentTypes = tct.ToArray();
            }
        }
    }
}