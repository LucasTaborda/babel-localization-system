using UnityEngine;

namespace Localization
{
    public class LocalizationManager : MonoBehaviour
    {
        public enum Language { english, spanish };

        [SerializeField] private TextAsset[] _languages;

        private static XMLParser _xmlParser;

        public Language currentLanguage;


        private void Awake()
        {
            _xmlParser = new XMLParser(GetLanguageFile(currentLanguage));
        }


        private TextAsset GetLanguageFile(Language lang)
        {
            return _languages[(int)lang];
        }


        private void Translate()
        {
            var localizables = FindObjectsOfType<LocalizableText>(true);

            foreach (var localizable in localizables)
            {
                localizable.Refresh();
            }
        }


        public static string GetText(string tag)
        {
            return _xmlParser.ObtainNode(tag);
        }


        public void ChangeLanguage(Language language)
        {
            currentLanguage = language;
            _xmlParser.LoadXML(GetLanguageFile(currentLanguage));
            Translate();
        }


    }
}

