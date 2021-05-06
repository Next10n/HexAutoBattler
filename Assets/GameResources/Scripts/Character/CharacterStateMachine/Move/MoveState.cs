using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Стейт передвижения персонажа
    /// </summary>
    public class MoveState : BaseState
    {
        private float moveOffset = 0.01f;

        private const string WALK_ANIMATION = "walk/walk";
        private const string IDLE_ANIMATION = "idle/idle";

        private Character _character;
        private SkeletonAnimation _skeletonAnimation;
        private Mover _characterMover;

        private bool _blocked = false;

        private HexCell movingCell;

        public MoveState(int stateOrder, List<StateInitializer> otherStates, StateInitializer currentStateInitializer, List<IState> initedStates) 
            : base(stateOrder, otherStates, currentStateInitializer, initedStates)
        {

        }

        public override void EnterAction()
        {
            movingCell = _character.Path[_character.Path.Count - 2].PathCell;
            if(movingCell.Character == null)
            {
                _blocked = false;
                movingCell.SetCharacter(_character);
                _skeletonAnimation.loop = true;
                _skeletonAnimation.AnimationName = WALK_ANIMATION;
            }
            else
            {
                _blocked = true;
            }
        }

        public override bool EnterCondition()
        {
            if(_character.Path == null)
            {
                return false;
            }
            return _character.Path.Count > 1;
        }

        public override void ExitAction()
        {
            if (_blocked)
            {

            }
            else
            {
                _character.CurrentCell.RemoveCharacter();
                _character.SetCell(movingCell);
                _skeletonAnimation.AnimationName = IDLE_ANIMATION;
            }
            _character.ClearPath();
        }

        public override bool ExitCondition()
        {
            if (_blocked)
            {
                return true;
            }
            if (Mathf.Abs(Vector2.Distance(_character.transform.position, movingCell.transform.position)) < moveOffset)
            {
                return true;
            }
            if(_character.Path == null)
            {
                return true;
            }
            return _character.Path.Count < 2;
        }

        public override void InitComponents(Character character)
        {
            _character = character;
            _skeletonAnimation = character.GetComponent<SkeletonAnimation>();
            _characterMover = character.GetComponent<Mover>();
        }

        public override void StateAction()
        {
            _characterMover.Move(_character.transform, movingCell.transform.position);
        }
    }
}