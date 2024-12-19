using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmayaKids
{
    [CreateAssetMenu(fileName = "LevelSetup", menuName = "Game/LevelSetup")]
    public class LevelSetupSO : ScriptableObject
    {
        public LevelSet levelSet;

        [System.Serializable]
        public class LevelSet
        {
            public List<Slot> Slots = new List<Slot>();
        }

        [System.Serializable]
        public class Slot
        {
            [SerializeField] private int _rows;
            [SerializeField] private int _columns;
            public int Rows => _rows;
            public int Columns => _columns;
        }
    }

}
