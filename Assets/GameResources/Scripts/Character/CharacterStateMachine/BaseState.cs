using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Базовый класс стейта поведения
    /// </summary>
    public abstract class BaseState : IState
    {
        public event Action<IState> OnStateInit = delegate { };
        public event Action<IState> OnStateEnter = delegate { };
        public event Action<IState> OnStateExit = delegate { };

        private int _stateOrder;
        private List<IState> _states = new List<IState>();

        public int StateOrder => _stateOrder;
        public List<IState> States => _states;
        public StateInitializer StateInitializer => _currentStateInitializer;

        public bool Inited { get; private set; } = false;
        public bool Entered { get; private set; } = false;

        public abstract bool EnterCondition();
        public abstract bool ExitCondition();

        public abstract void EnterAction();
        public abstract void ExitAction();
        public abstract void StateAction();

        public abstract void InitComponents(Character character);

        private StateInitializer _currentStateInitializer;
        private List<StateInitializer> _otherStates;
        private List<IState> _initedStates;

        public BaseState(int stateOrder, List<StateInitializer> otherStates, StateInitializer currentStateInitializer, List<IState> initedStates)
        {
            _stateOrder = stateOrder;
            _currentStateInitializer = currentStateInitializer;
            _otherStates = otherStates;
            _initedStates = initedStates;

        }

        public void Init(Character character)
        {
            if(Inited == true)
            {
                return;
            }
            _initedStates.Add(this);
            foreach (StateInitializer stateInitializer in _otherStates)
            {
                IState initedState = _initedStates.Find(x => x.StateInitializer == stateInitializer);
                if (initedState != null)
                {
                    States.Add(initedState);
                }
                else
                {
                    States.Add(stateInitializer.CreateState(_initedStates));
                }
            }
            InitComponents(character);
            Inited = true;
            for (int i = 0; i < States.Count; i++)
            {
                States[i].Init(character);
            }
            States.Sort((x, y) => x.StateOrder.CompareTo(y.StateOrder));
            OnStateInit(this);
        }

        public void StateEnter()
        {
            Entered = true;
            EnterAction();
            OnStateEnter(this);
        }

        public IState StateExit()
        {
            Entered = false;
            ExitAction();
            OnStateExit(this);
            for (int i = 0; i < States.Count; i++)
            {
                if(States[i].EnterCondition() == true)
                {
                    return States[i];
                }
            }
            return this;
        }

        public IState StateUpdate()
        {
            if (Entered == false)
            {
                StateEnter();
            }
            if (ExitCondition() == true)
            {
                return StateExit();
            }
            StateAction();


            return this;
        }



    }
}
