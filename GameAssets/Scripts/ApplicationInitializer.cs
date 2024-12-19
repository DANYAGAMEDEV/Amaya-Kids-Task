using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmayaKids
{
    public class ApplicationInitializer : MonoBehaviour
    {
        [SerializeField] private UIHandler uiHandler;
        [SerializeField] private GridSpawner gridSpawner;
        [SerializeField] private LevelSetupSO levelSetup;
        [SerializeField] private DataSetsContainerSO dataSets—ontainer;
        [SerializeField] private GameObject correctAnswerEffect;

        private SessionHandler sessionHandler;
        private IEffectService effectService;

        private void Awake()
        {
            effectService = new EffectService();
            sessionHandler = gameObject.AddComponent<SessionHandler>();

            sessionHandler.Initialize(uiHandler, effectService, gridSpawner, levelSetup, dataSets—ontainer);
            uiHandler.Initialize(effectService, sessionHandler);
            gridSpawner.Initialize(effectService);
            effectService.Initialize(correctAnswerEffect);

            sessionHandler.GameStart();
        }
    }
}
