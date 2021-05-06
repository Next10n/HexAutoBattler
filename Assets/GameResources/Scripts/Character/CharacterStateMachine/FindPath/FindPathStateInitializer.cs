using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// SO стейта поика противника
    /// </summary>
    [CreateAssetMenu(fileName = "FindPathState", menuName = "BattleSystem/StateBehaviour/FindPathState")]
    public class FindPathStateInitializer : StateInitializer
    {
        public override IState CreateState(List<IState> initedStates)
        {
            IState state = new FindPathState(stateOrder, states, this, initedStates);
            return state;
        }
    }
}