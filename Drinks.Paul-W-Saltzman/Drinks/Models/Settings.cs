using System;
using System.Linq;

namespace drinks_info.Models
{
    internal class Settings
    {
        internal int SettingsId { get; set; }
        internal int Version {get; set; }
        internal LanguageEnum Language { get; set; }

        internal enum LanguageEnum
        {
            [LanguageInfo("English")]
            EN,
            [LanguageInfo("German")]
            DE,
            [LanguageInfo("French")]
            FR,
            [LanguageInfo("Italian")]
            IT
        }

        [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
        sealed class LanguageInfoAttribute : Attribute
        {
            public string DisplayName { get; }

            public LanguageInfoAttribute(string displayName)
            {
                DisplayName = displayName;
            }
        }

        internal string GetLanguageDisplayName(LanguageEnum language)
        {
            var field = language.GetType().GetField(language.ToString());
            var attribute = (LanguageInfoAttribute)field.GetCustomAttributes(typeof(LanguageInfoAttribute), false).FirstOrDefault();
            return attribute?.DisplayName ?? language.ToString();
        }
    }
}
