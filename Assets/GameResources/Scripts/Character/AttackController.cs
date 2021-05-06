using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Атака персонажа
    /// </summary>
    public class AttackController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;

        public float Speed => _speed;
        public int Damage => _damage;
    }
}