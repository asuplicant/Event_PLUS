using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Events_PLUS.Domains
{
    public class Usuarios
    {
        [Key]
        public Guid IDUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome do usuário é obrigatório!")]
        public string? NomeUsuario { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Email do usuário é obrigatório!")]
        public string? Email { get; set; }


        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "A senha deve conter entre 5 e 30 caracteres.")]
        public string? Senha { get; set; }

        //referência para a entidade TiposUsuarios
        [Required(ErrorMessage = "O tipo do usuário é obrigatório!")]
        public Guid IDTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TipoUsuarios? TipoUsuario { get; set; }
    }
}