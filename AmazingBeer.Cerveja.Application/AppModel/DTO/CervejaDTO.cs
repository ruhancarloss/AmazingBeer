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
        public decimal? ABV { get; set; } // quantidade alcóolica
        public decimal? IBU { get; set; } // nível de amargor
        public decimal? Avaliacao { get; set; }
    }
}
