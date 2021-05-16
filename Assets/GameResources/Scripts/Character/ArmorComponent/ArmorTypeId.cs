using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Id Типа атаки
    /// </summary>
    [CreateAssetMenu(fileName = "ArmorTypeId", menuName = "BattleSystem/Character/ArmorTypeId")]
    public class ArmorTypeId : ScriptableObject
    {
        [SerializeField] private string _id;

        public string Id => _id;
    }
}