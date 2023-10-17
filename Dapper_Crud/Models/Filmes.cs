namespace Dapper_Crud.Models
{
    public class Filmes
    {
        public int FilmeId { get; set; }
        public string Name { get; set; }
        public int? Nota { get; set; }
        public DateTime? DataLancamento { get; set; }
    }
}
