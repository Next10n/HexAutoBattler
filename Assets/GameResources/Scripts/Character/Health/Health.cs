using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Здоровье
    /// </summary>
    public class Health : MonoBehaviour
    {
        public event Action<int> OnHealthUpdate = delegate { };
        public event Action OnZeroHealth = delegate { };
        public event Action<Character> OnTakeDamage = delegate { };

        [SerializeField] private int _startHealth;
        [SerializeField] private ArmorComponent _armor;
        [SerializeField] private bool _debugApplyingDamage;

        public int CurrentHealth { get; private set; }

        private void Start()
        {
            CurrentHealth = _startHealth;
        }

        public bool TryApplyDamageFrom(Character character)
        {
            int damage = _armor.CalculateDamage(character.Attack);
            if(damage <= 0)
            {
                Debug.LogError("Урон не может быть отрицательным");
                return false;
            }
            if(CurrentHealth - damage <= 0)
            {
                CurrentHealth = 0;
                OnZeroHealth();
            }
            else
            {
                CurrentHealth -= damage;
            }
            if (_debugApplyingDamage)
            {
                Debug.Log("Получено " + damage + " урона персонажем " + name + "от атаки типа " + character.Attack.Id.Id + ". Изначальный урон : " + character.Attack.Damage
                    +". Пперсножаш получивший урон имел следующие характеристика брони : ");
                for (int i = 0; i < _armor.ArmorValues.Length; i++)
                {
                    Debug.Log("Броня: " + _armor.ArmorValues[i].typeId.Id + " " + _armor.ArmorValues[i].value);
                }
            }

            OnTakeDamage(character);
            OnHealthUpdate(CurrentHealth);
            return true;
        }
    }
}