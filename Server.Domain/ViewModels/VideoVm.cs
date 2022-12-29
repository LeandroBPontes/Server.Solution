namespace Server.Domain.ViewModels;

public class VideoVm
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public decimal SizeInBytes { get; set; }
}