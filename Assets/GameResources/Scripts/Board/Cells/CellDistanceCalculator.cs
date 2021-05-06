using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Вычисление дистанции от клетки до клетки
    /// </summary>
    public static class CellDistanceCalculator
    {
        /// <summary>
        /// Вычисление дистанции от клетки до клетки
        /// </summary>
        /// <param name="ingoingCell">Клетка от которой считаь дистанцию</param>
        /// <param name="findingCell">Клетка до которой считать дистанцию</param>
        /// <returns></returns>
        public static int CalculateDistance(HexCell ingoingCell, HexCell findingCell)
        {
            int x = ingoingCell.Coordinates.X;
            int y = ingoingCell.Coordinates.Y;
            int z = ingoingCell.Coordinates.Z;
            int otherX = findingCell.Coordinates.X;
            int otherY = findingCell.Coordinates.Y;
            int otherZ = findingCell.Coordinates.Z;
            return
            ((x < otherX ? otherX - x : x - otherX) +
            (y < otherY ? otherY - y : y - otherY) +
            (z < otherZ ? otherZ - z : z - otherZ)) / 2;
        }
    }
}
