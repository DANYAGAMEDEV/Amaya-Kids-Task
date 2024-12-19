using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmayaKids
{
    public interface IUIHandler
    {
        void Initialize(IEffectService effectHandler, ISessionHandler _sessionHandler);
        void ShowTask(string task);
        void ShowGameEnd();
        void ShowLoadScreen();
        void OnRestartButtonClicked();
    }
}
