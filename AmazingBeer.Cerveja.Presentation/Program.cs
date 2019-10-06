using AmazingBeer.Cerveja.Application.AppModel.DTO;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace AmazingBeer.Cerveja.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "https://localhost:44379/api/cerveja";
            var client = new HttpClient();

            //Salvar
            CervejaDTO cerva = new CervejaDTO
            {
                Nome = "Corona",
                Tipo = "Pilsen",
                Descricao = "Top",
                ABV = 1,
                IBU = 2
            };
            System.Console.WriteLine("Press salvar cerveja.");
            System.Console.ReadLine();
            var result = client.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(cerva), Encoding.UTF8, "application/json")).Result; 

            System.Console.WriteLine("Press Editar.");
            Guid id = new Guid("9D78563D-26F8-43CE-8439-08D74A9BF256");
            //Salvar
            CervejaDTO cervaedit = new CervejaDTO
            {
                Id = id,
                Nome = "Corona alt",
                Tipo = "Pilsen alt",
                Descricao = "Top alt",
                ABV = 1,
                IBU = 2
            };
            System.Console.WriteLine("Press editar cerveja.");
            System.Console.ReadLine();
            var resultedit = client.PutAsync(uri + "/" + id.ToString(), new StringContent(JsonConvert.SerializeObject(cervaedit), Encoding.UTF8, "application/json")).Result; 
            System.Console.WriteLine("Press salvou.");

            System.Console.WriteLine("Press apagar cerveja.");
            System.Console.ReadLine();

            Guid iddelete = new Guid("8E04DA8B-AE48-4D02-BBFF-ADE911DF7AC4");
            var resultexcluir = client.DeleteAsync(uri + "/" + iddelete.ToString()).Result;
            System.Console.WriteLine("Press apagou.");

        }
    }
}
