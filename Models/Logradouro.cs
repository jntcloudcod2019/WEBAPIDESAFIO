using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDesafio.Models
{
    [Table ("Logradouro")]
    public class Logradouro
    {
        [Column("LogradouroID")]
        [Display(Name = "LogradouroID ")]
        public int LogradouroID { get; set; }

        [Column("Endereco")]
        [Display(Name = "Endereco ")]
        public string Endereco { get; set; }

        [Column("Cidade")]
        [Display(Name = "Cidade ")]
        public string Cidade { get; set; }

        [Column("Estado")]
        [Display(Name = "Estado ")]
        public string Estado { get; set; }

        [Column("ClienteID")]
        [Display(Name = "ClienteID ")]
        public int ClienteID { get; set; }

        //public Cliente Cliente { get; set; } // Relação com o Cliente
    }
}
