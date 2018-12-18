using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSM2.Models
{
    public class Evento
    {


        [ScaffoldColumn(false)]
        public int id { get; set; }

        /*    [ScaffoldColumn(false)]
        public IList<Comentario> { get; set; }*/
        //Tambien tengo que crear el model de comentario y el assembler

        /*    [ScaffoldColumn(false)]
      public IList<Entradas> { get; set; }*/

        //Model y Assembler van muy relacionados por que en el assembler asigno bien las variables que creo en el model
        //y todo esto es para los detalles del evento

        [Display(Prompt = "Lugar del evento", Description = "Lugar del evento", Name = "Lugar ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el evento")]
        [StringLength(maximumLength: 50, ErrorMessage = "El lugar no puede tener más de 50 caracteres")]
        public string Lugar { get; set; }

        [Display(Prompt = "Fecha", Description = "Fecha", Name = "Fecha")]
        //Tipo de fecha
        //        [DataType(DataType.DateTime)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? Fecha { get; set; }

        [Display(Prompt = "Tipo", Description = "Tipo", Name = "Tipo ")]
        [Required(ErrorMessage = "Debe indicar una imagen del evento")]
        public DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum Tipo { get; set; }


        [Display(Prompt = "Descripción del evento", Description = "Descripción del evento", Name = "Descripción ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el artículo")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre del evento no puede tener más de 200 caracteres")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Nombre del evento", Description = "Nombre del evento", Name = "Nombre ")]
        [Required(ErrorMessage = "Debe indicar un nombre para el evento")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string Nombre { get; set; }

        [Display(Prompt = "Genero", Description = "Genero", Name = "Genero ")]
        [Required(ErrorMessage = "Debe indicar una imagen del evento")]
        public DSMGenNHibernate.Enumerated.DSM.GeneroEventoEnum Genero { get; set; }
















    }
}