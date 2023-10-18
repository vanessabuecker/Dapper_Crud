using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dapper_Crud.Models
{
    public class Filmes
    {
        [Key] 
        public int FilmeID { get; set; }

        [Column("Nome")] 
        public string Nome { get; set; }
        public DateTime? DataLancamento { get; set; }

        public int? Nota { get; set; }
        
    }
}