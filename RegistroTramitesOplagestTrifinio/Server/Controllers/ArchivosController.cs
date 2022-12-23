using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistroTramitesOplagestTrifinio.Services.Interfaces;
using RegistroTramitesOplagestTrifinio.Shared;
using System.Net;

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

        [HttpPost("{VisitaId:int}/SubirArchivoVisitaTecnica")]
        public async Task<ActionResult<UploadResult>> PostFile([FromForm] IEnumerable<IFormFile> files, int visitaId)
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
                            "unsafe_uploads",
                            untrustedFileName
                            );

                        Console.WriteLine(path);

                        await using FileStream fs = new(path, FileMode.Create);

                        await file.CopyToAsync(fs);

                        await CompletarVisitaTecnica(visitaId);

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
