using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLabEF1.Models
{
    [Table("Localidad")]
    public class Localidad
    {
        [Key]
        public int LocalidadId { get; set; }
        public string Nombre { get; set; }

        #region propiedades Nav
        public List<Estudiante> Estudiantes { get; set; }
        public List<Profesor> Profesores { get; set; }
        #endregion
    }
}
