namespace RegistroTramitesOplagestTrifinio.Shared.DTOs.Requisitos
{
    public struct RequisitosCheckBoxesModel
    {
        public int Clave { get; set; }
        public string Valor { get; set; }

        public RequisitosCheckBoxesModel(int clave, string valor)
        {
            Clave = clave;
            Valor = valor;
        }
    }
}
