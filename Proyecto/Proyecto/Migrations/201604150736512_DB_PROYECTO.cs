namespace Proyecto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DB_PROYECTO : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Archivoes",
                c => new
                    {
                        idArchivo = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        contentType = c.String(),
                        tipo = c.Int(nullable: false),
                        contenido = c.Binary(),
                        automovil_idAutomovil = c.Int(),
                    })
                .PrimaryKey(t => t.idArchivo)
                .ForeignKey("dbo.Automovils", t => t.automovil_idAutomovil)
                .Index(t => t.automovil_idAutomovil);
            
            CreateTable(
                "dbo.Automovils",
                c => new
                    {
                        idAutomovil = c.Int(nullable: false, identity: true),
                        precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        color = c.String(),
                        descripcion = c.String(),
                        estado = c.String(),
                        transmision = c.String(),
                        idMarca = c.Int(nullable: false),
                        idModelo = c.Int(nullable: false),
                        idCombustible = c.Int(nullable: false),
                        Compra_idCompra = c.Int(),
                    })
                .PrimaryKey(t => t.idAutomovil)
                .ForeignKey("dbo.Combustibles", t => t.idCombustible, cascadeDelete: true)
                .ForeignKey("dbo.Marcas", t => t.idMarca, cascadeDelete: true)
                .ForeignKey("dbo.Modeloes", t => t.idModelo, cascadeDelete: true)
                .ForeignKey("dbo.Compras", t => t.Compra_idCompra)
                .Index(t => t.idMarca)
                .Index(t => t.idModelo)
                .Index(t => t.idCombustible)
                .Index(t => t.Compra_idCompra);
            
            CreateTable(
                "dbo.Combustibles",
                c => new
                    {
                        idCombustible = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idCombustible);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        idMarca = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idMarca);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        idModelo = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idModelo);
            
            CreateTable(
                "dbo.Compras",
                c => new
                    {
                        idCompra = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        Usuario_idUsuario = c.Int(),
                    })
                .PrimaryKey(t => t.idCompra)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_idUsuario)
                .Index(t => t.Usuario_idUsuario);
            
            CreateTable(
                "dbo.Rols",
                c => new
                    {
                        idRol = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idRol);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        idUsuario = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        correo = c.String(nullable: false),
                        direccion = c.String(),
                        telefono = c.String(nullable: false, maxLength: 12),
                        contraseña = c.String(nullable: false),
                        confirmarContraseña = c.String(),
                        rol_idRol = c.Int(),
                    })
                .PrimaryKey(t => t.idUsuario)
                .ForeignKey("dbo.Rols", t => t.rol_idRol)
                .Index(t => t.rol_idRol);
            
            CreateTable(
                "dbo.Transmisions",
                c => new
                    {
                        idTransmision = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idTransmision);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "rol_idRol", "dbo.Rols");
            DropForeignKey("dbo.Compras", "Usuario_idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Automovils", "Compra_idCompra", "dbo.Compras");
            DropForeignKey("dbo.Automovils", "idModelo", "dbo.Modeloes");
            DropForeignKey("dbo.Automovils", "idMarca", "dbo.Marcas");
            DropForeignKey("dbo.Automovils", "idCombustible", "dbo.Combustibles");
            DropForeignKey("dbo.Archivoes", "automovil_idAutomovil", "dbo.Automovils");
            DropIndex("dbo.Usuarios", new[] { "rol_idRol" });
            DropIndex("dbo.Compras", new[] { "Usuario_idUsuario" });
            DropIndex("dbo.Automovils", new[] { "Compra_idCompra" });
            DropIndex("dbo.Automovils", new[] { "idCombustible" });
            DropIndex("dbo.Automovils", new[] { "idModelo" });
            DropIndex("dbo.Automovils", new[] { "idMarca" });
            DropIndex("dbo.Archivoes", new[] { "automovil_idAutomovil" });
            DropTable("dbo.Transmisions");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Rols");
            DropTable("dbo.Compras");
            DropTable("dbo.Modeloes");
            DropTable("dbo.Marcas");
            DropTable("dbo.Combustibles");
            DropTable("dbo.Automovils");
            DropTable("dbo.Archivoes");
        }
    }
}
