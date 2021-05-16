using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Компонент защиты персонажа
    /// </summary>
    public class ArmorComponent : MonoBehaviour
    {
        [SerializeField] private ArmorValue[] _armorValues;
        [SerializeField] private AttakArmorSettings _attakArmorSettings;

        public ArmorValue[] ArmorValues => _armorValues;

        //TODO избавиться от понятия основной тип защиты персонажа
        public ArmorTypeId Id
        {
            get
            {
                int maxDamage = 0;
                ArmorTypeId maxArmor = _armorValues[0].typeId;
                for (int i = 0; i < _armorValues.Length; i++)
                {
                    if(_armorValues[i].value >= maxDamage)
                    {
                        maxDamage = 0;
                        maxArmor = _armorValues[i].typeId;
                    }
                }
                return maxArmor;
            }
        }


        /// <summary>
        /// Подсчет демаджа по текущему армору
        /// </summary>
        /// <returns></returns>
        public int CalculateDamage(AttackComponent attackComponent)
        {
            AttackTypeId attackId = attackComponent.Id;
            int damage = attackComponent.Damage;
            ArmorTypeId currentArmor = _attakArmorSettings.GetArmor(attackId);
            int armorSkill = 0;
            int advansedArmor = 0;
            int advancedArmorDevider = 0;
            for (int i = 0; i < _armorValues.Length; i++)
            {
                if(_armorValues[i].typeId == currentArmor)
                {
                    armorSkill += _armorValues[i].value;
                }
                else
                {
                    advansedArmor += _armorValues[i].value;
                    advancedArmorDevider++;
                }                
            }
            armorSkill += Mathf.RoundToInt((float)advansedArmor / (float)advancedArmorDevider);
            int damageValue = Mathf.RoundToInt(damage + damage * ((damage - armorSkill) * attackComponent.DamageModificator));
            return damageValue;
        }
    }        

    [System.Serializable]
    public struct ArmorValue
    {
        public ArmorTypeId typeId;
        public int value;
    }
}