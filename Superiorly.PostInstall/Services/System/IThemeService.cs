namespace Superiorly.PostInstall.Services;

public interface IThemeService
{
    void Apply(string name);
    void RefreshSystem();
    void ApplyCorners(string style);
}
