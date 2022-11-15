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
                        Nombre = c.String(),
                        FotoPerfil = c.String(),
                        FechaNacimiento = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.personas");
        }
    }
}
