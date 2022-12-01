using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RegistroTramitesOplagestTrifinio.Models
{
    public class UsuarioModel
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UsuarioId { get; set; } = string.Empty;

        [BsonElement("nombre")]
        [BsonRepresentation(BsonType.String)]
        public string Nombre { get; set; } = string.Empty;

        [BsonElement("correo_electronico")]
        [BsonRepresentation(BsonType.String)]
        public string CorreoElectronico { get; set; } = string.Empty;

        [BsonElement("clave")]
        [BsonRepresentation(BsonType.String)]
        public string Clave { get; set; } = string.Empty;

        [BsonElement("estado")]
        [BsonRepresentation(BsonType.Boolean)]
        public bool Activo { get; set; } = false;

        [BsonElement("fecha_creacion")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? FechaCreacion { get; set; }
    }
}