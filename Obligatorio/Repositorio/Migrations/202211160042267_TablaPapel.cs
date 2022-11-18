namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablaPapel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.papeles",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 128),
                        Actor_Id = c.Int(nullable: false),
                        Pelicula_Identificador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Nombre, t.Actor_Id, t.Pelicula_Identificador })
                .ForeignKey("dbo.personas", t => t.Actor_Id, cascadeDelete: true)
                .ForeignKey("dbo.peliculas", t => t.Pelicula_Identificador, cascadeDelete: true)
                .Index(t => t.Actor_Id)
                .Index(t => t.Pelicula_Identificador);
            
            CreateTable(
                "dbo.PeliculaPersonas",
                c => new
                    {
                        Pelicula_Identificador = c.Int(nullable: false),
                        Persona_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pelicula_Identificador, t.Persona_Id })
                .ForeignKey("dbo.peliculas", t => t.Pelicula_Identificador, cascadeDelete: true)
                .ForeignKey("dbo.personas", t => t.Persona_Id, cascadeDelete: true)
                .Index(t => t.Pelicula_Identificador)
                .Index(t => t.Persona_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeliculaPersonas", "Persona_Id", "dbo.personas");
            DropForeignKey("dbo.PeliculaPersonas", "Pelicula_Identificador", "dbo.peliculas");
            DropForeignKey("dbo.papeles", "Pelicula_Identificador", "dbo.peliculas");
            DropForeignKey("dbo.papeles", "Actor_Id", "dbo.personas");
            DropIndex("dbo.PeliculaPersonas", new[] { "Persona_Id" });
            DropIndex("dbo.PeliculaPersonas", new[] { "Pelicula_Identificador" });
            DropIndex("dbo.papeles", new[] { "Pelicula_Identificador" });
            DropIndex("dbo.papeles", new[] { "Actor_Id" });
            DropTable("dbo.PeliculaPersonas");
            DropTable("dbo.papeles");
        }
    }
}
