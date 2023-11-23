using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    [Table("Lanches")]
    public class Lanche
    {

        [Key]
        public int LancheId { get; set; }
        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Nome do lanche")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A descrição deve ser preenchida")]
        [Display(Name = "Descrição do Lanche")]
        [MinLength(20)]
        [MaxLength(200)]
        public string DescricaoCurta { get; set; }
        [NotMapped]
        public DateTime DataDeCriacao { get; set; }
        public string DescricaoDetalhada { get; set; }
        [Required]
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public bool IsLanchePReferido { get; set; }
        public bool EmEstoque { get; set; }

        //Define o relacionamento entre Categoria e lanche
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
