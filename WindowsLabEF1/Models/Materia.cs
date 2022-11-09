using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLabEF1.Models
{
    [Table("Materia")]
    public class Materia
    {
        [Key]
        public int MateriaId { get; set; }
        public string Nombre { get; set; }

        #region propiedades Nav
        public List<Planilla> Planillas { get; set; }
        #endregion
    }
}
