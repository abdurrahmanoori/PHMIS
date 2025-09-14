using System.Globalization;

namespace PHMIS.Application.Common.Localization
{
    public static class TranslationSelector
    {
        // Picks the best language code from available ones based on requested culture
        public static string? PickLanguage(IEnumerable<string> languages, string? requested)
        {
            if (languages == null) return null;
            var langs = languages.ToList();
            if (!langs.Any()) return null;

            if (!string.IsNullOrWhiteSpace(requested))
            {
                // Exact match first
                var exact = langs.FirstOrDefault(l => string.Equals(l, requested, StringComparison.OrdinalIgnoreCase));
                if (exact != null) return exact;

                // Primary language fallback (e.g., fa from fa-AF)
                try
                {
                    var culture = new CultureInfo(requested);
                    var primary = culture.TwoLetterISOLanguageName;
                    var primaryMatch = langs.FirstOrDefault(l => string.Equals(l, primary, StringComparison.OrdinalIgnoreCase));
                    if (primaryMatch != null) return primaryMatch;
                }
                catch { }
            }
            // Nothing matched -> return first
            return langs[0];
        }
    }
}
