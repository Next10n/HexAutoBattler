using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleSystem
{

    /// <summary>
    /// Выбор клетки
    /// </summary>
    public class CellSelectHandler : MonoBehaviour
    {
        public event Action<bool> OnSelectCell;

        public bool Selected { get; private set; }

        public void Select()
        {
            Selected = true;
            OnSelectCell(true);
        }
        
        public void UnSelect()
        {
            Selected = false;
            OnSelectCell(false);
        }
    }
}