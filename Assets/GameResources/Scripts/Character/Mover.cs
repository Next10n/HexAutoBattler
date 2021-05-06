using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Передвижение
    /// </summary>
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;

        public void Move(Transform transform, Vector3 position)
        {
            transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * _speed);
        }
    }
}