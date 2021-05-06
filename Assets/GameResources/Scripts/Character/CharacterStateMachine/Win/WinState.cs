using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Стейт победы
    /// </summary>
    public class WinState : BaseState
    {
        private const string WIN_ANIMATION = "win/win";
        private SkeletonAnimation _skeletonAnimation;
        private CharacterManager _characterManager;
        private Character _character;

        public WinState(int stateOrder, List<StateInitializer> otherStates, StateInitializer currentStateInitializer, List<IState> initedStates)
     : base(stateOrder, otherStates, currentStateInitializer, initedStates)
        {

        }

        public override void EnterAction()
        {
            _skeletonAnimation.AnimationName = WIN_ANIMATION;
        }

        public override bool EnterCondition()
        {
            return _characterManager.GetAliveCharacters(_characterManager.GetCharactersWithoutId(_character.Id)).Count == 0;
        }

        public override void ExitAction()
        {
 
        }

        public override bool ExitCondition()
        {
            return false;
        }

        public override void InitComponents(Character character)
        {
            _skeletonAnimation = character.GetComponent<SkeletonAnimation>();
            _characterManager = character.Manager;
            _character = character;
        }

        public override void StateAction()
        {

        }
    }
}