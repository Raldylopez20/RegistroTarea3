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

        public int MoraId { get; set; }

        public int PrestamoId { get; set; }

        public float Valor { get; set; }

        public DateTime FechaMoraDetalle { get; set; } = DateTime.Now;
    
        public MorasDetalle()
        {

            this.PrestamoId = 0;
            this.Valor = 0;
            FechaMoraDetalle = DateTime.Now;

        }
    
    
        public MorasDetalle(  int moraId, int prestamoId, DateTime fechaMoraDetalle, float valor)
        {
            Id = 0;
            MoraId = moraId;
            PrestamoId  = prestamoId;
            FechaMoraDetalle = fechaMoraDetalle;
            Valor = valor;
        }
    }

}