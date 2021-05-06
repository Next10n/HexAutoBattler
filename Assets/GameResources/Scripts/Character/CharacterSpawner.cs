using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Спавнер персонажей
    /// </summary>
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField] private CharacterArmyId id;
        [SerializeField] private BoardController boardController;
        [SerializeField] private SpawnPositions spawnPositions;
        [Header("пресонажи для спавна на локации")]
        [SerializeField] private Character[] characters;
        [SerializeField] private CharacterManager characterManager;


        private List<Vector2Int> spawns = new List<Vector2Int>();
        private List<Character> spawnedCharacters = new List<Character>();
        public CharacterArmyId Id => id;


        private void Awake()
        {
            foreach(Vector2Int spawn in spawnPositions.Spawns)
            {
                spawns.Add(spawn);
            }
            foreach (Character character in characters)
            {
                spawnedCharacters.Add(character);
            }
        }

        private void Start()
        {
            while(spawnedCharacters.Count > 0)
            {
                int characterIndex = Random.Range(0, spawnedCharacters.Count);
                Character character = spawnedCharacters[characterIndex];
                spawnedCharacters.RemoveAt(characterIndex);
                int spawnIndex = Random.Range(0, spawns.Count);
                Vector2Int spawn = spawns[spawnIndex];
                spawns.RemoveAt(spawnIndex);
                HexCell cell = boardController.BattleLocation.Cells[spawn.x, spawn.y];
                Character instantiatedCharacter = Instantiate(character, cell.transform.position, Quaternion.identity, cell.transform);
                instantiatedCharacter.Init(id, characterManager, cell);
                characterManager.AddCharacter(instantiatedCharacter);
            }

        }
    }
}