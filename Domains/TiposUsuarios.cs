using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Events_PLUS.Domains
{
    [Table("TiposUsuarios")]
    public class TiposUsuarios
    {
        // Implementando a ForeignKEY TipoUsuarioId
        [Key]
        public Guid TipoUsuarioID { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O titulo de usuario é ")]
        public string? TituloTipoUsuario { get; set; }
    }
}

