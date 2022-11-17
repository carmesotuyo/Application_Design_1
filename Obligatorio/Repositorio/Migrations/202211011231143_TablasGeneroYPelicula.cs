namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablasGeneroYPelicula : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.generos",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 128),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Nombre);
            
            CreateTable(
                "dbo.peliculas",
                c => new
                    {
                        Identificador = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        AptaTodoPublico = c.Boolean(nullable: false),
                        EsPatrocinada = c.Boolean(nullable: false),
                        Poster = c.String(),
                        GeneroPrincipal_Nombre = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Identificador)
                .ForeignKey("dbo.generos", t => t.GeneroPrincipal_Nombre)
                .Index(t => t.GeneroPrincipal_Nombre);
            
            CreateTable(
                "dbo.PeliculaGeneroes",
                c => new
                    {
                        Pelicula_Identificador = c.Int(nullable: false),
                        Genero_Nombre = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Pelicula_Identificador, t.Genero_Nombre })
                .ForeignKey("dbo.peliculas", t => t.Pelicula_Identificador, cascadeDelete: true)
                .ForeignKey("dbo.generos", t => t.Genero_Nombre, cascadeDelete: true)
                .Index(t => t.Pelicula_Identificador)
                .Index(t => t.Genero_Nombre);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PeliculaGeneroes", "Genero_Nombre", "dbo.generos");
            DropForeignKey("dbo.PeliculaGeneroes", "Pelicula_Identificador", "dbo.peliculas");
            DropForeignKey("dbo.peliculas", "GeneroPrincipal_Nombre", "dbo.generos");
            DropIndex("dbo.PeliculaGeneroes", new[] { "Genero_Nombre" });
            DropIndex("dbo.PeliculaGeneroes", new[] { "Pelicula_Identificador" });
            DropIndex("dbo.peliculas", new[] { "GeneroPrincipal_Nombre" });
            DropTable("dbo.PeliculaGeneroes");
            DropTable("dbo.peliculas");
            DropTable("dbo.generos");
        }
    }
}
