using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Member.SYW._01_Scripts.UI
{
    public class UIHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private RectTransform _rectTransform;

        [Header("Settings")]
        [SerializeField] private float hoverWidth;
        [SerializeField] private float hoverHeight;
        [SerializeField] private float duration;

        private float _originWidth;
        private float _originHeight;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            
            _originWidth = _rectTransform.sizeDelta.x;
            _originHeight = _rectTransform.sizeDelta.y;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _rectTransform.DOKill();
            _rectTransform.DOSizeDelta(
                    new Vector2(hoverWidth, hoverHeight), duration)
                .SetEase(Ease.Flash)
                .SetUpdate(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _rectTransform.DOKill();
            _rectTransform.DOSizeDelta(
                    new Vector2(_originWidth, _originHeight), duration)
                .SetEase(Ease.Flash)
                .SetUpdate(true);
        }

        private void OnDisable()
        {
            _rectTransform.DOKill();
        }
    }
}