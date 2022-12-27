using System.ComponentModel.DataAnnotations;

namespace Server.Domain.AppServices.Commands;

public class CreateServerCommand
{
    [Required] public int IpPort { get; set; }

    [Required] public string IpAddress { get; set; }

    [Required] public string Name { get; set; }

    [Required] public string Role { get; set; }
}