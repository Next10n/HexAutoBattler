using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Скрипт персонажа
    /// </summary>
    public class Character : MonoBehaviour
    {
        [SerializeField] private Health _health;

        [Header("Стартовый стейт машины поведения.")]
        [SerializeField] private StateInitializer startState;

        [Header("Тип Атаки")]
        [SerializeField] private AttackComponent _attack;

        [Header("Тип Защиты")]
        [SerializeField] private ArmorComponent _armor;

        [Header("Выводит в консоль текущий стейт персонажа")]
        [SerializeField] private bool debugState = false;

        public CharacterArmyId Id { get; private set; }

        public AttackComponent Attack => _attack;
        public ArmorComponent Armor => _armor;

        public IState State { get; private set; }
        public CharacterManager Manager {get; private set;}

        [SerializeField] private HexCell cell;

        [SerializeField] private List<PathElement> _path = null;

        public HexCell CurrentCell { get => cell; private set { cell = value; } }
        public List<PathElement> Path => _path; //{ get; private set; }
        public Character Target { get; private set; }
        public bool DebugState => debugState;
        public Health Health => _health;

        //Костыль на апдейт стейтов
        private bool _pause = false;

        public void Init(CharacterArmyId id, CharacterManager manager, HexCell hexCell)
        {
            Id = id;
            Manager = manager;
            CurrentCell = hexCell;
        }

        private void Start()
        {
            State = startState.CreateState(new List<IState>());
            State.Init(this);
        }

        public void CustomUpdate()
        {
            if (_pause)
                return;
            State = State.StateUpdate();
            if(debugState)
                Debug.Log("State : " + State.StateInitializer.name);
        }

        public void Pause(float time)
        {
            _pause = true;
            Invoke(nameof(Unpause), time);
        }

        private void Unpause()
        {
            _pause = false;
        }

        public void SetPath(List<PathElement> pathElements)
        {
            _path = pathElements;
        }

        public void SetCell(HexCell newCell)
        {
            CurrentCell = newCell;
        }

        public void SetTarget(Character character)
        {
            Target = character;
            Target.Health.OnZeroHealth += RemoveTarget;
        }

        public void ClearPath()
        {
            _path.Clear();
        }

        public void RemoveTarget()
        {
            if (Target != null)
            {
                Target.Health.OnZeroHealth -= RemoveTarget;
                ClearPath();
                Target = null;
            }

        }
    }
}