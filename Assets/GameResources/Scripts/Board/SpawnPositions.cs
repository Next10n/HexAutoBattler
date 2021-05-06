using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Позиции для спавна персонажей
    /// </summary>
    [CreateAssetMenu(fileName ="SpawnPositions", menuName ="BattleSystem/Board/SpawnPositions")]
    public class SpawnPositions : ScriptableObject
    {
        [SerializeField] private Vector2Int[] spawnPositions;

        public Vector2Int[] Spawns => spawnPositions;
    }
}