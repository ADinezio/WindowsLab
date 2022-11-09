using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLabEF1.Models
{
    [Table("Detalle")]
    public class Detalle
    {
        [Key]
        public int PlanillaId { get; set; }
        public int DetalleId { get; set; }
        public int EstadoId { get; set; }

        #region propiedades Nav
        public Planilla Plantilla { get; set; }
        public Estado Estado { get; set; }
        #endregion
    }
}
