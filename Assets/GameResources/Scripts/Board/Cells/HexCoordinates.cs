using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Хранение координат точек в гексовом пространстве
    /// </summary>
    [System.Serializable]
    public struct HexCoordinates
    {
        [SerializeField]
        private int _x;

        [SerializeField]
        private int _y;

        public int X => _x;

        public int Y => _y;

        public int Z => -X - Y;

        public HexCoordinates(int x, int y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Добавим статический метод для создания множества координат из обычных смещённых координат.
        /// </summary>
        public static HexCoordinates FromOffsetCoordinates(int x, int y)
        {
            return new HexCoordinates(x, y - x / 2);
        }
    }
}