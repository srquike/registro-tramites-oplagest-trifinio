using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RegistroTramitesOplagestTrifinio.Models
{
    public class Instructivo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InstructivoId { get; set; } = string.Empty;

        [BsonElement("numero")]
        [BsonRepresentation(BsonType.Int32)]
        public int Numero { get; set; }

        [BsonElement("nombre")]
        [BsonRepresentation(BsonType.String)]
        public string Nombre { get; set; } = string.Empty;
    }
}
