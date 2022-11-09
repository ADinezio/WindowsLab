﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsLabEF1.Models
{
    [Table("Tipo")]
    public class Tipo
    {
        [Key]
        public int TipoId { get; set; }
        public string Nombre { get; set; }

        #region propiedades Nav
        public List<Evaluacion> Evaluaciones { get; set; }
        #endregion
    }
}
