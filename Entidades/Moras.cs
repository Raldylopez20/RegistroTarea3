using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTarea3.Entidades
{

    public class Moras
    {
        [Key]

        public int MoraId { get; set; }

        public DateTime Fecha { get; set; }  = DateTime.Now;

        public double Total { get; set; }

        [ForeignKey("MoraId")]
        public List<MorasDetalle> Detalle { get; set; } = new List<MorasDetalle>();

        public Moras()
        {

            MoraId = 0;
            Total = 0;
            Detalle = new List<MorasDetalle>();


        }

    }

}