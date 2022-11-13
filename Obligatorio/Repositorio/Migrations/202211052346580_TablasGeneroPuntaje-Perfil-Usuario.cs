namespace Repositorio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablasGeneroPuntajePerfilUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.perfiles",
                c => new
                    {
                        Alias = c.String(nullable: false, maxLength: 128),
                        NombreUsuario = c.String(nullable: false, maxLength: 128),
                        Pin = c.Int(nullable: false),
                        ConfirmarPin = c.Int(nullable: false),
                        EsOwner = c.Boolean(nullable: false),
                        EsInfantil = c.Boolean(nullable: false),
                        Usuario_Nombre = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Alias, t.NombreUsuario })
                .ForeignKey("dbo.usuarios", t => t.Usuario_Nombre)
                .Index(t => t.Usuario_Nombre);
            
            CreateTable(
                "dbo.generos_puntajes",
                c => new
                    {
                        AliasPerfil = c.String(nullable: false, maxLength: 128),
                        NombreGenero = c.String(nullable: false, maxLength: 128),
                        Puntaje = c.Int(nullable: false),
                        Genero_Nombre = c.String(maxLength: 128),
                        Perfil_Alias = c.String(maxLength: 128),
                        Perfil_NombreUsuario = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AliasPerfil, t.NombreGenero })
                .ForeignKey("dbo.generos", t => t.Genero_Nombre)
                .ForeignKey("dbo.perfiles", t => new { t.Perfil_Alias, t.Perfil_NombreUsuario })
                .Index(t => t.Genero_Nombre)
                .Index(t => new { t.Perfil_Alias, t.Perfil_NombreUsuario });
            
            CreateTable(
                "dbo.usuarios",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false),
                        Clave = c.String(nullable: false),
                        ConfirmarClave = c.String(),
                        EsAdministrador = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Nombre);
            
            CreateTable(
                "dbo.PerfilPeliculas",
                c => new
                    {
                        Perfil_Alias = c.String(nullable: false, maxLength: 128),
                        Perfil_NombreUsuario = c.String(nullable: false, maxLength: 128),
                        Pelicula_Identificador = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Perfil_Alias, t.Perfil_NombreUsuario, t.Pelicula_Identificador })
                .ForeignKey("dbo.perfiles", t => new { t.Perfil_Alias, t.Perfil_NombreUsuario }, cascadeDelete: true)
                .ForeignKey("dbo.peliculas", t => t.Pelicula_Identificador, cascadeDelete: true)
                .Index(t => new { t.Perfil_Alias, t.Perfil_NombreUsuario })
                .Index(t => t.Pelicula_Identificador);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.perfiles", "Usuario_Nombre", "dbo.usuarios");
            DropForeignKey("dbo.generos_puntajes", new[] { "Perfil_Alias", "Perfil_NombreUsuario" }, "dbo.perfiles");
            DropForeignKey("dbo.generos_puntajes", "Genero_Nombre", "dbo.generos");
            DropForeignKey("dbo.PerfilPeliculas", "Pelicula_Identificador", "dbo.peliculas");
            DropForeignKey("dbo.PerfilPeliculas", new[] { "Perfil_Alias", "Perfil_NombreUsuario" }, "dbo.perfiles");
            DropIndex("dbo.PerfilPeliculas", new[] { "Pelicula_Identificador" });
            DropIndex("dbo.PerfilPeliculas", new[] { "Perfil_Alias", "Perfil_NombreUsuario" });
            DropIndex("dbo.generos_puntajes", new[] { "Perfil_Alias", "Perfil_NombreUsuario" });
            DropIndex("dbo.generos_puntajes", new[] { "Genero_Nombre" });
            DropIndex("dbo.perfiles", new[] { "Usuario_Nombre" });
            DropTable("dbo.PerfilPeliculas");
            DropTable("dbo.usuarios");
            DropTable("dbo.generos_puntajes");
            DropTable("dbo.perfiles");
        }
    }
}
