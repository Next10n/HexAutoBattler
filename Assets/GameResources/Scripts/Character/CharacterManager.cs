using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Котнроллер персонажей
    /// </summary>
    public class CharacterManager : MonoBehaviour
    {
        public List<Character> Characters { get; private set; } = new List<Character>();

        public List<Character> GetCharactersWithId(CharacterArmyId characterArmyId)
        {
            return Characters.FindAll(x => x.Id == characterArmyId);
        }

        public List<Character> GetAliveCharacters(List<Character> characters)
        {
            return characters.FindAll(x => x.Health.CurrentHealth > 0);
        }

        public List<Character> GetCharactersWithoutId(CharacterArmyId characterArmyId)
        {
            return Characters.FindAll(x => x.Id != characterArmyId);
        }

        public void AddCharacter(Character character)
        {
            Characters.Add(character);
        }

        private void Update()
        {
            for (int i = 0; i < Characters.Count; i++)
            {
                Characters[i].CustomUpdate();
            }
        }
    }
}
