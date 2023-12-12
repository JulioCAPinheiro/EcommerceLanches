using Ecommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Ecommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagensController : Controller
    {
        private readonly ConfigurationImagens _myConfig;
        private readonly IWebHostEnvironment _hostingEnviroment;

        public AdminImagensController(IOptions<ConfigurationImagens> myConfiguration, IWebHostEnvironment hostingEnviroment)
        {
            _myConfig = myConfiguration.Value;
            _hostingEnviroment = hostingEnviroment;
        }

        public IActionResult Index()
        {

            return View();
        }

        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                return View(ViewData);
            }

            if (files.Count > 10)
            {
                ViewData["Erro"] = "Error: Quantidade de arquivo excedeu o limite";
                return View(ViewData);
            }

            long size = files.Sum(f => f.Length);

            var filePathsName = new List<string>();

            var filePath = Path.Combine(_hostingEnviroment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            foreach (var file in files)
            {
                if (file.FileName.Contains(".jpg") || file.FileName.Contains(".gif") || file.FileName.Contains(".jpeg") || file.FileName.Contains(".png"))
                {
                    var fileNameWithOath = string.Concat(filePath, "\\", file.FileName);

                    filePathsName.Add(fileNameWithOath);

                    using (var stream = new FileStream(fileNameWithOath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }

            ViewData["Resultado"] = $"{files.Count} Arquivos foram enviados ao servido, " + $"Com tamanho total de: {size} bytes";

            ViewBag.Arquivos = filePathsName;

            return View(ViewData);
        }

        public IActionResult GetImagens()
        {
            FileManagerModel model = new FileManagerModel();

            var userImagesPath = Path.Combine(_hostingEnviroment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            DirectoryInfo dir = new DirectoryInfo(userImagesPath);

            FileInfo[] files = dir.GetFiles();

            model.PathImagesProduto = _myConfig.NomePastaImagensProdutos;

            if(files.Length == 0)
            {
                ViewData["Erro"] = $"Nenhum Arquivo encontrado na pasta {userImagesPath}";
            }

            model.Files = files;

            return View(model);
        }

        public IActionResult DeleteFile(string fname)
        {
            string _imagemDeleta = Path.Combine(_hostingEnviroment.WebRootPath, _myConfig.NomePastaImagensProdutos + "\\", fname);

            if(System.IO.File.Exists(_imagemDeleta))
            {
                System.IO.File.Delete(_imagemDeleta);

                ViewData["Deletado"] = $"Arquivo(s) {_imagemDeleta} Deletado com sucesso";
            }

            return View("Index");
        }
    }
}
