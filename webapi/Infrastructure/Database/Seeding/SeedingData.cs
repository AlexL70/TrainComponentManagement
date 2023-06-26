using System.Text.RegularExpressions;
using webapi.Infrastructure.Database.Models;

namespace webapi.Infrastructure.Database.Seeding
{
    public enum TCTEnum {
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
        public static readonly (TCTEnum parent, TCTEnum child)[] tctRelations =
            new (TCTEnum parent, TCTEnum child)[] {

            (parent: TCTEnum.Train, child: TCTEnum.Engine),
            (parent: TCTEnum.Train, child: TCTEnum.PassengerCar),
            (parent: TCTEnum.Train, child: TCTEnum.FreightCar),
            (parent: TCTEnum.Engine, child: TCTEnum.Gauge),
            (parent: TCTEnum.PassengerCar, child: TCTEnum.Gauge),
            (parent: TCTEnum.FreightCar, child: TCTEnum.Gauge),
            (parent: TCTEnum.Gauge, child: TCTEnum.Axle),
            (parent: TCTEnum.Gauge, child: TCTEnum.Wheel),
            (parent: TCTEnum.Engine, child: TCTEnum.Seat),
            (parent: TCTEnum.FreightCar, child: TCTEnum.Seat),
            (parent: TCTEnum.Engine, child: TCTEnum.Window),
            (parent: TCTEnum.PassengerCar, child: TCTEnum.Window),
            (parent: TCTEnum.Engine, child: TCTEnum.Door),
            (parent: TCTEnum.PassengerCar, child: TCTEnum.Door),
            (parent: TCTEnum.FreightCar, child: TCTEnum.Door),
            (parent: TCTEnum.Engine, child: TCTEnum.ControlPanel),
            (parent: TCTEnum.Engine, child: TCTEnum.Light),
            (parent: TCTEnum.Engine, child: TCTEnum.Brake),
            (parent: TCTEnum.PassengerCar, child: TCTEnum.Brake),
            (parent: TCTEnum.FreightCar, child: TCTEnum.Brake),
            (parent: TCTEnum.Wheel, child: TCTEnum.Bolt),
            (parent: TCTEnum.Wheel, child: TCTEnum.Nut),
            (parent: TCTEnum.Engine, child: TCTEnum.EngineHood),
            (parent: TCTEnum.Engine, child: TCTEnum.Piston),
            (parent: TCTEnum.Engine, child: TCTEnum.Handrail),
            (parent: TCTEnum.PassengerCar, child: TCTEnum.Handrail),
            (parent: TCTEnum.FreightCar, child: TCTEnum.Handrail),
            (parent: TCTEnum.Engine, child: TCTEnum.Step),
            (parent: TCTEnum.PassengerCar, child: TCTEnum.Step),
            (parent: TCTEnum.Engine, child: TCTEnum.Roof),
            (parent: TCTEnum.PassengerCar, child: TCTEnum.Roof),
            (parent: TCTEnum.FreightCar, child: TCTEnum.Roof),
            (parent: TCTEnum.Engine, child: TCTEnum.AirConditioner),
            (parent: TCTEnum.PassengerCar, child: TCTEnum.AirConditioner),
            (parent: TCTEnum.Engine, child: TCTEnum.Flooring),
            (parent: TCTEnum.PassengerCar, child: TCTEnum.Flooring),
            (parent: TCTEnum.Engine, child: TCTEnum.Mirror),
            (parent: TCTEnum.Engine, child: TCTEnum.Horn),
            (parent: TCTEnum.Engine, child: TCTEnum.Coupler),
            (parent: TCTEnum.PassengerCar, child: TCTEnum.Coupler),
            (parent: TCTEnum.FreightCar, child: TCTEnum.Coupler),
            (parent: TCTEnum.Door, child: TCTEnum.Hinge),
            (parent: TCTEnum.Window, child: TCTEnum.Hinge),
            (parent: TCTEnum.Coupler, child: TCTEnum.Hinge),
            (parent: TCTEnum.Engine, child: TCTEnum.Ladder),
            (parent: TCTEnum.PassengerCar, child: TCTEnum.Ladder),
            (parent: TCTEnum.FreightCar, child: TCTEnum.Ladder),
            (parent: TCTEnum.Roof, child: TCTEnum.Paint),
            (parent: TCTEnum.Flooring, child: TCTEnum.Paint),
            (parent: TCTEnum.Door, child: TCTEnum.Paint),
            (parent: TCTEnum.Window, child: TCTEnum.Paint),
            (parent: TCTEnum.Engine, child: TCTEnum.Decal),
            (parent: TCTEnum.PassengerCar, child: TCTEnum.Decal),
            (parent: TCTEnum.FreightCar, child: TCTEnum.Decal),
            (parent: TCTEnum.Engine, child: TCTEnum.Battery),
            (parent: TCTEnum.Engine, child: TCTEnum.Radiator),
        };
        public static readonly TrainComponentType[] componentTypes = { };
        public static readonly TrainComponentTypeRelation[] relations = { };
        static SeedingData()
        {
            var tct = new List<TrainComponentType>();
            foreach (var item in Enum.GetValues(typeof(TCTEnum)).Cast<TCTEnum>())
            {
                var quantityItems = new TCTEnum[] {
                    TCTEnum.Wheel,
                    TCTEnum.Seat,
                    TCTEnum.Window,
                    TCTEnum.Door,
                    TCTEnum.ControlPanel,
                    TCTEnum.Light,
                    TCTEnum.Brake,
                    TCTEnum.Bolt,
                    TCTEnum.Nut,
                    TCTEnum.Handrail,
                    TCTEnum.Step,
                    TCTEnum.Mirror,
                    TCTEnum.Hinge,
                    TCTEnum.Ladder,
                    TCTEnum.Decal,
                    TCTEnum.Gauge,

                };
                var name = Regex.Replace(item.ToString(), "([A-Z])", " $1").Trim();
                // Fill in train component types
                tct.Add(new TrainComponentType { 
                    Id = (int)item,
                    Name = name,
                    CanAssignQuantity = quantityItems.Contains(item),
                    IsRoot = (int)item == 1
                });
                // Fill in possible parent/child relations between component types
                var relList = new List<TrainComponentTypeRelation>();
                componentTypes = tct.ToArray();
                foreach (var rel in tctRelations)
                {
                    relList.Add(new TrainComponentTypeRelation {
                        ParentTypeId = (int)rel.parent,
                        ChildTypeId = (int)rel.child,
                    });
                }
                relations = relList.ToArray();
            }
        }
    }
}