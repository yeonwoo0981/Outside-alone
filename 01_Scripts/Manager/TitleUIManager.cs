using Member.SYW._01_Scripts.UI;
using TMPro;
using UnityEngine;

namespace Member.SYW._01_Scripts.Manager
{
    public class TitleUIManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI creditText;
        [SerializeField] private RectTransform originTransform;
        private EditPanel _editPanel;
        private bool _creditIsOpen = false;

        private void Awake()
        {
            _editPanel = EditPanel.Instance;
        }

        private void Start()
        {
            SoundManager.Instance.Play(BGMSoundType.MAINBGM, 1f);
            creditText.gameObject.SetActive(false);
        }

        public void EditCredit()
        {
            if (!_creditIsOpen)
            {
                creditText.gameObject.SetActive(true);
                _creditIsOpen = true;
            }
            else if (_creditIsOpen)
            {
                creditText.gameObject.SetActive(false);
                _creditIsOpen = false;
            }
        }

        public void EscPanelOpen()
        {
            _editPanel.gameObject.SetActive(true);
        }
        
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}