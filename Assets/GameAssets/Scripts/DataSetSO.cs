using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmayaKids
{
    [CreateAssetMenu(fileName = "DataSet_", menuName = "Game/DataSets")]
    public class DataSetSO : ScriptableObject
    {
        public DataSet dataSet;

        [System.Serializable]
        public class DataSet
        {
            public List<Slot> Slots = new List<Slot>();
        }

        [System.Serializable]
        public class Slot
        {
            [SerializeField] private string _item;
            [SerializeField] private Sprite _sprite;
            [SerializeField] private int _spriteRotation;
            public string Item => _item;
            public Sprite Sprite => _sprite;
            public int SpriteRotation => _spriteRotation;
        }
    }
}

