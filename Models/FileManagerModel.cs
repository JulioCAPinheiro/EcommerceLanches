namespace Ecommerce.Models
{
    public class FileManagerModel
    {
        //Fornece Propriedades e métodos para ciar, copiar, excluir, abrir arquivos, etc.
        public FileInfo[] Files { get; set; }
        //Representa um arquivo enviado via httprequest
        public IFormFile IFormFile { get; set; }
        //Representa uma lista de arquivos enviado httprequest
        public List<IFormFile> IFormFiles { get; set; }
        //Representa a pasta onde vamos salvar as imagens
        public string PathImagesProduto { get; set; }
    }
}
