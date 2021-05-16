using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Поиск пути до противника
    /// </summary>
    public class FindPathState : BaseState
    {
        private Character _character;
        private List<Character> _enemyCharacters;
        private AttakArmorSettings _attakArmorSettings;
        private CharacterEnemyFinder _characterEnemyFinder;

        public FindPathState(int stateOrder, List<StateInitializer> otherStates, StateInitializer currentStateInitializer, List<IState> initedStates)
            : base(stateOrder, otherStates, currentStateInitializer, initedStates)
        {

        }

        public override void EnterAction()
        {
            _enemyCharacters = _characterEnemyFinder.EnemyCharacters;
        }

        public override bool EnterCondition()
        {
            return _character.Path.Count == 0;
        }

        public override void ExitAction()
        {
            StateAction();
        }

        public override bool ExitCondition()
        {
            return true;
            //return _character.Path.Count > 0;
        }

        public override void InitComponents(Character character)
        {
            _character = character;
            _characterEnemyFinder = character.GetComponent<CharacterEnemyFinder>();
            _attakArmorSettings = _characterEnemyFinder.ArmorSetting;
        }

        public override void StateAction()
        {
            Dictionary<Character, List<PathElement>> paths = new Dictionary<Character, List<PathElement>>();
            for (int i = 0; i < _enemyCharacters.Count; i++)
            {
                List<PathElement> path = PathFinder.FindPath(_character.CurrentCell, _enemyCharacters[i].CurrentCell);
                if(path != null)
                {
                    paths.Add(_enemyCharacters[i], path);
                }
            }
            int minDistance = ClosestPathDistance(paths);

            KeyValuePair<Character, List<PathElement>> findedPath = GetPriorityPath(GetPathsWithDistance(paths, minDistance));
            if (_character.DebugState)
            {
                Debug.Log("paths.Count " + paths.Count);
                Debug.Log("minDistancet " + minDistance);
            }
            _character.SetPath(findedPath.Value);
            _character.SetTarget(findedPath.Key);
            //_character.Pause(Random.Range(0.1f, 0.4f));
        }


        private int ClosestPathDistance(Dictionary<Character, List<PathElement>> paths)
        {
            int minDistance = int.MaxValue;
            foreach(KeyValuePair<Character, List<PathElement>> path in paths)
            {
                if(minDistance > path.Value.Count)
                {
                    minDistance = path.Value.Count;
                }
            }
            return minDistance;
        }

        private Dictionary<Character, List<PathElement>> GetPathsWithDistance(Dictionary<Character, List<PathElement>> paths, int distance)
        {
            Dictionary<Character, List<PathElement>> distancePaths = new Dictionary<Character, List<PathElement>>();
            foreach (KeyValuePair<Character, List<PathElement>> path in paths)
            {
                if (distance == path.Value.Count)
                {
                    distancePaths.Add(path.Key, path.Value);
                }
            }
            return distancePaths;
        }

        private KeyValuePair<Character, List<PathElement>> GetPriorityPath(Dictionary<Character, List<PathElement>> paths)
        {
            Dictionary<Character, List<PathElement>> applyArmorEnemyPaths = new Dictionary<Character, List<PathElement>>();
            foreach (KeyValuePair<Character, List<PathElement>> path in paths)
            {
                ArmorTypeId applyingArmor = _attakArmorSettings.GetArmor(_character.Attack.Id);
                if (applyingArmor == path.Key.Armor.Id)
                {
                    applyArmorEnemyPaths.Add(path.Key, path.Value);
                }
            }
            if(applyArmorEnemyPaths.Count > 0)
            {
                return applyArmorEnemyPaths.ElementAt(Random.Range(0, applyArmorEnemyPaths.Count));
            }
            else
            {
                return paths.ElementAt(Random.Range(0, paths.Count));
            }
        }

        private List<Character> GetEnemyCharactersWithArmor(List<Character> characters)
        {
            List<Character> charactersWithArmor = new List<Character>();

            for (int i = 0; i < characters.Count; i++)
            {
                ArmorTypeId applyingArmor = _attakArmorSettings.GetArmor(_character.Attack.Id);
                if(applyingArmor == characters[i].Armor.Id)
                {
                    charactersWithArmor.Add(characters[i]);
                }
            }
            return charactersWithArmor;
        }
    }
}