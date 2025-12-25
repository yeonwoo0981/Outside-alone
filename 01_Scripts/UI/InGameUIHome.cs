using DG.Tweening;
using Member.SYW._01_Scripts.Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Member.SYW._01_Scripts.UI
{
    public class InGameUIHome : MonoSingleton<InGameUIHome>
    {
        [SerializeField] private GameUIManager gameUIManager;
        private RectTransform _rectTransform;
        private EditPanel _editPanel;
        private float _originTransform;
        private float _targetTransform;

        protected override void Awake()
        {
            base.Awake();
            _editPanel = EditPanel.Instance;
            _rectTransform = GetComponent<RectTransform>();
            _originTransform = _rectTransform.anchoredPosition.x;
            _targetTransform = _originTransform + 460;
        }

        private void OnEnable()
        {
            gameUIManager.OnEscOpen += AppearanceUI;
            gameUIManager.OnEscClose += UnAppearanceUI;
        }

        private void AppearanceUI()
        {
            _rectTransform.DOKill();
            _rectTransform.DOAnchorPosX(_targetTransform, 0.75f)
                .SetUpdate(true);
        }

        private void UnAppearanceUI()
        {
            _rectTransform.DOKill();
            _rectTransform.DOAnchorPosX(_originTransform, 0.75f)
                .SetUpdate(true);
            _editPanel.gameObject.SetActive(false);
        }

        public void EditPanelOpen()
        {
            _editPanel.gameObject.SetActive(true);
        }

        public void GoTitle()
        {
            SceneManager.LoadScene("Title");
            TimeManager.Instance.TimeStart();
        }

        public void Restart()
        {
            gameUIManager.ResumeGame();
        } 
        
        private void OnDisable()
        {
            gameUIManager.OnEscOpen -= AppearanceUI;
            gameUIManager.OnEscClose -= UnAppearanceUI;
        }
    }
}