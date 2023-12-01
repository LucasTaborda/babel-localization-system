using TMPro;
using UnityEngine;

namespace Localization
{
    public class LocalizableText : MonoBehaviour
    {
        private TMP_Text tmp;
        public string textTag;
        public bool loadOnStart = true;


        private void SetTMP()
        {
            if (tmp == null) tmp = GetComponent<TMP_Text>();
        }


        private void Awake()
        {
            SetTMP();
        }


        private void Start()
        {
            if (loadOnStart) Refresh();
        }


        public void Refresh()
        {
            SetTMP();
            tmp.text = LocalizationManager.GetText(textTag);
        }


    }
}
