using Microsoft.EntityFrameworkCore;

namespace RegistroTramitesOplagestTrifinio.Server.Herramientas
{
    public static class HttpContextExtensions
    {
        public async static Task InsertarParametrosPaginacionEnRespuesta<T>(this HttpContext context, IQueryable<T> queryable, int registros)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            double cantidad = await queryable.CountAsync();
            double paginas = Math.Ceiling(cantidad / registros);

            context.Response.Headers.Add("cantidad", cantidad.ToString());
            context.Response.Headers.Add("paginas", paginas.ToString());
        }
    }
}