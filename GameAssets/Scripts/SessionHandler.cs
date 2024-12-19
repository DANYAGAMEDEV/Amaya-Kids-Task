using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmayaKids
{
    public class SessionHandler : MonoBehaviour, ISessionHandler
    {
        private LevelSetupSO levelSetup;
        private DataSetsContainerSO dataSets—ontainer;
        private GridSpawner gridSpawner;
        private IUIHandler uIHandler;
        private IEffectService effectService;

        public int currentLevel, maxLevel;
        public string correctAnswer;
        private List<string> usedAnswers = new List<string>();
        private const float invokeTimeDelay = 2f;

        public void Initialize(IUIHandler _uIHandler, IEffectService _effectService, GridSpawner _gridSpawner, LevelSetupSO _levelSetup, DataSetsContainerSO _dataSets—ontainer)
        {
            uIHandler = _uIHandler;
            effectService = _effectService;
            gridSpawner = _gridSpawner;
            levelSetup = _levelSetup;
            dataSets—ontainer = _dataSets—ontainer;
        }
        public void GameStart()
        {
            LevelGenerator levelGenerator = new LevelGenerator(gridSpawner, levelSetup, dataSets—ontainer, currentLevel, usedAnswers);
            (maxLevel, correctAnswer) =  levelGenerator.GenerateLevel(OnCellClicked);
            uIHandler.ShowTask(correctAnswer);
        }
        public void OnCellClicked(Cell _cell)
        {
            string answer = _cell.Item;

            if (CheckAnswer(answer))
            {
                effectService.Bounce(_cell.gameObject);
                effectService.CorrectAnswerEffect(_cell.gameObject);
                if (this != null) Invoke("SwitchLevel", invokeTimeDelay);
            }
            else
            {
                effectService.EaseInBounce(_cell.gameObject);
            }
            bool CheckAnswer(string _answer) => answer == correctAnswer;
        }
        public void SwitchLevel()
        {
            if (currentLevel < maxLevel)
            {
                currentLevel += 1;
                GameStart();
            }
            else GameEnd();  
        }
        public void GameEnd()
        {
            uIHandler.ShowGameEnd();
        }
        public void GameRestart()
        {
            currentLevel = 0;
            Invoke("GameStart", invokeTimeDelay);
        }

    }

}
