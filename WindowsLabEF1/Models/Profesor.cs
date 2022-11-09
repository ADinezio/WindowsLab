using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLabEF1.Models
{
    [Table("Profesor")]
    public class Profesor
    {
        [Key]
        public int ProfesorId { get; set; }
        public string Nombre { get; set; }
        public int LocalidadId { get; set; }
        public string Apellido { get; set; }

        #region propiedades Nav
        public List<Planilla> Planillas { get; set; }
        public Localidad Localidad { get; set; }
        #endregion
    }
}
