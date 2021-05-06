using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Контейнер скинов персонажей
    /// </summary>
    [CreateAssetMenu(fileName ="SkinContainer", menuName ="BattleSystem/Character/SkinContainer")]
    public class CharacterSkinContainer : ScriptableObject
    {
        public WeaponSkin[] WeaponSkins;
        public ArmorSkin[] ArmoprSkins;

        public string GetWeaponSkinName(AttackType attackType)
        {
            foreach(WeaponSkin weaponSkin in WeaponSkins)
            {
                if(weaponSkin.AttackType == attackType)
                {
                    return weaponSkin.SkinName;
                }
            }
            return WeaponSkins[0].SkinName;
        }

        public string GetArmorSkinName(ArmorType armorType)
        {
            foreach (ArmorSkin armorSkin in ArmoprSkins)
            {
                if (armorSkin.ArmorType == armorType)
                {
                    return armorSkin.SkinName;
                }
            }
            return ArmoprSkins[0].SkinName;
        }
    }

    [System.Serializable]
    public struct WeaponSkin
    {
        public AttackType AttackType;
        public string SkinName;
    }

    [System.Serializable]
    public struct ArmorSkin
    {
        public ArmorType ArmorType;
        public string SkinName;
    }
}
