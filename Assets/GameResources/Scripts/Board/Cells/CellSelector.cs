using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Скрипт селектящий клетки
    /// </summary>
    public class CellSelector : MonoBehaviour
    {
        public event Action<HexCell> OnCelectCell = delegate { };

        [SerializeField] private BoardController boardController;
        [SerializeField] private int maxSelectedCells = 2;

        private List<HexCell> selectedCell = new List<HexCell>();

        public List<HexCell> SelectedCells => selectedCell;

        private void Start()
        {
            CellClickHandler.OnCellClicked += SelectCell;
        }

        private void OnDestroy()
        {
            CellClickHandler.OnCellClicked -= SelectCell;
        }

        public void UnselectAll()
        {
            while (selectedCell.Count > 0)
            {
                HexCell current = selectedCell[0];
                selectedCell.RemoveAt(0);
                current.Selector.UnSelect();
            }
        }

        private void SelectCell(HexCell hexCell)
        {
            if(selectedCell.Count >= maxSelectedCells)
            {
                HexCell current = selectedCell[0];
                selectedCell.RemoveAt(0);
                current.Selector.UnSelect();
            }
            hexCell.Selector.Select();
            selectedCell.Add(hexCell);
            OnCelectCell(hexCell);
        }


    }
}
