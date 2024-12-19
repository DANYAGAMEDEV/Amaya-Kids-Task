using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace AmayaKids
{
    public class EffectService : IEffectService
    {
        private GameObject correctAnswerEffect;
        public void Initialize(GameObject _correctAnswerEffect)
        {
            correctAnswerEffect = _correctAnswerEffect;
        }
        public void Bounce(GameObject _tergetObject)
        {
            Tween BounceAnimation(float _scale)
            {
                return _tergetObject.transform.DOScale(Vector3.one * _scale, 0.8f).SetEase(Ease.InOutSine);
            }
            Sequence bounceSequence = DOTween.Sequence();
            bounceSequence.Append(BounceAnimation(1.2f))
                          .Append(BounceAnimation(0.8f))
                          .Append(BounceAnimation(1f));
        }
        public void EaseInBounce(GameObject _tergetObject) => _tergetObject.transform.DOShakePosition(0.5f, new Vector3(10, 0, 0), 10, 90, false, true).SetEase(Ease.InBounce);
        public void Fade<T>(T target, float targetAlpha, float duration) where T : Graphic
        {
            target.DOFade(targetAlpha, duration).SetEase(Ease.InQuad);
        }
        public void CorrectAnswerEffect(GameObject _tergetObject)
        {
            if (correctAnswerEffect != null)
            {
                GameObject effectObject = Object.Instantiate(correctAnswerEffect, _tergetObject.transform.position, Quaternion.identity);
                effectObject.transform.SetParent(_tergetObject.transform);
            }
        }
    }
}

