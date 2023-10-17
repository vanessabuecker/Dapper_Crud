namespace Dapper_Crud.Models
{
    public class FilmesRequest
    {
        public int FilmeID { get; set; }
        public string Name { get; set; }
        public int Nota { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
