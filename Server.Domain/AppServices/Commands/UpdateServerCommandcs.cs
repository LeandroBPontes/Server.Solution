using System.ComponentModel.DataAnnotations;
using Server.Domain.Enums;

namespace Server.Domain.AppServices.Commands;

public class UpdateServerCommand : CreateServerCommand
{
    [Required] public Guid Id { get; set; }
    [Required] public EStatus Status { get; set; }
}