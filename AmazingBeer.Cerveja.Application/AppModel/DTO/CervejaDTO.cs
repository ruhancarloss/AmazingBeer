using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBeer.Cerveja.Application.AppModel.DTO
{
    public class CervejaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public float ABV { get; set; } // quantidade alcóolica
        public float IBU { get; set; } // nível de amargor
        public double Avaliacao { get; set; }
    }
}
