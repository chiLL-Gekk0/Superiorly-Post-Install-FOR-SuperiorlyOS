namespace Superiorly.PostInstall.Models;

public sealed class BrowserTip
{
    public Dictionary<string, string> Controversy { get; set; } = new();
    public Dictionary<string, string> Data { get; set; } = new();
    public int Security { get; set; }
}

public sealed class ActionItem
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Icon { get; set; } = "";
    public string Logo { get; set; } = "";
    public string Tab { get; set; } = "";
    public string Type { get; set; } = "";
    public List<ActionOption> Options { get; set; } = new();

    // every command exiting 0 means the action is currently on
    public List<string> Check { get; set; } = new();

    // commands to launch the program when it is already installed
    public List<string> Launch { get; set; } = new();

    public BrowserTip? Tip { get; set; }
    public string Info { get; set; } = "";
}

public sealed class TabDefinition
{
    public string Id { get; set; } = "";
    public string Title { get; set; } = "";
}

public sealed class ActionOption
{
    public string Label { get; set; } = "";
    public List<string> Commands { get; set; } = new();
}

public sealed class SectionDefinition
{
    public string Id { get; set; } = "";
    public string Icon { get; set; } = "";
    public List<TabDefinition> Tabs { get; set; } = new();
    public List<ActionItem> Actions { get; set; } = new();
}

public sealed class CatalogDefinition
{
    public string Name { get; set; } = "Superiorly Post-Install";
    public List<SectionDefinition> Sections { get; set; } = new();
    public Dictionary<string, int> Tooltips { get; set; } = new();
}
