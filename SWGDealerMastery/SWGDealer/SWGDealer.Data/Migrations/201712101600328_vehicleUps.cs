namespace SWGDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicleUps : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VehicleModels", "VehicleMakeId", "dbo.VehicleMakes");
            DropIndex("dbo.VehicleModels", new[] { "VehicleMakeId" });
            AlterColumn("dbo.VehicleModels", "VehicleMakeId", c => c.Int());
            CreateIndex("dbo.VehicleModels", "VehicleMakeId");
            AddForeignKey("dbo.VehicleModels", "VehicleMakeId", "dbo.VehicleMakes", "VehicleMakeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleModels", "VehicleMakeId", "dbo.VehicleMakes");
            DropIndex("dbo.VehicleModels", new[] { "VehicleMakeId" });
            AlterColumn("dbo.VehicleModels", "VehicleMakeId", c => c.Int(nullable: false));
            CreateIndex("dbo.VehicleModels", "VehicleMakeId");
            AddForeignKey("dbo.VehicleModels", "VehicleMakeId", "dbo.VehicleMakes", "VehicleMakeId", cascadeDelete: true);
        }
    }
}
