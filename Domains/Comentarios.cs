using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Events_PLUS.Domains
{
    public class Comentarios
    {
        [Key]
        public Guid IdComentarioEvento { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "Descrição do comentário obrigatório!")]
        public string? Descricao { get; set; }

        [Column(TypeName = "BIT")]
        [Required]
        public bool Exibe { get; set; }

        //ref.tabela Usuario
        [Required(ErrorMessage = "Usuário obrigatório!")]
        public Guid UsuarioID { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuarios? Usuario { get; set; }

        //ref.tabela Evento
        [Required(ErrorMessage = "Evento obrigatório!")]
        public Guid EventoID { get; set; }

        [ForeignKey("IdEvento")]
        public Evento? Evento { get; set; }
    }
}
