using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Стейт получения урона
    /// </summary>
    public class TakeDamageState : BaseState
    {
        private Health _health;
        private Character _enemy;
        private SkeletonAnimation _skeletonAnimation;

        private const string TAKE_DAMAGE_LEFT = "take_damage/hit_from_left";
        private const string TAKE_DAMAGE_RIGHT = "take_damage/hit_from_right";
        private const string IDLE = "idle/idle";

        private bool _stateEnabled;

        public TakeDamageState(int stateOrder, List<StateInitializer> otherStates, StateInitializer currentStateInitializer, List<IState> initedStates)
: base(stateOrder, otherStates, currentStateInitializer, initedStates)
        {

        }


        public override void EnterAction()
        {
            _skeletonAnimation.AnimationName = TAKE_DAMAGE_LEFT;
            _skeletonAnimation.AnimationState.Complete += DeactivateState;
        }

        public override bool EnterCondition()
        {
            return _stateEnabled;
        }

        public override void ExitAction()
        {
            _skeletonAnimation.AnimationState.Complete -= DeactivateState;
            _skeletonAnimation.AnimationName = IDLE;
        }

        public override bool ExitCondition()
        {
            return _stateEnabled == false;
        }

        public override void InitComponents(Character character)
        {
            _health = character.GetComponent<Health>();
            _health.OnTakeDamage += InitEnemy;
            _skeletonAnimation = character.GetComponent<SkeletonAnimation>();
        }

        private void InitEnemy(Character enemy)
        {
            ActivateState();
            _enemy = enemy;
        }

        private void ActivateState()
        {
            _stateEnabled = true;
        }

        private void DeactivateState(TrackEntry trackEntry)
        {
            DeactivateState();
        }

        private void DeactivateState()
        {
            _stateEnabled = false;
        }


        public override void StateAction()
        {

        }

    }
}