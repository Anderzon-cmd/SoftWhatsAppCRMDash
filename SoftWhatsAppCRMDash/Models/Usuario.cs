using System;
using System.Collections.Generic;

namespace SoftWhatsAppCRMDash.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellidos { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Rol { get; set; }

    public string? Imagen { get; set; }
}
