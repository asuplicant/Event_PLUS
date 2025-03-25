using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events_PLUS.Domains
{
    [Table("Presenca")]
    public class Presenca
    {
        [Key]
        public Guid PresencaID { get; set; }

        public Guid EventoID { get; set; }
        [ForeignKey("EventoID")]
        public Evento? Evento { get; set; }

        public Guid UsuarioID { get; set; }

        [ForeignKey("UsuarioID")]
        public Usuarios? Usuario { get; set; }

        [Column(TypeName = "BIT")]
        public bool? Situacao { get; set; }

    }
}