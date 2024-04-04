namespace WowClientSwitcher.Data.Models;

public class UserSettings
{
    public string WowClientIdentifier { get; set; } = "World Of Warcraft";
    public int PaddingX { get; set; } = 20;
    public int PaddingY { get; set; } = 10;
    public int RefreshTimeout { get; set; } = 3;
}