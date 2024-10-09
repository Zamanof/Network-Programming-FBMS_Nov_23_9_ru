namespace NP_03._TCP_Task_Manager__client_side_;

internal class Command
{
    public const string ProcessList = "PROCLIST";
    public const string Kill = "KILL";
    public const string Run = "RUN";
    public string? Text { get; set; }
    public string? Param { get; set; }
}
