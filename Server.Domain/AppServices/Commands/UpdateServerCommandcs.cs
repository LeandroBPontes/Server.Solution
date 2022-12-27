using System.ComponentModel.DataAnnotations;

namespace Server.Domain.AppServices.Commands;

public class UpdateServerCommand : CreateServerCommand
{
    [Required] public Guid Id { get; set; }
}