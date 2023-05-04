using Microsoft.AspNetCore.Mvc;
using NUglify.Helpers;
using TestProject.Extensions;
using TestProject.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace TestProject.Components;

[ViewComponent(Name = "Footer")]
public class FooterViewComponent : ViewComponent
{
    private readonly ILocalizationService _localizationService;

    public FooterViewComponent(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
    }

    public IViewComponentResult Invoke(Settings settings, IPublishedContent page)
    {
        var currentCulture = Thread.CurrentThread.CurrentCulture;
        var availableLanguages = _localizationService.GetAllLanguages().Where(l => page.Cultures.Keys.Contains(l.IsoCode));

        var currentLanguage = availableLanguages.GetLanguageFromIsoCode(currentCulture.Name);

        var languagesAndRedirectUrls = new Dictionary<string, string>();
        page.Cultures.Where(c => c.Key.ToLower() != currentCulture.Name.ToLower()).ForEach(x =>
        {
            var culture = x.Key;
            var language = availableLanguages.GetLanguageFromIsoCode(culture);
            var url = page.Url(culture);

            languagesAndRedirectUrls.Add(language, url);
        });

        var model = new FooterViewModel
        {
            LogoText = !string.IsNullOrWhiteSpace(settings.FooterLogoText) ? settings.FooterLogoText : settings.LogoText,
            Description = settings.FooterDescriprion,
            CurrentLanguage = currentLanguage,
            LanguagesAndRedirectUrls = languagesAndRedirectUrls
        };

        // ReSharper disable once Mvc.ViewComponentViewNotResolved
        return View(model);
    }
}
