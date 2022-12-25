using RegistroTramitesOplagestTrifinio.Shared.DTOs;

namespace RegistroTramitesOplagestTrifinio.Server.Extensiones
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacion)
        {
            return queryable
                .Skip((paginacion.Pagina - 1) * paginacion.Cantidad)
                .Take(paginacion.Cantidad);
        }
    }
}
