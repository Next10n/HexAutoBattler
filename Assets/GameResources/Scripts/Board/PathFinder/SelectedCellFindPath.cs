using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Поиск пути для двух выбранных точек
    /// </summary>
    public class SelectedCellFindPath : MonoBehaviour
    {
        public event Action<List<PathElement>> OnFindPath = delegate{};

        [SerializeField] private CellSelector cellSelector;

        private void Awake()
        {
            cellSelector.OnCelectCell += TryFindPath;
        }

        private void TryFindPath(HexCell hexCell)
        {
            if(cellSelector.SelectedCells.Count == 2)
            {
                OnFindPath(PathFinder.FindPath(cellSelector.SelectedCells[0], cellSelector.SelectedCells[1]));
            }
        }


        private void OnDestroy()
        {
            cellSelector.OnCelectCell -= TryFindPath;
        }

    }
}