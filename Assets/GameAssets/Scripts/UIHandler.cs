using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AmayaKids
{
    public class UIHandler : MonoBehaviour, IUIHandler
    {
        [SerializeField] private Text taskText;
        [SerializeField] private Image fadeScreen;
        [SerializeField] private Image loadScreen;
        [SerializeField] private Button restartBtn;
        private IEffectService effectService;
        private ISessionHandler sessionHandler;
        public void Initialize(IEffectService _effectService, ISessionHandler _sessionHandler)
        {
            effectService = _effectService;
            sessionHandler = _sessionHandler;
            restartBtn.onClick?.AddListener(OnRestartButtonClicked);
        }
        public void ShowTask(string _task)
        {
            fadeScreen.gameObject.SetActive(false);
            loadScreen.gameObject.SetActive(false);
            restartBtn.gameObject.SetActive(false);
            effectService.Fade(taskText, 1, 2);
            taskText.text = $"Find {_task}";
        }
        public void ShowGameEnd()
        {
            fadeScreen.gameObject.SetActive(true);
            effectService.Fade(fadeScreen, 0.7f, 1.4f);
            restartBtn.gameObject.SetActive(true);
        }
        public void ShowLoadScreen()
        {
            restartBtn.gameObject.SetActive(false);
            loadScreen.gameObject.SetActive(true);
            effectService.Fade(loadScreen, 2, 2);
        }
        public void OnRestartButtonClicked()
        {
            ShowLoadScreen();
            sessionHandler.GameRestart();
        }
    }
}
