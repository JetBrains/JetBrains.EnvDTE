using EnvDTE;
using JetBrains.Annotations;
using JetBrains.Rider.Model;

namespace JetBrains.EnvDTE.Client.Util
{
    public static class SupportedLanguageUtils
    {
        public static bool IsSupported([CanBeNull] string language) =>
            language == CodeModelLanguageConstants.vsCMLanguageCSharp;

        [CanBeNull]
        public static string ToEnvDTELanguage(this LanguageModel model) => model switch
        {
            LanguageModel.CSharp => CodeModelLanguageConstants.vsCMLanguageCSharp,
            LanguageModel.VB => CodeModelLanguageConstants.vsCMLanguageVB,
            _ => null
        };
    }
}
