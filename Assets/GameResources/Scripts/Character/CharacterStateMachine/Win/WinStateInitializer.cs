using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// SO стейта победы
    /// </summary>
    [CreateAssetMenu(fileName = "WinState", menuName = "BattleSystem/StateBehaviour/WinState")]
    public class WinStateInitializer : StateInitializer
    {
        public override IState CreateState(List<IState> initedStates)
        {
            IState state = new WinState(stateOrder, states, this, initedStates);
            return state;
        }
    }
}