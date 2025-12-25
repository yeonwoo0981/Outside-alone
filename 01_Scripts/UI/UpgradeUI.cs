using DG.Tweening;
using Member.KYM.Code.Bus;
using Member.KYM.Code.GameEvents;
using Member.KYM.Code.Manager;
using Member.KYM.Code.Manager.Level;
using UnityEngine;
using UnityEngine.UI;
using Sequence = DG.Tweening.Sequence;

namespace Member.SYW._01_Scripts.UI
{
    public class UpgradeUI : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Image panel1;
        [SerializeField] private Image panel2;
        [SerializeField] private Image panel3;
        [SerializeField] private Image panel4;

        [Header("Settings")]
        [SerializeField] private float animationDuration = 0.5f;
        [SerializeField] private float slideOffset = 1000f;
        [SerializeField] private CanvasGroup canvasGroup;
        
        private Sequence _animSeq;
        
        private Vector2 _p1Origin, _p2Origin, _p3Origin, _p4Origin;

        [SerializeField] private Image image;
        private Material _material;

        private void Awake()
        {
            _material = image.material;
            _p1Origin = panel1.rectTransform.anchoredPosition;
            _p2Origin = panel2.rectTransform.anchoredPosition;
            _p3Origin = panel3.rectTransform.anchoredPosition;
            _p4Origin = panel4.rectTransform.anchoredPosition;
        }

        public void Show()
        {
            gameObject.SetActive(true);
            canvasGroup.blocksRaycasts = true;
            
            panel1.rectTransform.anchoredPosition = _p1Origin + new Vector2(-slideOffset, 0);
            panel2.rectTransform.anchoredPosition = _p2Origin + new Vector2(-slideOffset, 0);
            
            panel3.rectTransform.anchoredPosition = _p3Origin + new Vector2(slideOffset, 0);
            panel4.rectTransform.anchoredPosition = _p4Origin + new Vector2(slideOffset, 0);

            if (_animSeq != null && _animSeq.IsActive()) _animSeq.Kill();
            _animSeq = DOTween.Sequence().SetUpdate(true);

            _animSeq.Join(panel1.rectTransform.DOAnchorPos(_p1Origin, animationDuration).SetEase(Ease.OutBack));
            _animSeq.Join(panel2.rectTransform.DOAnchorPos(_p2Origin, animationDuration).SetEase(Ease.OutBack));
            _animSeq.Join(panel3.rectTransform.DOAnchorPos(_p3Origin, animationDuration).SetEase(Ease.OutBack));
            _animSeq.Join(panel4.rectTransform.DOAnchorPos(_p4Origin, animationDuration).SetEase(Ease.OutBack));

            TimeManager.Instance.TimeStop();
        }

        public void Choose(int index)
        {
            if (PlayerPrefs.GetInt("UpgradePoint") == 0) return;
            Debug.Log(index);
            
            UpgradeManager.Instance.PlusPoint(-1);
            
            switch (index)
            {
                case 0:
                    EventBus<WeaponUpgradeEvent>.Raise(new WeaponUpgradeEvent(UpgradeType.Damage));
                    break;
                case 1:
                    EventBus<WeaponUpgradeEvent>.Raise(new WeaponUpgradeEvent(UpgradeType.Speed));
                    break;
                case 2:
                    EventBus<WeaponUpgradeEvent>.Raise(new WeaponUpgradeEvent(UpgradeType.Reload));
                    break;
                case 3:
                    EventBus<WeaponUpgradeEvent>.Raise(new WeaponUpgradeEvent(UpgradeType.Ammo));
                    break;
            }
        }

        public void Exit()
        {
            canvasGroup.blocksRaycasts = false;
            PlayExitAnimation();
        }

        public void UpgradeEffect()
        {
            _material.DOFloat(1f, "_RainbowFade", 0.5f)
                .SetUpdate(true)
                .OnComplete(() =>
                {
                    _material.DOFloat(0f, "_RainbowFade", 0.5f)
                        .SetUpdate(true);
                });
        }
        
        private void PlayExitAnimation()
        {
            if (_animSeq != null && _animSeq.IsActive()) _animSeq.Kill();
            
            _animSeq = DOTween.Sequence().SetUpdate(true);
            
            _animSeq.Join(panel1.rectTransform.DOAnchorPos(_p1Origin + new Vector2(-slideOffset, 0), animationDuration).SetEase(Ease.InBack));
            _animSeq.Join(panel2.rectTransform.DOAnchorPos(_p2Origin + new Vector2(-slideOffset, 0), animationDuration).SetEase(Ease.InBack));
            _animSeq.Join(panel3.rectTransform.DOAnchorPos(_p3Origin + new Vector2(slideOffset, 0), animationDuration).SetEase(Ease.InBack));
            _animSeq.Join(panel4.rectTransform.DOAnchorPos(_p4Origin + new Vector2(slideOffset, 0), animationDuration).SetEase(Ease.InBack));
            
            _animSeq.OnComplete(ChooseComplete);
        }
        
        private void ChooseComplete()
        {
            if (_animSeq != null) _animSeq.Kill();

            TimeManager.Instance.TimeStart();
            canvasGroup.blocksRaycasts = true;
            gameObject.SetActive(false);
        }
    }
}