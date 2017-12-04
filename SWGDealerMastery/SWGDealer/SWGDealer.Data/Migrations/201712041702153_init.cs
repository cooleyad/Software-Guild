namespace SWGDealer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.SalesSpecials",
                c => new
                    {
                        SalesSpecialsId = c.Int(nullable: false, identity: true),
                        SpecialsName = c.String(),
                        SpecialDesc = c.String(),
                    })
                .PrimaryKey(t => t.SalesSpecialsId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        PurchaseTypeId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        DatePurchased = c.DateTime(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseTypes", t => t.PurchaseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.PurchaseTypeId)
                .Index(t => t.VehicleId)
                .Index(t => t.CustomerId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.PurchaseTypes",
                c => new
                    {
                        PurchaseTypeId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseTypeId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Role = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        Vin = c.String(),
                        ModelId = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        BodyStyle = c.String(),
                        TransmissionType = c.String(),
                        Color = c.String(),
                        InteriorColor = c.String(),
                        Odometer = c.Int(nullable: false),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MSRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Image = c.String(),
                        VehicleIsNew = c.Boolean(nullable: false),
                        VehicleIsSold = c.Boolean(nullable: false),
                        VehicleFeatured = c.Boolean(nullable: false),
                        Model_VehicleModelId = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.VehicleModels", t => t.Model_VehicleModelId)
                .Index(t => t.Model_VehicleModelId);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        VehicleModelId = c.Int(nullable: false, identity: true),
                        VehicleModelName = c.String(),
                        VehicleMakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleModelId)
                .ForeignKey("dbo.VehicleMakes", t => t.VehicleMakeId, cascadeDelete: true)
                .Index(t => t.VehicleMakeId);
            
            CreateTable(
                "dbo.VehicleMakes",
                c => new
                    {
                        VehicleMakeId = c.Int(nullable: false, identity: true),
                        VehicleMakeName = c.String(),
                    })
                .PrimaryKey(t => t.VehicleMakeId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Purchases", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Model_VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleModels", "VehicleMakeId", "dbo.VehicleMakes");
            DropForeignKey("dbo.Purchases", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Purchases", "PurchaseTypeId", "dbo.PurchaseTypes");
            DropForeignKey("dbo.Purchases", "CustomerId", "dbo.Customers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.VehicleModels", new[] { "VehicleMakeId" });
            DropIndex("dbo.Vehicles", new[] { "Model_VehicleModelId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Purchases", new[] { "User_Id" });
            DropIndex("dbo.Purchases", new[] { "CustomerId" });
            DropIndex("dbo.Purchases", new[] { "VehicleId" });
            DropIndex("dbo.Purchases", new[] { "PurchaseTypeId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.VehicleMakes");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.Vehicles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.PurchaseTypes");
            DropTable("dbo.Customers");
            DropTable("dbo.Purchases");
            DropTable("dbo.SalesSpecials");
            DropTable("dbo.Contacts");
        }
    }
}
