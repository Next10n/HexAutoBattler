using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Настройки соответствия типу атаки, типам брони
    /// </summary>
    [CreateAssetMenu(fileName ="AttackArmorSettings", menuName = "BattleSystem/StateBehaviour/EnemyFinder/AttackArmorSettings")]
    public class AttakArmorSettings : ScriptableObject
    {
        [SerializeField] private AttackArmorPair[] attackArmorPairs;

        [SerializeField] private ArmorTypeId defaultArmor;

        public AttackArmorPair[] Pairs => attackArmorPairs;

        public ArmorTypeId GetArmor(AttackTypeId attackType)
        {
            for (int i = 0; i < attackArmorPairs.Length; i++)
            {
                if(attackArmorPairs[i].Attack == attackType)
                {
                    return attackArmorPairs[i].ArmorType;
                }
            }
            return defaultArmor;
        }
    }


    [System.Serializable]
    public struct AttackArmorPair
    {
        public AttackTypeId Attack;
        public ArmorTypeId ArmorType;

    }
}