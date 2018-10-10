namespace BoVoyageP4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangementCivilite : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Civilite", c => c.Int(nullable: false));
            AlterColumn("dbo.Participants", "Civilite", c => c.Int(nullable: false));
            AlterColumn("dbo.Commercials", "Civilite", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Commercials", "Civilite", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.Participants", "Civilite", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.Clients", "Civilite", c => c.String(nullable: false, maxLength: 4));
        }
    }
}
