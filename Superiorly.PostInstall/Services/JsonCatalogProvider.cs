using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Superiorly.PostInstall.Models;

namespace Superiorly.PostInstall.Services;

public sealed class JsonCatalogProvider : ICatalogProvider
{
    private static readonly JsonSerializerOptions Options = new() { PropertyNameCaseInsensitive = true };
    private static readonly UTF8Encoding NoBom = new(false);

    public CatalogDefinition Load()
    {
        var baseDir = AppContext.BaseDirectory;
        var actionsPath = Path.Combine(baseDir, "data", "actions.json");
        var tipsPath = Path.Combine(baseDir, "data", "tooltips.json");

        CatalogDefinition catalog;
        if (File.Exists(actionsPath))
        {
            catalog = LoadCatalog(File.ReadAllBytes(actionsPath));
        }
        else
        {
            var asm = Assembly.GetExecutingAssembly();
            using var stream = asm.GetManifestResourceStream("Superiorly.PostInstall.data.actions.json")
                ?? throw new InvalidOperationException("actions.json not found (neither on disk nor embedded)");
            using var ms = new MemoryStream();
            stream.CopyTo(ms);
            catalog = LoadCatalog(ms.ToArray());
        }

        if (File.Exists(tipsPath))
        {
            var tipsJson = File.ReadAllText(tipsPath);
            var tooltips = JsonSerializer.Deserialize<Dictionary<string, BrowserTip>>(tipsJson, Options);
            if (tooltips != null) catalog.Tooltips = tooltips;
        }
        else
        {
            var asm = Assembly.GetExecutingAssembly();
            using var tips = asm.GetManifestResourceStream("Superiorly.PostInstall.data.tooltips.json");
            if (tips != null)
            {
                var tooltips = JsonSerializer.Deserialize<Dictionary<string, BrowserTip>>(tips, Options);
                if (tooltips != null) catalog.Tooltips = tooltips;
            }
        }

        return catalog;
    }

    private static CatalogDefinition LoadCatalog(byte[] raw)
    {
        var node = JsonNode.Parse(DecodeCatalog(raw))
            ?? throw new InvalidOperationException("actions.json is empty or invalid");
        return node.Deserialize<CatalogDefinition>(Options) ?? new CatalogDefinition();
    }

    // ponytail: editors save UTF-16 by default; sniff the BOM so a wrong encoding never bricks startup
    private static string DecodeCatalog(byte[] raw)
    {
        string s;
        if (raw.Length >= 2 && raw[0] == 0xFF && raw[1] == 0xFE)
            s = Encoding.Unicode.GetString(raw);
        else if (raw.Length >= 2 && raw[0] == 0xFE && raw[1] == 0xFF)
            s = Encoding.BigEndianUnicode.GetString(raw);
        else if (raw.Length >= 3 && raw[0] == 0xEF && raw[1] == 0xBB && raw[2] == 0xBF)
            s = Encoding.UTF8.GetString(raw, 3, raw.Length - 3);
        else
            s = NoBom.GetString(raw);
        return s.Length > 0 && s[0] == '﻿' ? s.Substring(1) : s;
    }
}
