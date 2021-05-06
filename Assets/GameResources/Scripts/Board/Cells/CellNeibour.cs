using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    public enum Neighbour
    {
        North,
        NorthEast,
        SouthEast,
        South,
        SouthWest,
        NorthWest
    }
    public static class NeighbourExtensions
    {
        public static Neighbour Opposite(this Neighbour direction)
        {
            return (int)direction < 3 ? (direction + 3) : (direction - 3);
        }
    }
    /// <summary>
    /// Сосед клетки
    /// </summary>
    [System.Serializable]
    public class CellNeighbour
    {
        [SerializeField]
        private Neighbour _neigbour;
        [SerializeField]
        private HexCell _cell;

        public Neighbour Neighbour => _neigbour;
        public HexCell Cell => _cell;

        public CellNeighbour(Neighbour neighbour, HexCell hexCell)
        {
            _neigbour = neighbour;
            _cell = hexCell;
        }
    }
}