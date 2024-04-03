namespace WowClientSwitcher.Data.Models;

public class UserSettings
{
    public string WowClientIdentifier { get; set; } = "World Of Warcraft";
    public int WindowX { get; set; } = 1;
    public int WindowY { get; set; } = 1;
    public int PaddingX { get; set; } = 20;
    public int PaddingY { get; set; } = 10;
}