using RegistroTramitesOplagestTrifinio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroTramitesOplagestTrifinio.Services.Interfaces
{
    internal interface IInstructivosService
    {
        void Create(InstructivoModel instructivo);
        void Delete(int instructivoId);
        void Update(InstructivoModel instructivo);
        List<InstructivoModel> GetInstructivos();
        InstructivoModel GetInstructivo(int instructivoId);
    }
}
