using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        [Required(ErrorMessage = "O nome da categoria deve ser informado")]
        [StringLength(100, ErrorMessage = "O tamanho máximo é 100 Caracteres")]
        [Display(Name = "Nome")]
        public string CategoriaNome { get; set; }

        [Required(ErrorMessage = "A Desscrição deve ser informada")]
        [StringLength(200, ErrorMessage = "O tamanho máximo é 200 Caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set; }

    }
}
