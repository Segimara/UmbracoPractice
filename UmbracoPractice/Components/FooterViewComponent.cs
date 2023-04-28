using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace TestProject.Components;

[ViewComponent(Name = "Footer")]
public class FooterViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Settings settings)
    {
        var model = new FooterViewModel
        {
            LogoText = settings.LogoText,
            SomeFooterProp = settings.SomeFooterProperty
        };
        return View(model);
    }
}
