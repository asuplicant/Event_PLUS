using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events_PLUS.Domains;

[Table("TipoUsuarios")]
public class TipoUsuarios
{
    [Key]
    public Guid TipoUsuarioId { get; set; }

    [Column(TypeName = "VARCHAR(50)")]
    [Required(ErrorMessage = "O tipo do usuário é obrigatório!")]
    public string? TituloTipoUsuario { get; set; }
}