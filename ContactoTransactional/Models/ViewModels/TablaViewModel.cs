using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactoTransactional.Models.ViewModels
{
    public class TablaViewModel {

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo electronico")]
        public string Correo { get; set; }

        [Required]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNcimiento { get; set; }

    }
}