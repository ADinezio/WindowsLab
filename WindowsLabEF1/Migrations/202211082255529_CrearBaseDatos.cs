namespace WindowsLabEF1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearBaseDatos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrera",
                c => new
                    {
                        CarreraId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.CarreraId);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        CarreraId = c.Int(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.PlanId)
                .ForeignKey("dbo.Carrera", t => t.CarreraId, cascadeDelete: true)
                .Index(t => t.CarreraId);
            
            CreateTable(
                "dbo.Planilla",
                c => new
                    {
                        PlanillaId = c.Int(nullable: false, identity: true),
                        CarreraId = c.Int(nullable: false),
                        MateriaId = c.Int(nullable: false),
                        ProfesorId = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PlanillaId)
                .ForeignKey("dbo.Carrera", t => t.CarreraId, cascadeDelete: true)
                .ForeignKey("dbo.Curso", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.Materia", t => t.MateriaId, cascadeDelete: true)
                .ForeignKey("dbo.Profesor", t => t.ProfesorId, cascadeDelete: true)
                .Index(t => t.CarreraId)
                .Index(t => t.MateriaId)
                .Index(t => t.ProfesorId)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.CursoId);
            
            CreateTable(
                "dbo.Detalle",
                c => new
                    {
                        PlanillaId = c.Int(nullable: false, identity: true),
                        DetalleId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                        Plantilla_PlanillaId = c.Int(),
                    })
                .PrimaryKey(t => t.PlanillaId)
                .ForeignKey("dbo.Estado", t => t.EstadoId, cascadeDelete: true)
                .ForeignKey("dbo.Planilla", t => t.Plantilla_PlanillaId)
                .Index(t => t.EstadoId)
                .Index(t => t.Plantilla_PlanillaId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.Materia",
                c => new
                    {
                        MateriaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.MateriaId);
            
            CreateTable(
                "dbo.Profesor",
                c => new
                    {
                        ProfesorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        LocalidadId = c.Int(nullable: false),
                        Apellido = c.String(),
                    })
                .PrimaryKey(t => t.ProfesorId)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId, cascadeDelete: true)
                .Index(t => t.LocalidadId);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        LocalidadId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.LocalidadId);
            
            CreateTable(
                "dbo.Estudiante",
                c => new
                    {
                        EstudianteId = c.Int(nullable: false, identity: true),
                        LocalidadId = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.String(),
                        Calle = c.String(),
                        Numero = c.String(),
                    })
                .PrimaryKey(t => t.EstudianteId)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId, cascadeDelete: true)
                .Index(t => t.LocalidadId);
            
            CreateTable(
                "dbo.Evaluacion",
                c => new
                    {
                        EvaluacionId = c.Int(nullable: false, identity: true),
                        TipoId = c.Int(nullable: false),
                        EstudianteId = c.Int(nullable: false),
                        DetalleId = c.Int(nullable: false),
                        Nota = c.Int(nullable: false),
                        Detalle_PlanillaId = c.Int(),
                    })
                .PrimaryKey(t => t.EvaluacionId)
                .ForeignKey("dbo.Detalle", t => t.Detalle_PlanillaId)
                .ForeignKey("dbo.Estudiante", t => t.EstudianteId, cascadeDelete: true)
                .ForeignKey("dbo.Tipo", t => t.TipoId, cascadeDelete: true)
                .Index(t => t.TipoId)
                .Index(t => t.EstudianteId)
                .Index(t => t.Detalle_PlanillaId);
            
            CreateTable(
                "dbo.Tipo",
                c => new
                    {
                        TipoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.TipoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Planilla", "ProfesorId", "dbo.Profesor");
            DropForeignKey("dbo.Profesor", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Estudiante", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Evaluacion", "TipoId", "dbo.Tipo");
            DropForeignKey("dbo.Evaluacion", "EstudianteId", "dbo.Estudiante");
            DropForeignKey("dbo.Evaluacion", "Detalle_PlanillaId", "dbo.Detalle");
            DropForeignKey("dbo.Planilla", "MateriaId", "dbo.Materia");
            DropForeignKey("dbo.Detalle", "Plantilla_PlanillaId", "dbo.Planilla");
            DropForeignKey("dbo.Detalle", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Planilla", "CursoId", "dbo.Curso");
            DropForeignKey("dbo.Planilla", "CarreraId", "dbo.Carrera");
            DropForeignKey("dbo.Plan", "CarreraId", "dbo.Carrera");
            DropIndex("dbo.Evaluacion", new[] { "Detalle_PlanillaId" });
            DropIndex("dbo.Evaluacion", new[] { "EstudianteId" });
            DropIndex("dbo.Evaluacion", new[] { "TipoId" });
            DropIndex("dbo.Estudiante", new[] { "LocalidadId" });
            DropIndex("dbo.Profesor", new[] { "LocalidadId" });
            DropIndex("dbo.Detalle", new[] { "Plantilla_PlanillaId" });
            DropIndex("dbo.Detalle", new[] { "EstadoId" });
            DropIndex("dbo.Planilla", new[] { "CursoId" });
            DropIndex("dbo.Planilla", new[] { "ProfesorId" });
            DropIndex("dbo.Planilla", new[] { "MateriaId" });
            DropIndex("dbo.Planilla", new[] { "CarreraId" });
            DropIndex("dbo.Plan", new[] { "CarreraId" });
            DropTable("dbo.Tipo");
            DropTable("dbo.Evaluacion");
            DropTable("dbo.Estudiante");
            DropTable("dbo.Localidad");
            DropTable("dbo.Profesor");
            DropTable("dbo.Materia");
            DropTable("dbo.Estado");
            DropTable("dbo.Detalle");
            DropTable("dbo.Curso");
            DropTable("dbo.Planilla");
            DropTable("dbo.Plan");
            DropTable("dbo.Carrera");
        }
    }
}
