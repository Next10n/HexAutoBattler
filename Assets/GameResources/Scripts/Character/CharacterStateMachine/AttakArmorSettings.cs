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

        [SerializeField] private ArmorType[] defaultArmors;

        public AttackArmorPair[] Pairs => attackArmorPairs;

        public ArmorType[] GetArmors(AttackType attackType)
        {
            for (int i = 0; i < attackArmorPairs.Length; i++)
            {
                if(attackArmorPairs[i].Attack == attackType)
                {
                    return attackArmorPairs[i].ArmorTypes;
                }
            }
            return defaultArmors;
        }
    }


    [System.Serializable]
    public struct AttackArmorPair
    {
        public AttackType Attack;
        public ArmorType[] ArmorTypes;

    }
}