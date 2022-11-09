using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLabEF1.Models
{
    [Table("Evaluacion")]
    public class Evaluacion
    {
        [Key]
        public int EvaluacionId { get; set; }
        public int TipoId { get; set; }
        public int EstudianteId { get; set; }
        public int DetalleId { get; set; }
        public int Nota { get; set; }

        #region propiedades Nav
        public Estudiante Estudiante { get; set; }
        public Detalle Detalle { get; set; }
        public Tipo Tipo { get; set; }
        #endregion
    }
}
