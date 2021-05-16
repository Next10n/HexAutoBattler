using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Id Типа атаки
    /// </summary>
    [CreateAssetMenu(fileName ="AttackTypeId", menuName ="BattleSystem/Character/AttackTypeId")]
    public class AttackTypeId : ScriptableObject
    {
        [SerializeField] private string _id;

        public string Id => _id;
    }
}