using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Обработчик клика на клетку
    /// </summary>
    [RequireComponent(typeof(HexCell))]
    public class CellClickHandler : MonoBehaviour
    {
        public static event Action<HexCell> OnCellClicked = delegate { };

        private HexCell _hexCell;

        private void Awake()
        {
            _hexCell = GetComponent<HexCell>();
        }

        private void OnMouseDown()
        {
            OnCellClicked(_hexCell);
        }
    }
}