using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AmayaKids
{
    public interface IEffectService
    {
        void Initialize(GameObject correctAnswerEffect);
        void Bounce(GameObject targetObject);
        void EaseInBounce(GameObject targetObject);
        void Fade<T>(T target, float targetAlpha, float duration) where T : Graphic;
        void CorrectAnswerEffect(GameObject targetObject);
    }
}
