using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Events_PLUS.Domains
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        public Guid FeedbackId { get; set; }

        public Guid EventoId { get; set; }
        [ForeignKey("EventoID")]
        public Evento? Evento { get; set; }


        public Guid UsuarioId { get; set; }
        [ForeignKey("UsuarioID")]
        public Usuarios? Usuario { get; set; }

        [Column(TypeName = "VARCHAR(300)")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        public bool? Exibir { get; set; }
    }
}