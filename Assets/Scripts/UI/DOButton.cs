using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class DoButton : Button
    {
        [SerializeField] private Vector3 _targetScale;
        [SerializeField] [Range(0, 1)] private float _duration;
        
        private Vector3 _startScale;

        protected override void Awake()
        {
            base.Awake();
            _startScale = transform.localScale;
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            transform.DOScale(_targetScale, _duration);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            transform.DOScale(_startScale, _duration);
        }
    }
}
