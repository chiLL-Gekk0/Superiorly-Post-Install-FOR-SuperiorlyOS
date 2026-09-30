using Superiorly.PostInstall.Models;

namespace Superiorly.PostInstall.Services;

public interface ICatalogProvider
{
    CatalogDefinition Load();
}
