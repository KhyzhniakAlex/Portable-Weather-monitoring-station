using System;
using System.Collections.Generic;
using System.Data.Entity;
using WeatherAnalyzerServer.Models;
using System.Linq;
using System.Web;

namespace WeatherAnalyzerServer.Services
{
    public class DBInitializer : DropCreateDatabaseAlways<WeatherContext>
    {
        protected override void Seed(WeatherContext context)
        {
            Guid ControllerId = new Guid();

            context.ControllerLocation.Add(new ControllerLocation { ControllerId = ControllerId, GeoLocation = "50.351848, 30.477985" });

            // Temperature mocked data for 10 days and 24 hours
            context.TemperatureForDays.Add(new TemperatureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 4, 30), TemperatureValueForDay = 22, TemperatureValueForNight = 16 });
            context.TemperatureForDays.Add(new TemperatureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 1), TemperatureValueForDay = 18, TemperatureValueForNight = 16 });
            context.TemperatureForDays.Add(new TemperatureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 2), TemperatureValueForDay = 16, TemperatureValueForNight = 13 });
            context.TemperatureForDays.Add(new TemperatureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 3), TemperatureValueForDay = 13, TemperatureValueForNight = 11 });
            context.TemperatureForDays.Add(new TemperatureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 4), TemperatureValueForDay = 15, TemperatureValueForNight = 10 });
            context.TemperatureForDays.Add(new TemperatureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 5), TemperatureValueForDay = 16, TemperatureValueForNight = 11 });
            context.TemperatureForDays.Add(new TemperatureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 6), TemperatureValueForDay = 17, TemperatureValueForNight = 12 });
            context.TemperatureForDays.Add(new TemperatureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 7), TemperatureValueForDay = 19, TemperatureValueForNight = 15 });
            context.TemperatureForDays.Add(new TemperatureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 8), TemperatureValueForDay = 20, TemperatureValueForNight = 16 });
            context.TemperatureForDays.Add(new TemperatureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 9), TemperatureValueForDay = 20, TemperatureValueForNight = 13 });

            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "0:00", TemperatureValue = 10 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "1:00", TemperatureValue = 10 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "2:00", TemperatureValue = 10 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "3:00", TemperatureValue = 9 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "4:00", TemperatureValue = 9 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "5:00", TemperatureValue = 8 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "6:00", TemperatureValue = 8 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "7:00", TemperatureValue = 8 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "8:00", TemperatureValue = 9 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "9:00", TemperatureValue = 11 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "10:00", TemperatureValue = 11 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "11:00", TemperatureValue = 12 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "12:00", TemperatureValue = 14 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "13:00", TemperatureValue = 15 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "14:00", TemperatureValue = 15 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "15:00", TemperatureValue = 15 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "16:00", TemperatureValue = 16 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "17:00", TemperatureValue = 17 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "18:00", TemperatureValue = 17 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "19:00", TemperatureValue = 16 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "20:00", TemperatureValue = 14 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "21:00", TemperatureValue = 14 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "22:00", TemperatureValue = 13 });
            context.TemperatureForHours.Add(new TemperatureForHours { ControllerId = ControllerId, Hour = "23:00", TemperatureValue = 12 });




            // Humidity mocked data for 10 days and 24 hours
            context.HumidityForDays.Add(new HumidityForDays { ControllerId = ControllerId, Date = new DateTime(2020, 4, 30), HumidityValueForDay = 50, HumidityValueForNight = 94 });
            context.HumidityForDays.Add(new HumidityForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 1), HumidityValueForDay = 52, HumidityValueForNight = 97 });
            context.HumidityForDays.Add(new HumidityForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 2), HumidityValueForDay = 54, HumidityValueForNight = 60 });
            context.HumidityForDays.Add(new HumidityForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 3), HumidityValueForDay = 58, HumidityValueForNight = 53 });
            context.HumidityForDays.Add(new HumidityForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 4), HumidityValueForDay = 53, HumidityValueForNight = 48 });
            context.HumidityForDays.Add(new HumidityForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 5), HumidityValueForDay = 53, HumidityValueForNight = 91 });
            context.HumidityForDays.Add(new HumidityForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 6), HumidityValueForDay = 66, HumidityValueForNight = 66 });
            context.HumidityForDays.Add(new HumidityForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 7), HumidityValueForDay = 70, HumidityValueForNight = 78 });
            context.HumidityForDays.Add(new HumidityForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 8), HumidityValueForDay = 55, HumidityValueForNight = 60 });
            context.HumidityForDays.Add(new HumidityForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 9), HumidityValueForDay = 49, HumidityValueForNight = 51 });

            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "0:00", HumidityValue = 47 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "1:00", HumidityValue = 47 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "2:00", HumidityValue = 49 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "3:00", HumidityValue = 50 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "4:00", HumidityValue = 55 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "5:00", HumidityValue = 58 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "6:00", HumidityValue = 63 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "7:00", HumidityValue = 69 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "8:00", HumidityValue = 67 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "9:00", HumidityValue = 67 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "10:00", HumidityValue = 67 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "11:00", HumidityValue = 61 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "12:00", HumidityValue = 61 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "13:00", HumidityValue = 66 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "14:00", HumidityValue = 68 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "15:00", HumidityValue = 80 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "16:00", HumidityValue = 100 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "17:00", HumidityValue = 100 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "18:00", HumidityValue = 91 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "19:00", HumidityValue = 74 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "20:00", HumidityValue = 74 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "21:00", HumidityValue = 70 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "22:00", HumidityValue = 59 });
            context.HumidityForHours.Add(new HumidityForHours { ControllerId = ControllerId, Hour = "23:00", HumidityValue = 57 });





            // Pressure mocked data for 10 days and 24 hours
            context.PressureForDays.Add(new PressureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 4, 30), PressureValueForDay = 755, PressureValueForNight = 750 });
            context.PressureForDays.Add(new PressureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 1), PressureValueForDay = 755, PressureValueForNight = 750 });
            context.PressureForDays.Add(new PressureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 2), PressureValueForDay = 759, PressureValueForNight = 750 });
            context.PressureForDays.Add(new PressureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 3), PressureValueForDay = 769, PressureValueForNight = 754 });
            context.PressureForDays.Add(new PressureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 4), PressureValueForDay = 763, PressureValueForNight = 756 });
            context.PressureForDays.Add(new PressureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 5), PressureValueForDay = 762, PressureValueForNight = 753 });
            context.PressureForDays.Add(new PressureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 6), PressureValueForDay = 763, PressureValueForNight = 760 });
            context.PressureForDays.Add(new PressureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 7), PressureValueForDay = 751, PressureValueForNight = 743 });
            context.PressureForDays.Add(new PressureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 8), PressureValueForDay = 750, PressureValueForNight = 740 });
            context.PressureForDays.Add(new PressureForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 9), PressureValueForDay = 743, PressureValueForNight = 739 });

            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "0:00", PressureValue = 760 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "1:00", PressureValue = 760 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "2:00", PressureValue = 760 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "3:00", PressureValue = 757 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "4:00", PressureValue = 755 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "5:00", PressureValue = 752 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "6:00", PressureValue = 749 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "7:00", PressureValue = 750 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "8:00", PressureValue = 751 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "9:00", PressureValue = 752 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "10:00", PressureValue = 754 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "11:00", PressureValue = 753 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "12:00", PressureValue = 758 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "13:00", PressureValue = 760 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "14:00", PressureValue = 754 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "15:00", PressureValue = 757 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "16:00", PressureValue = 749 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "17:00", PressureValue = 748 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "18:00", PressureValue = 752 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "19:00", PressureValue = 751 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "20:00", PressureValue = 756 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "21:00", PressureValue = 755 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "22:00", PressureValue = 755 });
            context.PressureForHours.Add(new PressureForHours { ControllerId = ControllerId, Hour = "23:00", PressureValue = 755 });




            // Heat Index mocked data for 10 days and 24 hours
            context.HeatIndexForDays.Add(new HeatIndexForDays { ControllerId = ControllerId, Date = new DateTime(2020, 4, 30), HeatIndexValueForDay = 30, HeatIndexValueForNight = 28 });
            context.HeatIndexForDays.Add(new HeatIndexForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 1), HeatIndexValueForDay = 31, HeatIndexValueForNight = 28 });
            context.HeatIndexForDays.Add(new HeatIndexForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 2), HeatIndexValueForDay = 29, HeatIndexValueForNight = 28 });
            context.HeatIndexForDays.Add(new HeatIndexForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 3), HeatIndexValueForDay = 27, HeatIndexValueForNight = 23 });
            context.HeatIndexForDays.Add(new HeatIndexForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 4), HeatIndexValueForDay = 36, HeatIndexValueForNight = 29 });
            context.HeatIndexForDays.Add(new HeatIndexForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 5), HeatIndexValueForDay = 35, HeatIndexValueForNight = 30 });
            context.HeatIndexForDays.Add(new HeatIndexForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 6), HeatIndexValueForDay = 38, HeatIndexValueForNight = 30 });
            context.HeatIndexForDays.Add(new HeatIndexForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 7), HeatIndexValueForDay = 40, HeatIndexValueForNight = 37 });
            context.HeatIndexForDays.Add(new HeatIndexForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 8), HeatIndexValueForDay = 42, HeatIndexValueForNight = 33 });
            context.HeatIndexForDays.Add(new HeatIndexForDays { ControllerId = ControllerId, Date = new DateTime(2020, 5, 9), HeatIndexValueForDay = 41, HeatIndexValueForNight = 36 });

            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "0:00", HeatIndexValue = 30 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "1:00", HeatIndexValue = 28 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "2:00", HeatIndexValue = 34 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "3:00", HeatIndexValue = 34 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "4:00", HeatIndexValue = 31 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "5:00", HeatIndexValue = 32 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "6:00", HeatIndexValue = 32 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "7:00", HeatIndexValue = 35 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "8:00", HeatIndexValue = 31 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "9:00", HeatIndexValue = 29 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "10:00", HeatIndexValue = 28 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "11:00", HeatIndexValue = 35 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "12:00", HeatIndexValue = 33 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "13:00", HeatIndexValue = 29 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "14:00", HeatIndexValue = 31 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "15:00", HeatIndexValue = 26 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "16:00", HeatIndexValue = 30 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "17:00", HeatIndexValue = 34 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "18:00", HeatIndexValue = 31 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "19:00", HeatIndexValue = 31 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "20:00", HeatIndexValue = 31 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "21:00", HeatIndexValue = 27 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "22:00", HeatIndexValue = 26 });
            context.HeatIndexForHours.Add(new HeatIndexForHours { ControllerId = ControllerId, Hour = "23:00", HeatIndexValue = 29 });



            context.SaveChanges();
        }
    }
}