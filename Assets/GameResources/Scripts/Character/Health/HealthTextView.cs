using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BattleSystem
{
    /// <summary>
    /// Вьюшка здоровья
    /// </summary>
    public class HealthTextView : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Text _healthText;

        private void OnEnable()
        {
            _health.OnHealthUpdate += ViewText;
        }

        private void Start()
        {
            ViewText(_health.CurrentHealth);
        }

        private void ViewText(int health)
        {
            _healthText.text = health.ToString();
            if(health == 0)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            _health.OnHealthUpdate -= ViewText;
        }
    }
}