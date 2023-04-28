using Umbraco.Cms.Web.Common.PublishedModels;

namespace TestProject.Models
{
    public class HeaderViewModel
    {
        public string LogoText { get; set; }
        public IEnumerable<NavigationItem> NavigationItems { get; set; }
    }
}
