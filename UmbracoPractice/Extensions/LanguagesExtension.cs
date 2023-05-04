using Umbraco.Cms.Core.Models;

namespace TestProject.Extensions
{
    public static class LanguagesExtension
    {
        public static string GetLanguageFromIsoCode(this IEnumerable<ILanguage> languages, string isoCode)
        {
            return languages.FirstOrDefault(l => l.IsoCode.ToLower() == isoCode.ToLower())?.CultureInfo?.NativeName ?? isoCode;
        }
    }
}
