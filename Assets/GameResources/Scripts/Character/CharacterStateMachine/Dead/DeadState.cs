using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Стейт Смерти
    /// </summary>
    public class DeadState : BaseState
    {
        private const string DEAD_ANIMATION = "defeat/death";

        private Health _health;
        private SkeletonAnimation _skeletonAnimation;
        private Character _character;

        public DeadState(int stateOrder, List<StateInitializer> otherStates, StateInitializer currentStateInitializer, List<IState> initedStates)
: base(stateOrder, otherStates, currentStateInitializer, initedStates)
        {

        }

        public override void EnterAction()
        {
            _skeletonAnimation.loop = false;
            _skeletonAnimation.AnimationName = DEAD_ANIMATION;
            _character.CurrentCell.RemoveCharacter();
        }

        public override bool EnterCondition()
        {
            return _health.CurrentHealth == 0;
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
            _health = character.Health;
            _skeletonAnimation = character.GetComponent<SkeletonAnimation>();
            _character = character;
        }

        public override void StateAction()
        {

        }

    }
}