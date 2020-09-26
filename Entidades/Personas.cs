using System;
using System.ComponentModel.DataAnnotations;

namespace RegistroTarea3.Entidades
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }

        public string Nombres { get; set; }

        public double Balance { get; set; }
        
        public DateTime Fecha { set; get; } = DateTime.Now;
    }
}