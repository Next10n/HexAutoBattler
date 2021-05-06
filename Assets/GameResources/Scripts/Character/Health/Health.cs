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

        [SerializeField] private int startHealth;

        public int CurrentHealth { get; private set; }

        private void Start()
        {
            CurrentHealth = startHealth;
        }

        public bool TryApplyDamageFrom(Character character)
        {
            int damage = character.GetComponent<AttackController>().Damage;
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
            OnTakeDamage(character);
            OnHealthUpdate(CurrentHealth);
            return true;
        }
    }
}