using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace AmayaKids
{
    public class Cell : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image image;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private string item;
        public string Item => item;
        private Action<Cell> onCellClicked; 

        public Vector2 GetSize()
        {
            Vector2 size = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
            return size;
        }
        public void SetCell(DataSetSO.Slot _dataSetSlot, Action<Cell> clickAction)
        {
            image.sprite = _dataSetSlot.Sprite;
            rectTransform.Rotate(0, 0, _dataSetSlot.SpriteRotation);
            item = _dataSetSlot.Item;
            onCellClicked = clickAction;
        }
        public void OnPointerClick(PointerEventData eventData) => onCellClicked?.Invoke(this);
    }
}


