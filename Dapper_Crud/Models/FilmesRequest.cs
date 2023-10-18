using System.ComponentModel.DataAnnotations.Schema;

namespace Dapper_Crud.Models
{
    public class FilmesRequest
    {
        public int FilmeID { get; set; }
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public int Nota { get; set; }
       
    }
}
