using Umbraco.Cms.Core.Strings;

namespace TestProject.Models
{
    public class FooterViewModel
    {
        public string LogoText { get; set; }
        public IHtmlEncodedString SomeFooterProp { get; set; }
    }
}
