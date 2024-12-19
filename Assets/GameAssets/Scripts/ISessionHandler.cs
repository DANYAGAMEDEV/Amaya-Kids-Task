using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmayaKids
{
    public interface ISessionHandler
    {
        void GameStart();
        void GameEnd();
        void GameRestart();
        void OnCellClicked(Cell _cell);
        void SwitchLevel();
    }
}

