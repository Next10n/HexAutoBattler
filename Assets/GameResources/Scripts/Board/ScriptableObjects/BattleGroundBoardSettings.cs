using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Настройки поля для битвы
    /// </summary>
    [CreateAssetMenu(fileName = "BattleGroundBoardSettings", menuName = "BattleSystem/Board/BattleGroundBoardSettings")]
    public class BattleGroundBoardSettings : ScriptableObject
    {
        [SerializeField] private int width;
        [SerializeField] private int height;

        public int Width => width;
        public int Heigth => height;
    }
}
