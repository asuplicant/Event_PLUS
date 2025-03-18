using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Events_PLUS.Domains
{
    [Table("PresencaEventos")]
    public class PresencasEventos
    {
        [Key]
        public Guid IdPresenca { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "A presença é obrigatório!")]
        public string? Presenca { get; set; }

        public Guid IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuarios? IdUsuarios { get; set; }

        public Guid IdEvento { get; set; }

        [ForeignKey("IdEvento")]
        public Eventos? Evento { get; set; }
    }
}
