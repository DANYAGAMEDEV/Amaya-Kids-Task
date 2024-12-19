using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmayaKids 
{
    public class LevelGenerator
    {
        private GridSpawner gridSpawner;
        private LevelSetupSO levelSetupSO;
        private DataSetsContainerSO dataSetsContainerSO;
        private int currentLevel;
        private List<string> usedAnswers;

        public LevelGenerator(GridSpawner _gridSpawner, LevelSetupSO _levelSetupSO, DataSetsContainerSO _dataSetsContainerSO, int _currentLevel, List<string> _usedAnswers)
        {
            gridSpawner = _gridSpawner;
            levelSetupSO = _levelSetupSO;
            dataSetsContainerSO = _dataSetsContainerSO;
            currentLevel = _currentLevel;
            usedAnswers = _usedAnswers;
        }

        public (int,string) GenerateLevel(System.Action<Cell> _onCellClicked)
        {
            LevelSetupSO.Slot levelSetup = SelectLevelSetup();
            List<Cell> cells = gridSpawner.CreateGrid(levelSetup.Rows, levelSetup.Columns);
            int maxLevel = levelSetupSO.levelSet.Slots.Count - 1;

            int dataSetsCount = dataSetsContainerSO.dataSets.Length;
            int randomDataSetValue = Random.Range(0, dataSetsCount);
            DataSetSO dataSetSO = SelectDataSet();
            List<string> usedSlots = new List<string>();

            for (int i = 0; i < cells.Count; i++)
            {
                DataSetSO.Slot dataSetSlot = GetRandomDataSetSlot();
                if (usedSlots.Contains(dataSetSlot.Item)) { i--; continue; }
                usedSlots.Add(dataSetSlot.Item);
                cells[i].SetCell(dataSetSlot, _onCellClicked);
            }

            string correctAnswer = SelectCorrectAnswer();
            string SelectCorrectAnswer()
            {
                while (true)
                {
                    int randomValue = Random.Range(0, usedSlots.Count);
                    string item = usedSlots[randomValue];

                    if (!usedAnswers.Contains(item)) return item;
                }
            }

            LevelSetupSO.Slot SelectLevelSetup()
            {
               return levelSetupSO.levelSet.Slots[currentLevel];
            }
            DataSetSO SelectDataSet()
            {
                return dataSetsContainerSO.dataSets[randomDataSetValue];
            }
            DataSetSO.Slot GetRandomDataSetSlot()
            {
                int value = Random.Range(0, dataSetSO.dataSet.Slots.Count);
               return dataSetSO.dataSet.Slots[value];
            }

            return (maxLevel, correctAnswer);
        }
    }

}

