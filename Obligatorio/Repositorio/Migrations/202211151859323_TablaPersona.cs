namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaPersona : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.personas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FotoPerfil = c.String(),
                        Nombre = c.String(),
                        FechaNacimiento = c.DateTime(nullable: true, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.personas");
        }
    }
}
