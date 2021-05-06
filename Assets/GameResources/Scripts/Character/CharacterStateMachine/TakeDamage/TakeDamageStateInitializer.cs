using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// SO стейта смерти
    /// </summary>
    [CreateAssetMenu(fileName = "TakeDamageState", menuName = "BattleSystem/StateBehaviour/TakeDamageState")]
    public class TakeDamageStateInitializer : StateInitializer
    {
        public override IState CreateState(List<IState> initedStates)
        {
            IState state = new TakeDamageState(stateOrder, states, this, initedStates);
            return state;
        }
    }
}
