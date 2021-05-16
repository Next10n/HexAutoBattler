using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Инициализация скина
    /// </summary>
    [RequireComponent(typeof(Character))]
    [RequireComponent(typeof(SkeletonAnimation))]
    public class CharacterSkin : MonoBehaviour
    {
        [SerializeField] private CharacterSkinContainer _characterSkinContainer;

        private Character _character;
        private SkeletonAnimation _skeletonAnimation;

        private void Awake()
        {
            _character = GetComponent<Character>();
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
            Skeleton skeleton = _skeletonAnimation.skeleton;
            SkeletonData data = skeleton.Data;

            var weapon = data.FindSkin(_characterSkinContainer.GetWeaponSkinName(_character.Attack.Id));
            var armor = data.FindSkin(_characterSkinContainer.GetArmorSkinName(_character.Armor.Id));

            Skin equipingSkin = new Skin("CombinedSkin");

            equipingSkin.AddSkin(weapon);
            equipingSkin.AddSkin(armor);

            skeleton.SetSkin(equipingSkin);
            skeleton.SetSlotsToSetupPose();
            _skeletonAnimation.Update(0);

        }
    }
}