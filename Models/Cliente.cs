using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebApiDesafio.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Column("ClienteID")]
        [Display(Name = "ClienteID ")]
        public int ClienteID { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome ")]


        public string Nome { get; set; }


        [Column("Email ")]
        [Display(Name = "Email  ")]
        public string Email { get; set; }


        [Column("Logotipo")]
        [Display(Name = "Logotipo ")]
        public string Logotipo { get; set; }


    }
}
