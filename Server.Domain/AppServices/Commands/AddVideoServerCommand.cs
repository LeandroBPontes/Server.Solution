namespace Server.Domain.AppServices.Commands;

public class AddVideoServerCommand
{
    public string Description { get; set; }

    public decimal SizeInBytes { get; set; }
}