namespace WeatherAnalyzerServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ControllerLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeoLocation = c.String(),
                        ControllerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HeatIndexForDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        HeatIndexValueForDay = c.Double(nullable: false),
                        HeatIndexValueForNight = c.Double(nullable: false),
                        ControllerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HeatIndexForHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hour = c.String(),
                        HeatIndexValue = c.Double(nullable: false),
                        ControllerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HumidityForDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        HumidityValueForDay = c.Double(nullable: false),
                        HumidityValueForNight = c.Double(nullable: false),
                        ControllerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HumidityForHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hour = c.String(),
                        HumidityValue = c.Double(nullable: false),
                        ControllerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PressureForDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        PressureValueForDay = c.Double(nullable: false),
                        PressureValueForNight = c.Double(nullable: false),
                        ControllerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PressureForHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hour = c.String(),
                        PressureValue = c.Double(nullable: false),
                        ControllerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TemperatureForDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TemperatureValueForDay = c.Double(nullable: false),
                        TemperatureValueForNight = c.Double(nullable: false),
                        ControllerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TemperatureForHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hour = c.String(),
                        TemperatureValue = c.Double(nullable: false),
                        ControllerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TemperatureForHours");
            DropTable("dbo.TemperatureForDays");
            DropTable("dbo.PressureForHours");
            DropTable("dbo.PressureForDays");
            DropTable("dbo.HumidityForHours");
            DropTable("dbo.HumidityForDays");
            DropTable("dbo.HeatIndexForHours");
            DropTable("dbo.HeatIndexForDays");
            DropTable("dbo.ControllerLocations");
        }
    }
}
