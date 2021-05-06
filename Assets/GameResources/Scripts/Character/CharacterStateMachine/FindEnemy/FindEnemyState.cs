using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Состояние поика противника
    /// </summary>
    public class FindEnemyState : BaseState
    {
        private CharacterEnemyFinder _characterEnemyFinder;

        public FindEnemyState(int stateOrder, List<StateInitializer> otherStates, StateInitializer stateInitializer, List<IState> initedStates) 
            : base(stateOrder, otherStates, stateInitializer, initedStates)
        {

        }

        public override void InitComponents(Character character)
        {
            _characterEnemyFinder = character.GetComponent<CharacterEnemyFinder>();
        }

        public override bool EnterCondition()
        {
            return _characterEnemyFinder.EnemyCharacters.Count == 0;
        }

        public override bool ExitCondition()
        {
            return _characterEnemyFinder.EnemyCharacters.Count > 0;
        }

        public override void EnterAction()
        {

        }

        public override void ExitAction()
        {
            
        }

        public override void StateAction()
        {
            _characterEnemyFinder.FindEnemies();               
        }

    }

}
