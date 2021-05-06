using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Компонент определяющий противника для персонажа
    /// </summary>
    public class CharacterEnemyFinder : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private AttakArmorSettings _attakArmorSettings;
        [SerializeField] private List<Character> _enemyCharacters;

        public List<Character> EnemyCharacters => _enemyCharacters; //{ get; private set; } = new List<Character>();
        public AttakArmorSettings ArmorSetting => _attakArmorSettings;


        public void FindEnemies()
        {
            _enemyCharacters = _character.Manager.GetCharactersWithoutId(_character.Id);
            for (int i = 0; i < EnemyCharacters.Count; i++)
            {
                EnemyCharacters[i].Health.OnZeroHealth += RemoveDeadCharacters;
            }
            //List<Character> charactersWithArmor = GetEnemyCharactersWithArmor(EnemyCharacters);
            //List<Character> aliveCharacters = new List<Character>();
            //aliveCharacters = charactersWithArmor.Count > 0 ? _character.Manager.GetAliveCharacters(charactersWithArmor) : _character.Manager.GetAliveCharacters(EnemyCharacters);
            //if (aliveCharacters.Count > 0)
            //{
            //    _character.SetTarget(aliveCharacters[Random.Range(0, aliveCharacters.Count)]);
            //}

        }

        private void OnDisable()
        {
            for (int i = 0; i < EnemyCharacters.Count; i++)
            {
                EnemyCharacters[i].Health.OnZeroHealth -= RemoveDeadCharacters;
            }
        }

        private void RemoveDeadCharacters()
        {
            for (int i = 0; i < EnemyCharacters.Count; i++)
            {
                EnemyCharacters[i].Health.OnZeroHealth -= RemoveDeadCharacters;
            }
            _enemyCharacters = EnemyCharacters.FindAll(x => x.Health.CurrentHealth > 0);
            for (int i = 0; i < EnemyCharacters.Count; i++)
            {
                EnemyCharacters[i].Health.OnZeroHealth += RemoveDeadCharacters;
            }
        }

    }
}