using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// SO для инициализации стейтов
    /// </summary>
    public abstract class StateInitializer : ScriptableObject
    {
        [SerializeField] protected int stateOrder;
        [SerializeField] protected List<StateInitializer> states;

        public abstract IState CreateState(List<IState> initedStates);
    }
}
