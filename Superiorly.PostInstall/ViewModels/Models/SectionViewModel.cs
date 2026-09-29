using CommunityToolkit.Mvvm.ComponentModel;

namespace Superiorly.PostInstall.ViewModels;

public partial class SectionViewModel : ObservableObject
{
    public string Id { get; init; } = "";
    public string Title { get; init; } = "";
    public string Description { get; init; } = "";
    public string Icon { get; init; } = "";
    public List<TabViewModel> Tabs { get; init; } = new();
}

public sealed class TabViewModel
{
    public string Id { get; init; } = "";
    public string Title { get; init; } = "";
}
