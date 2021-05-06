using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Id Армии
    /// </summary>
    [CreateAssetMenu(fileName = "ArmyId", menuName ="BattleSystem/Characters/ArmyId")]
    public class CharacterArmyId : ScriptableObject
    {
        [SerializeField] private string id;

        public string Id => id;
    }
}