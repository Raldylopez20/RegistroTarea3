  using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace RegistroTarea3.Entidades
{
    public class MorasDetalle
    {

        [Key]

        public int Id { get; set; }

        public int MorasId { get; set; }

        public int PrestamoId { get; set; }

        public float Valor { get; set; }

        public DateTime FechaMoraDetalle { get; set; } = DateTime.Now;
    
        public MorasDetalle()
        {

            Id = 0;
            MorasId = 0;
            PrestamoId = 0;
            Valor = 0;
            FechaMoraDetalle = DateTime.Now;

        }
    
    
        public MorasDetalle(  int morasId, int prestamoId, DateTime fechaMoraDetalle, float valor)
        {
            Id = 0;
            MorasId = morasId;
            PrestamoId  = prestamoId;
            FechaMoraDetalle = fechaMoraDetalle;
            Valor = valor;
        }
    }

}