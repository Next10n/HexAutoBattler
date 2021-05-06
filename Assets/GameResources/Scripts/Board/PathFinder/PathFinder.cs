using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    [System.Serializable]
    public struct PathElement
    {
        public HexCell StartCell;
        public HexCell PathCell;
        public int CurrentDistance;

        public PathElement(HexCell startCell, HexCell currentCell, int distance)
        {
            StartCell = startCell;
            PathCell = currentCell;
            CurrentDistance = distance;
        }

        public PathElement(PathElement pathElement)
        {
            StartCell = pathElement.StartCell;
            PathCell = pathElement.PathCell;
            CurrentDistance = pathElement.CurrentDistance;
        }
    }

    /// <summary>
    /// Нахождение пути
    /// </summary>
    public static class PathFinder
    {
        public static List<PathElement> FindPath(HexCell startCell, HexCell finishCell)
        {
            List<PathElement> pathElements = new List<PathElement>();
            List<HexCell> findedCells = new List<HexCell>();

            HexCellPriorityQueue queueCells = new HexCellPriorityQueue();
            queueCells.Enqueue(startCell);
            while (queueCells.Count > 0)
            {
                HexCell current = queueCells.Dequeue();
                if (current == finishCell)
                {
                    findedCells.Add(current);
                    while (current != startCell)
                    {
                        pathElements.Add(new PathElement(current.pathElemet));
                        current = current.pathElemet.PathCell;
                    }
                    break;
                }
                if (findedCells.Contains(current) == false  && current.Blocked == false)
                {
                    int distance;
                    distance = current.pathElemet.CurrentDistance;
                    distance++;
                    findedCells.Add(current);
                    foreach (CellNeighbour neighbour in current.CellNeighbours)
                    {
                        if (queueCells.Contains(neighbour.Cell) == false)
                        {                            
                            if(neighbour.Cell.Character == null || neighbour.Cell == finishCell)
                            {
                                int oldPriority = neighbour.Cell.pathElemet.CurrentDistance;
                                if (neighbour.Cell.pathElemet.PathCell == neighbour.Cell)
                                {
                                    neighbour.Cell.pathElemet.StartCell = startCell;
                                    neighbour.Cell.pathElemet.PathCell = current;
                                    neighbour.Cell.pathElemet.CurrentDistance = distance;
                                    neighbour.Cell.SearchHeuristic = CellDistanceCalculator.CalculateDistance(neighbour.Cell, finishCell);
                                }
                                if (distance < neighbour.Cell.pathElemet.CurrentDistance)
                                {
                                    queueCells.Change(neighbour.Cell, oldPriority);
                                }
                                else
                                {
                                    queueCells.Enqueue(neighbour.Cell);
                                }
                            }

                        }                   

                    }
                }
            }
            foreach (HexCell hexCell in findedCells)
            {
                finishCell.ResetPaths();
                foreach (CellNeighbour neighbour in hexCell.CellNeighbours)
                {
                    neighbour.Cell.ResetPaths();
                }
            }
            return pathElements;

        }
    }
}