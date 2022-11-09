using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLabEF1.Models
{
    [Table("Estudiante")]
    public class Estudiante
    {
        [Key]
        public int EstudianteId { get; set; }
        public int LocalidadId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }


        #region propiedades Nav
        public Localidad Localidad { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; }
        #endregion

    }
}
