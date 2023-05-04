using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace TestProject.Components;

[ViewComponent(Name = "Header")]
public class HeaderViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Settings settings)
    {
        var model = new HeaderViewModel
        {
            LogoText = settings?.LogoText,
            NavigationItems = settings?.HeaderNavigation.Select(x => x.Content).OfType<NavigationItem>()
        };

        // ReSharper disable once Mvc.ViewComponentViewNotResolved
        return View(model);
    }
}
