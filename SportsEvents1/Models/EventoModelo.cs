using SportsEventsGenNHibernate.EN.SportsEvents;
using SportsEventsGenNHibernate.Enumerated.SportsEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsEvents_FrontEnd.Models
{
    public class EventoModelo
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public int numPart { get; set; }

        [ScaffoldColumn(false)]
        public int idgaleria { get; set; }

        [Display(Prompt = "Numero máximo de participantes", Description = "Numero máximo de participantes", Name = "numPartMax")]
        [Required(ErrorMessage = "Debe indicar un numero de participantes máximo")]
        public int numPartMax { get; set; }

        [ScaffoldColumn(false)]
        public TipoEventoEnum tipo { get; set; }

        [Display(Prompt = "Nombre del evento", Description = "Nombre del evento", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el evento")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Descripción del evento", Description = "Descripción del evento", Name = "Descripción ")]
        [StringLength(maximumLength: 2000, ErrorMessage = "La descripción no puede tener más de 2000 caracteres")]
        public string Descripcion { get; set; }

        public String Categoria { get; set; }

        [Display(Prompt = "Localización del evento", Description = "Localización del evento", Name = "Localizacion ")]
        [Required(ErrorMessage = "Debe indicar una localizacion para el evento")]
        public String Localizacion { get; set; }

        public Double Longitud { get; set; }

        public Double Latitud { get; set; }

        [Display(Prompt = "Fecha del evento", Description = "Fecha del evento", Name = "Fecha ")]
        [Required(ErrorMessage = "Debe indicar una fecha para el evento")]
        public DateTime? Fecha { get; set; }

        [ScaffoldColumn(false)]
        public String Crea { get; set; }
    }
}

