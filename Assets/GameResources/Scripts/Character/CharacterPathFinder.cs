using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Поиску пути для конкретного персонажа
    /// </summary>
    public class CharacterPathFinder : MonoBehaviour
    {
        private CharacterManager characterManager;

        private void Awake()
        {
            characterManager = FindObjectOfType<CharacterManager>();
        }

        public List<PathElement> FindPathToRandomEnemy(HexCell currentCell, CharacterArmyId id)
        {
            List<Character> characters = characterManager.GetCharactersWithoutId(id);
            return PathFinder.FindPath(currentCell, characters[Random.Range(0, characters.Count)].CurrentCell);
        }



    }
}
