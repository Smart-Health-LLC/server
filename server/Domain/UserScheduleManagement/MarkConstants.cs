namespace server.Domain.UserScheduleManagement;

public abstract class MarkConstants
{
    public const int MaxLevel = 5;
    public const int MinLevel = 1;
    public static readonly int[] Values = [MinLevel, 2, 3, 4, MaxLevel];
}
