using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Нахождение дистанции от выбранной точки до всех остальных
    /// </summary>
    public class AllCellDistance : MonoBehaviour
    {
        [SerializeField] private BoardController _boardController;
        [SerializeField] private CellSelector _cellSelector;
        [SerializeField] private bool delay;

        private const float DELAY = 0.001f;

        private List<CellDistanceView> _distanceViews;

        private Coroutine findCoroutine;

        private void Awake()
        {
            _cellSelector.OnCelectCell += ViewDistanceToAll;
        }

        private void ViewDistanceToAll(HexCell hexCell)
        {
            //foreach (HexCell boardCell in _boardController.BattleLocation.Cells)
            //{
            //    int distance = CellDistanceCalculator.CalculateDistance(hexCell, boardCell);
            //    boardCell.GetComponentInChildren<CellDistanceView>().ViewDistance(distance);
            //}
            if(findCoroutine != null)
            {
                StopCoroutine(findCoroutine);
            }
        //    findCoroutine = StartCoroutine(Search(hexCell));
        }

        //private IEnumerator Search(HexCell cell)
        //{
        //    List<HexCell> findedCells = new List<HexCell>();
        //    Queue<HexCell> queueCells = new Queue<HexCell>();
        //    cell.DistanceView.ViewDistance(0);
        //    queueCells.Enqueue(cell);
        //    while (queueCells.Count > 0)
        //    {
        //        if (delay)
        //        {
        //            yield return new WaitForSeconds(DELAY);
        //        }              
        //        HexCell current = queueCells.Dequeue();
        //        if (findedCells.Contains(current) == false && current.Blocked == false)
        //        {
        //            int distance;
        //            if(cell.DistanceCollection.TryGetValue(current, out int currentDistance))
        //            {
        //                distance = currentDistance;
        //            }
        //            else
        //            {
        //                current.DistanceCollection.TryGetValue(cell, out int selfDistance);
        //                distance = selfDistance;
        //                distance++;
        //            }                    
        //            current.DistanceView.ViewDistance(distance);
        //            findedCells.Add(current);
        //            foreach (CellNeighbour neighbour in current.CellNeighbours)
        //            {
        //                if(queueCells.Contains(neighbour.Cell) == false)
        //                {
        //                    if(neighbour.Cell.DistanceCollection.ContainsKey(cell) == false)
        //                    {
        //                        neighbour.Cell.DistanceCollection.Add(cell, distance);
        //                    }                            
        //                    queueCells.Enqueue(neighbour.Cell);
        //                }
        //            }
                    
        //        }

        //    }
        //    yield return null;
        //}

        private void OnDestroy()
        {
            _cellSelector.OnCelectCell -= ViewDistanceToAll;
        }
    }
}