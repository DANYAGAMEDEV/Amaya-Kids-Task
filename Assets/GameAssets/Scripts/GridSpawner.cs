using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmayaKids
{
    public class GridSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject cellPrefab;
        private IEffectService effectService;

        public void Initialize(IEffectService _effectService) => effectService = _effectService;
        public List<Cell> CreateGrid(int _rows, int _columns)
        {
            ClearGrid();
            List<Cell> cells = new List<Cell>();

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    GameObject cellObject = Instantiate(cellPrefab, transform);
                    Cell cell = cellObject.GetComponent<Cell>();
                    cells.Add(cell);
                    Vector2 size = cell.GetSize();
                    float gridWidth = _columns * size.x;
                    float gridHeight = _rows * size.y;
                    Vector2 offset = new Vector2(-gridWidth / 2 + size.x / 2, -gridHeight / 2 + size.y / 2);
                    Vector2 position = new Vector2(j * size.x, i * size.y) + offset;
                    cellObject.transform.localPosition = position;
                    cellObject.name = "Cell_" + i + "_" + j;
                    effectService.Bounce(cellObject);
                }
            }
            void ClearGrid()
            {
                foreach (Transform child in transform) Destroy(child.gameObject);
            }

            return cells;
        }
    }
}

