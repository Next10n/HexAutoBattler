using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// SO стейта поика противника
    /// </summary>
    [CreateAssetMenu(fileName = "MoveState", menuName = "BattleSystem/StateBehaviour/MoveState")]
    public class MoveStateInitializer : StateInitializer
    {
        public override IState CreateState(List<IState> initedStates)
        {
            IState state = new MoveState(stateOrder, states, this, initedStates);
            return state;
        }
    }
}