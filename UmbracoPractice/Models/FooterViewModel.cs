using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace TestProject.Models
{
    public class FooterViewModel
    {
        public string LogoText { get; set; }
        public IHtmlEncodedString Description { get; set; }
        public string CurrentLanguage { get; set; }
        public Dictionary<string, string> LanguagesAndRedirectUrls { get; set; }
        public IEnumerable<NavigationItem> NavigationItems { get; set; }
    }
}
