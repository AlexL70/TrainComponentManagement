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

        public static readonly TrainComponentBrand[] brands = {
            new TrainComponentBrand { Id = 1, TypeId = (int)TCTEnum.Train, UniqueNumMask = "TR******", Name = "Train"},
            new TrainComponentBrand { Id = 2, TypeId = (int)TCTEnum.Engine, UniqueNumMask = "ENGAK******", Name = "Alan Keef"},
            new TrainComponentBrand { Id = 3, TypeId = (int)TCTEnum.Engine, UniqueNumMask = "ENGBT******", Name = "Bombardier Transportation"},
            new TrainComponentBrand { Id = 4, TypeId = (int)TCTEnum.Engine, UniqueNumMask = "ENGCEC******", Name = "Clayton Equipment Company"},
            new TrainComponentBrand { Id = 5, TypeId = (int)TCTEnum.PassengerCar, UniqueNumMask = "PCARCAF******", Name = "CAF Newport"},
            new TrainComponentBrand { Id = 6, TypeId = (int)TCTEnum.PassengerCar, UniqueNumMask = "PCARDKC******", Name = "Dick, Kerr & Co"},
            new TrainComponentBrand { Id = 7, TypeId = (int)TCTEnum.FreightCar, UniqueNumMask = "FCARDKC******", Name = "Dick, Kerr & Co"},
            new TrainComponentBrand { Id = 8, TypeId = (int)TCTEnum.FreightCar, UniqueNumMask = "FCARSW******", Name = "Swindon Works"},
            new TrainComponentBrand { Id = 9, TypeId = (int)TCTEnum.Wheel, UniqueNumMask = "WLLMTS******", Name = "Leonard Machine Tool Systems"},
            new TrainComponentBrand { Id = 10, TypeId = (int)TCTEnum.Wheel, UniqueNumMask = "WLSI******", Name = "Stucki Industrial"},
            new TrainComponentBrand { Id = 11, TypeId = (int)TCTEnum.Seat, UniqueNumMask = "SEATGRAM******", Name = "GRAMMER AG"},
            new TrainComponentBrand { Id = 12, TypeId = (int)TCTEnum.Seat, UniqueNumMask = "SEATMII******", Name = "Magna International, Inc."},
            new TrainComponentBrand { Id = 13, TypeId = (int)TCTEnum.Seat, UniqueNumMask = "SEATFSC******", Name = "Freedman Seating Company"},
            new TrainComponentBrand { Id = 14, TypeId = (int)TCTEnum.Window, UniqueNumMask = "WNDPCG******", Name = "ProCurve Glass"},
            new TrainComponentBrand { Id = 15, TypeId = (int)TCTEnum.Window, UniqueNumMask = "WNDDRL******", Name = "Dellner Romag Ltd"},
            new TrainComponentBrand { Id = 16, TypeId = (int)TCTEnum.Door, UniqueNumMask = "DOORTDS******", Name = "Train Door Solutions"},
            new TrainComponentBrand { Id = 17, TypeId = (int)TCTEnum.Door, UniqueNumMask = "DOORRT******", Name = "Railway Technology"},
            new TrainComponentBrand { Id = 18, TypeId = (int)TCTEnum.ControlPanel, UniqueNumMask = "CPLAC******", Name = "Adbro Controls"},
            new TrainComponentBrand { Id = 19, TypeId = (int)TCTEnum.ControlPanel, UniqueNumMask = "CPLSC******", Name = "Sella Controls"},
            new TrainComponentBrand { Id = 20, TypeId = (int)TCTEnum.Light, UniqueNumMask = "LGHTIL******", Name = "Imigy Led"},
            new TrainComponentBrand { Id = 21, TypeId = (int)TCTEnum.Light, UniqueNumMask = "LGHTWFL******", Name = "Wildlife Friendly Lighting"},
            new TrainComponentBrand { Id = 22, TypeId = (int)TCTEnum.Brake, UniqueNumMask = "BRKKBG******", Name = "Knorr-Bremse Group"},
            new TrainComponentBrand { Id = 23, TypeId = (int)TCTEnum.Brake, UniqueNumMask = "BRKRWB******", Name = "Railway Weelset & Break LTD"},
            new TrainComponentBrand { Id = 24, TypeId = (int)TCTEnum.Bolt, UniqueNumMask = "BLTBNM******", Name = "Bolt & Nut Manufacturing Ltd"},
            new TrainComponentBrand { Id = 25, TypeId = (int)TCTEnum.Bolt, UniqueNumMask = "BLTRCFBNC******", Name = "RCF Bolt & Nut Co."},
            new TrainComponentBrand { Id = 26, TypeId = (int)TCTEnum.Nut, UniqueNumMask = "NUTBNM******", Name = "Bolt & Nut Manufacturing Ltd"},
            new TrainComponentBrand { Id = 27, TypeId = (int)TCTEnum.Nut, UniqueNumMask = "NUTRCFBNC******", Name = "RCF Bolt & Nut Co."},
            new TrainComponentBrand { Id = 28, TypeId = (int)TCTEnum.EngineHood, UniqueNumMask = "EHDJDUK******", Name = "John Deere UK & IE"},
            new TrainComponentBrand { Id = 29, TypeId = (int)TCTEnum.EngineHood, UniqueNumMask = "EHDRTI******", Name = "Rapido Trains INC"},
            new TrainComponentBrand { Id = 30, TypeId = (int)TCTEnum.Axle, UniqueNumMask = "AXLLCI******", Name = "Lucchini UK"},
            new TrainComponentBrand { Id = 31, TypeId = (int)TCTEnum.Axle, UniqueNumMask = "AXLRWBL******", Name = "Railway Wheelset and Brake Ltd"},
            new TrainComponentBrand { Id = 32, TypeId = (int)TCTEnum.Piston, UniqueNumMask = "PSTHPR******", Name = "HP Rings"},
            new TrainComponentBrand { Id = 33, TypeId = (int)TCTEnum.Handrail, UniqueNumMask = "HRLTHP******", Name = "The Handrail People Ltd"},
            new TrainComponentBrand { Id = 34, TypeId = (int)TCTEnum.Step, UniqueNumMask = "STPLLT******", Name = "Lyte Ladders & Towers"},
            new TrainComponentBrand { Id = 35, TypeId = (int)TCTEnum.Step, UniqueNumMask = "STPRR******", Name = "Rapid Ramp"},
            new TrainComponentBrand { Id = 36, TypeId = (int)TCTEnum.Roof, UniqueNumMask = "ROOFDKC******", Name = "Dick, Kerr & Co"},
            new TrainComponentBrand { Id = 37, TypeId = (int)TCTEnum.Roof, UniqueNumMask = "ROOFSW******", Name = "Swindon Works"},
            new TrainComponentBrand { Id = 38, TypeId = (int)TCTEnum.AirConditioner, UniqueNumMask = "ACNDTRN******", Name = "Trane"},
            new TrainComponentBrand { Id = 39, TypeId = (int)TCTEnum.Flooring, UniqueNumMask = "FLRDKC******", Name = "Dick, Kerr & Co"},
            new TrainComponentBrand { Id = 40, TypeId = (int)TCTEnum.Mirror, UniqueNumMask = "MRRMFUK******", Name = "Mirrorfit UK"},
            new TrainComponentBrand { Id = 41, TypeId = (int)TCTEnum.Mirror, UniqueNumMask = "MRRMTL******", Name = "Mimtec Limited"},
            new TrainComponentBrand { Id = 42, TypeId = (int)TCTEnum.Horn, UniqueNumMask = "HRNTI******", Name = "Trent Instruments LTD"},
            new TrainComponentBrand { Id = 43, TypeId = (int)TCTEnum.Horn, UniqueNumMask = "HRNKA******", Name = "Kuda Automotive"},
            new TrainComponentBrand { Id = 44, TypeId = (int)TCTEnum.Coupler, UniqueNumMask = "CPLKB******", Name = "Knorr-Bremse"},
            new TrainComponentBrand { Id = 45, TypeId = (int)TCTEnum.Coupler, UniqueNumMask = "CPLDL******", Name = "Dellner Limited"},
            new TrainComponentBrand { Id = 46, TypeId = (int)TCTEnum.Hinge, UniqueNumMask = "HNGPKFT******", Name = "Prokraft"},
            new TrainComponentBrand { Id = 47, TypeId = (int)TCTEnum.Ladder, UniqueNumMask = "LDRCHLD******", Name = "Chase Ladders"},
            new TrainComponentBrand { Id = 48, TypeId = (int)TCTEnum.Ladder, UniqueNumMask = "LDRBRLD******", Name = "Bratts Ladders"},
            new TrainComponentBrand { Id = 49, TypeId = (int)TCTEnum.Paint, UniqueNumMask = "PNTUM******", Name = "Unitech Machinery"},
            new TrainComponentBrand { Id = 50, TypeId = (int)TCTEnum.Decal, UniqueNumMask = "DCLDT******", Name = "Decals & Transfers"},
            new TrainComponentBrand { Id = 51, TypeId = (int)TCTEnum.Gauge, UniqueNumMask = "GGTI******", Name = "Trent Instruments LTD"},
            new TrainComponentBrand { Id = 52, TypeId = (int)TCTEnum.Gauge, UniqueNumMask = "GGRWBL******", Name = "Railway Weelset & Break LTD"},
            new TrainComponentBrand { Id = 53, TypeId = (int)TCTEnum.Battery, UniqueNumMask = "BTRHR******", Name = "Hitachi Rail"},
            new TrainComponentBrand { Id = 54, TypeId = (int)TCTEnum.Battery, UniqueNumMask = "BTRALST******", Name = "Alstom"},
            new TrainComponentBrand { Id = 55, TypeId = (int)TCTEnum.Radiator, UniqueNumMask = "RDRMSN******", Name = "Myson"},
        };
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