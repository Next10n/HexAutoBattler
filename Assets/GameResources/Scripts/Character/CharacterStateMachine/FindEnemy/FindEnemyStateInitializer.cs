using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// SO стейта поика противника
    /// </summary>
    [CreateAssetMenu(fileName ="EnemyFindState", menuName = "BattleSystem/StateBehaviour/EnemyFindState")]
    public class FindEnemyStateInitializer : StateInitializer
    {
        public override IState CreateState(List<IState> initedStates)
        {
            IState state = new FindEnemyState(stateOrder, states, this, initedStates);
            return state;
        }
    }
}