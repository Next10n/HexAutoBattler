using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Карта заблокированных клеток
    /// </summary>
    [CreateAssetMenu(fileName ="BlockedCellsMap", menuName ="BattleSystem/Board/BlockMap")]
    public class BlockedCellMap : ScriptableObject
    {
        public Vector2Int[] blockedCells;
    }
}