using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// SO стейта атаки
    /// </summary>
    [CreateAssetMenu(fileName = "AttackState", menuName = "BattleSystem/StateBehaviour/AttackState")]
    public class AttackStateInitializer : StateInitializer
    {
        [SerializeField] private float _attackDistance;

        public override IState CreateState(List<IState> initedStates)
        {
            IState state = new AttackState(_attackDistance, stateOrder, states, this, initedStates);
            return state;
        }
    }
}