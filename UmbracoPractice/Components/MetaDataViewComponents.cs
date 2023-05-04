using Microsoft.AspNetCore.Mvc;
using TestProject.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace TestProject.Components
{
    [ViewComponent(Name = "MetaData")]
    public class MetaDataViewComponents : ViewComponent
    {
        public IViewComponentResult Invoke(IPublishedContent content, Settings settings)
        {
            var metadata = new MetaDataViewModel
            {
                Title = content.Value<string>("pageTitle"),
                Description = content.Value<string>("metaDataDescription"),
                Keywords = string.Join(", ", content.Value<string[]>("metaDataKeywords"))
            };
            if (string.IsNullOrWhiteSpace(metadata.Title))
            {
                metadata.Title = settings.PageTitle;
            }
            if (string.IsNullOrWhiteSpace(metadata.Description))
            {
                metadata.Description = settings.MetaDataDescription;
            }
            if (string.IsNullOrWhiteSpace(metadata.Keywords))
            {
                metadata.Keywords = string.Join(",", settings.MetaDataKeywords);
            }
            // ReSharper disable once Mvc.ViewComponentViewNotResolved
            return View(metadata);
        }
    }
}
