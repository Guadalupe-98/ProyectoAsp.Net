using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Modelos;

public class Usuario:IdentityUser
{

    [Required]
    public string nombre { get; set; }

    [Required]
    public string apellido { get; set;}


}
