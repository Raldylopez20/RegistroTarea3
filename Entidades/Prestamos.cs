using System;
using System.ComponentModel.DataAnnotations;

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
    }
}