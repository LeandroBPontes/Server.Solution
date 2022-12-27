using System.ComponentModel;

namespace Server.Domain.Enums;

public enum EStatus
{
    [Description("Running")] Running = 1,

    [Description("Not Running")] NotRunning = 2,
}