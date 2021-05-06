using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Генерация локации для боя
    /// </summary>
    public interface IBattleGroundGenerator 
    {
        BattleLocation GenerateLocation(BattleGroundBoardSettings settings);
    }
}