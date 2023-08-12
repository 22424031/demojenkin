using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace acme.Bookstore.Web;

[Dependency(ReplaceServices = true)]
public class BookstoreBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Bookstore";
}
