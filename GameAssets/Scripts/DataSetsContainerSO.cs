using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmayaKids
{
    [CreateAssetMenu(fileName = "DataSet—ontainer", menuName = "Game/DataSets—ontainer")]
    public class DataSetsContainerSO : ScriptableObject
    {
        public DataSetSO[] dataSets;
    }
}

