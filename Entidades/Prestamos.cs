using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RegistroTarea3.Entidades
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { set; get; }

        public DateTime Fecha { set; get; } = DateTime.Now;

        public int PersonaId { set; get; }

        public string Concepto { set; get; }

        public double Monto { set; get; }
        
        public double Balance { set; get; }

         //REGISTRO DETALLADO
        [ForeignKey("PrestamoId")]
        public List<MorasDetalle> Detalle { get; set; } = new List<MorasDetalle>();
    }
}