using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Интерфейс стейта поведения
    /// </summary>
    public interface IState
    {
        event Action<IState> OnStateInit;
        event Action<IState> OnStateEnter;
        event Action<IState> OnStateExit;

        void Init(Character character);
        void StateEnter();
        IState StateExit();

        bool EnterCondition();
        bool ExitCondition();

        int StateOrder { get; }
        StateInitializer StateInitializer { get; }
        List<IState> States { get; }

        IState StateUpdate();
    }
}