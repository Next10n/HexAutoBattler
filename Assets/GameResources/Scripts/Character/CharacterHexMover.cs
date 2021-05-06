using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Передвижение персонажа
    /// </summary>
    public class CharacterHexMover : MonoBehaviour
    {
        [SerializeField] private bool _moving = true;
        [SerializeField] private CharacterPathFinder _pathFinder;
        [SerializeField] private float moveDelay = 0.2f;
        private const float moveOffset = 0.01f;

        public HexCell CurrentCell { get; private set; }
        public HexCell MovingCell { get; private set; }

        private CharacterArmyId _id;
        private Coroutine _movingCoroutine;

        public void SetId(CharacterArmyId id)
        {
            _id = id;
        }

        public void SetCell(HexCell cell)
        {
            CurrentCell = cell;
            //CurrentCell.SetCharacter(this);
        }

        private void OnEnable()
        {
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while (_moving)
            {
                yield return new WaitForSeconds(moveDelay);
                List<PathElement> paths = _pathFinder.FindPathToRandomEnemy(CurrentCell, _id);
                if(paths.Count >= 2)
                {
                    MovingCell = paths[paths.Count - 2].PathCell;
                    if (MovingCell.Character == null)
                    {
                        //MovingCell.SetCharacter(this);
                        while (Mathf.Abs(Vector2.Distance(transform.position, MovingCell.transform.position)) > moveOffset)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, MovingCell.transform.position, Time.deltaTime);
                            yield return null;
                        }
                        CurrentCell.RemoveCharacter();
                        CurrentCell = MovingCell;
                    }

                    yield return null;
                }

            }

        }


    }
}
