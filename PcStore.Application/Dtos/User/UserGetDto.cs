namespace PcStore.Application.Dtos.User;

public class UserGetDto
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Correo { get; set; }
    public string? Telefono { get; set; }
    public int? IsAdmin { get; set; }
    public string? Password { get; set; }
    public DateTime FechaCreacion { get; set; }
}