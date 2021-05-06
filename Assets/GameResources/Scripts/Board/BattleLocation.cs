using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleSystem
{
    /// <summary>
    /// Локация для боя
    /// </summary>
    public class BattleLocation
    {
        public HexCell[,] Cells { get; private set; }

        public BattleLocation(HexCell[,] cells)
        {
            Cells = cells;
        }
    }
}