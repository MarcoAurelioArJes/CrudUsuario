using System.Runtime.Serialization;

namespace CadastroDeUsuario.Models
{
    [DataContract]
    public class UsuarioModel
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Telefone { get; set; }
        [DataMember]
        public string Observacao { get; set; }
    }
}
