using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLabEF1.Models
{
    [Table("Plan")]
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }
        public int CarreraId { get; set; }
        public string Nombre { get; set; }

        #region propiedades Nav
        public Carrera Carrera { get; set; }
        #endregion
    }
}
