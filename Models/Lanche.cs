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
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínomo {1} e no maximo {10} Caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição deve ser preenchida")]
        [Display(Name = "Descrição do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder o maximo de caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A descrição deve ser detalhada")]
        [Display(Name = "Descrição do Lanche ")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição não pode exceder o maximo de caracteres")]
        public string DescricaoDetalhada { get; set; }
        [NotMapped]
        public DateTime DataDeCriacao { get; set; }
        
        [Required(ErrorMessage = "Infome o preço do lanche")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1,999.99,ErrorMessage = "O Preço deve estar entre 1 e 999,999")]
        public decimal Preco { get; set; }
        [Display(Name ="Caminho imagem normal '1' Caracter ")]
        [StringLength(200, ErrorMessage ="Deve ter no minimo ")]
        public string ImagemUrl { get; set; }
        [Display(Name = "Caminho imagem Miniatura")]
        [StringLength(200, ErrorMessage = "Deve ter no minimo '1' Caracter ")]
        public string ImagemThumbnailUrl { get; set; }
        [Display(Name = "Preferido?")]
        public bool IsLanchePReferido { get; set; }

        [Display(Name ="Estoque")]
        public bool EmEstoque { get; set; }

        //Define o relacionamento entre Categoria e lanche
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
