using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared;
using System.Net;
using Archivo = System.IO.File;

namespace RegistroTramitesOplagestTrifinio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ArchivosController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IVisitasService _visitasService;
        private UploadResult _uploadResult;

        public ArchivosController(IWebHostEnvironment webHostEnvironment, IVisitasService visitasService)
        {
            _webHostEnvironment = webHostEnvironment;
            _visitasService = visitasService;
        }

        [HttpPost("subir/{tramiteFolder}")]
        public async Task<ActionResult<UploadResult>> PostFile([FromForm] IEnumerable<IFormFile> files, string tramiteFolder)
        {
            var maxAllowedFiles = 1;
            var filesProcessed = 0;
            var resourcePath = new Uri($"{Request.Scheme}://{Request.Host}/");

            foreach (var file in files)
            {
                _uploadResult = new UploadResult();
                var trustedFileNameForFileStorage = string.Empty;
                var untrustedFileName = file.FileName;
                var trustedFileNameForDisplay = WebUtility.HtmlEncode(untrustedFileName);

                _uploadResult.FileName = untrustedFileName;

                if (filesProcessed < maxAllowedFiles)
                {
                    try
                    {
                        trustedFileNameForFileStorage = Path.GetRandomFileName();

                        var path = Path.Combine(
                            _webHostEnvironment.ContentRootPath,
                            _webHostEnvironment.EnvironmentName,
                            "archivos_de_tramites",
                            tramiteFolder
                            );

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        await using FileStream fs = new(Path.Combine(path, untrustedFileName), FileMode.Create, FileAccess.Write);

                        await file.CopyToAsync(fs);

                        _uploadResult.Uploaded = true;
                        _uploadResult.StoredFileName = trustedFileNameForFileStorage;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        _uploadResult.ErrorCode = 3;
                    }
                }
            }

            return new CreatedResult(resourcePath, _uploadResult);
        }

        [HttpGet("todos/{tramiteFolder}")]
        public async Task<ActionResult<List<string>>> GetFileNamesAsync(string tramiteFolder)
        {
            var ruta = Path.Combine(_webHostEnvironment.ContentRootPath, _webHostEnvironment.EnvironmentName, "archivos_de_tramites", tramiteFolder);
            var archivos = new List<string>();

            if (!Directory.Exists(ruta))
            {
                return new List<string>();
            }

            var files = Directory.GetFiles(ruta);

            foreach (var file in files)
            {
                archivos.Add(Path.GetFileName(file));
            }

            return archivos;
        }

        [HttpGet("descargar/{tramiteFolder}/{fileName}")]
        public async Task<IActionResult> DownloadFile(string fileName, string tramiteFolder)
        {
            var ruta = Path.Combine(_webHostEnvironment.ContentRootPath, _webHostEnvironment.EnvironmentName, "archivos_de_tramites", tramiteFolder, fileName);

            if (!Archivo.Exists(ruta))
            {
                return NotFound("El archivo no existe");
            }

            var memoryStream = new MemoryStream();
            using var fileStream = new FileStream(ruta, FileMode.Open, FileAccess.Read);

            await fileStream.CopyToAsync(memoryStream);

            memoryStream.Position = 0;

            Console.WriteLine("Archivo solicitado: " + fileName + "\n Archivo enviado: " + Path.GetFileName(ruta));

            return File(memoryStream, "application/pdf", Path.GetFileName(ruta));
        }

        private async Task CompletarVisitaTecnica(int visitaId)
        {
            if (await _visitasService.GetVisitaAsync(visitaId) is var visita)
            {
                visita.Estado = "Realizada";
                visita.FechaFinalizacion = DateOnly.FromDateTime(DateTime.Today);

                await _visitasService.UpdateAsync(visita);
            }
        }
    }
}
