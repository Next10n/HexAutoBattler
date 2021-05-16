using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{

    /// <summary>
    /// Компонент атаки
    /// </summary>
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField] private AttackTypeId _attackTypeId;

        [SerializeField] private int _damage;
        [SerializeField] private float _speed;
        [SerializeField] private float _damageModificator = 0.05f;

        public AttackTypeId Id => _attackTypeId;

        public int Damage => _damage;
        public float Speed => _speed;
        public float DamageModificator => _damageModificator;

    }
}