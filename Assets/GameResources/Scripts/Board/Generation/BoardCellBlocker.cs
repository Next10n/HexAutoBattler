using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Блокирование клеток карты
    /// </summary>
    public class BoardCellBlocker : MonoBehaviour
    {
        [SerializeField] private BlockedCellMap[] blockedCellMaps;
        [SerializeField] private BoardController boardController;

        private void Start()
        {
            Vector2Int[] randomMap = blockedCellMaps[Random.Range(0, blockedCellMaps.Length)].blockedCells;
            foreach(Vector2Int blockedCell in randomMap)
            {
                boardController.BattleLocation.Cells[blockedCell.x-1, blockedCell.y-1].Block();
            }
        }

    }
}