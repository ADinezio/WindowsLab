using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLabEF1.Models
{
    [Table("Planilla")]
    public class Planilla
    {
        [Key]
        public int PlanillaId { get; set; }
        public int CarreraId { get; set; }
        public int MateriaId { get; set; }
        public int ProfesorId { get; set; }
        public int CursoId { get; set; }
        public DateTime Fecha { get; set; }

        #region propiedades Nav
        public Carrera Carrera { get; set; }
        public Materia Materia { get; set; }
        public Profesor Profesor { get; set; }
        public Curso Curso { get; set; }
        public List<Detalle> Detalles { get; set; }
        #endregion
    }
}
