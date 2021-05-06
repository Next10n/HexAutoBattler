using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// SO стейта смерти
    /// </summary>
    [CreateAssetMenu(fileName = "DeadState", menuName = "BattleSystem/StateBehaviour/DeadState")]
    public class DeadStateInitializator : StateInitializer
    {
        public override IState CreateState(List<IState> initedStates)
        {
            IState state = new DeadState(stateOrder, states, this, initedStates);
            return state;
        }
    }
}
