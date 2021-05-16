using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Стейт атаки
    /// </summary>
    public class AttackState : BaseState
    {
        private const string ATTACK_ANIMATION_EVENT = "Atack";
        private const string ATTACK_ANIMATION_1 = "atack/atack_to_1";
        private const string ATTACK_ANIMATION_INJECTION_1 = "atack/for_the_injection/atack_to_1_injection";
        private const string ATTACK_ANIMATION_2 = "atack/atack_to_2";
        private const string ATTACK_ANIMATION_3 = "atack/atack_to_3";
        private const string ATTACK_ANIMATION_4 = "atack/atack_to_4";
        private const string ATTACK_ANIMATION_INJECTION_4 = "atack/for_the_injection/atack_to_4_injection";

        private Character _character;
        private SkeletonAnimation _skeletonAnimation;
        private Health _enemyHealth;
        private AttackComponent _attackComponent;

        public readonly float AttackDistance;

        private string _animationName = string.Empty;
        private bool _flip = false;

        public AttackState(float attackDistance, int stateOrder, List<StateInitializer> otherStates, StateInitializer currentStateInitializer, List<IState> initedStates)
    : base(stateOrder, otherStates, currentStateInitializer, initedStates)
        {
            AttackDistance = attackDistance;
        }

        public override void EnterAction()
        {
            _skeletonAnimation.state.Event += AnimationAction;
            _enemyHealth = _character.Target.Health;
            _skeletonAnimation.loop = true;           
            ApplyDirection();
            _skeletonAnimation.timeScale = CalculateTimeScale();
        }

        private float CalculateTimeScale()
        {
            Spine.Animation myAnimation = _skeletonAnimation.Skeleton.Data.FindAnimation(_animationName);
            float defaultAnimationTime = myAnimation.Duration;
            return defaultAnimationTime / _attackComponent.Speed;
        }

        public override bool EnterCondition()
        {
            if (_character.DebugState)
            {
                Debug.Log("EnterAttackCondition");
                Debug.Log("_character Target : " + _character.Target.transform.parent.name);
            }
            if(_character.Target != null)
            {
                return Mathf.Abs(Vector2.Distance(_character.transform.position, _character.Target.transform.position)) < AttackDistance;
            }
            return false;
          
        }

        private void AnimationAction(Spine.TrackEntry state, Spine.Event e)
        {
            if(e.Data.Name == ATTACK_ANIMATION_EVENT)
            {
                _enemyHealth.TryApplyDamageFrom(_character);
            }
        }

        public override void ExitAction()
        {
            _character.ClearPath();
            _skeletonAnimation.state.Event -= AnimationAction;
            _skeletonAnimation.timeScale = 1f;
        }

        public override bool ExitCondition()
        {
            if(_character.Target == null)
            {
                return true;
            }
            if(_character.Health.CurrentHealth <= 0)
            {
                return true;
            }
            return Mathf.Abs(Vector2.Distance(_character.transform.position, _character.Target.transform.position)) > AttackDistance;
        }

        public override void InitComponents(Character character)
        {
            _character = character;
            _skeletonAnimation = character.GetComponent<SkeletonAnimation>();
            _attackComponent = character.Attack;
        }

        public override void StateAction()
        {
            if (_character.DebugState)
                Debug.Log("AttackState Action");
            ApplyDirection();
        } 

        private void ApplyDirection()
        {
            switch (GetCellDirection(_character.Target.CurrentCell))
            {
                case Neighbour.North:
                    _animationName = _character.Attack.Id.Id == "cutting" ? ATTACK_ANIMATION_1 : ATTACK_ANIMATION_INJECTION_1;
                    _flip = true;
                    break;
                case Neighbour.NorthWest:
                    _animationName = ATTACK_ANIMATION_2;
                    _flip = true;
                    break;
                case Neighbour.NorthEast:
                    _animationName = ATTACK_ANIMATION_2;
                    _flip = false;
                    break;
                case Neighbour.South:
                    _animationName = _character.Attack.Id.Id == "cutting" ? ATTACK_ANIMATION_4 : ATTACK_ANIMATION_INJECTION_4;
                    _flip = false;
                    break;
                case Neighbour.SouthEast:
                    _animationName = ATTACK_ANIMATION_3;
                    _flip = false;
                    break;
                case Neighbour.SouthWest:
                    _animationName = ATTACK_ANIMATION_3;
                    _flip = true;
                    break;                    
            }
            _skeletonAnimation.AnimationName = _animationName;
            _skeletonAnimation.skeleton.ScaleX = _flip ? -1 : 1;
        }

        private Neighbour GetCellDirection(HexCell cell)
        {
            for(int i = 0; i < _character.CurrentCell.CellNeighbours.Count; i++)
            {
                if(_character.CurrentCell.CellNeighbours[i].Cell == cell)
                {
                    return _character.CurrentCell.CellNeighbours[i].Neighbour;
                }
            }
            return Neighbour.NorthEast;
        }
    }
}
