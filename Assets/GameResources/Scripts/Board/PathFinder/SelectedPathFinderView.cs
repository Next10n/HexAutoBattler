using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Отображение найденного пути для двух точек
    /// </summary>
    public class SelectedPathFinderView : MonoBehaviour
    {
        [SerializeField] private SelectedCellFindPath selectedCellFindPath;
        [SerializeField] private BoardController boardController;

        private void Awake()
        {
            selectedCellFindPath.OnFindPath += ViewPath;
        }

        private void ViewPath(List<PathElement> path)
        {
            foreach(HexCell hexCell in boardController.BattleLocation.Cells)
            {
                hexCell.DistanceView.View(false);
            }
            for (int i = 0; i < path.Count; i++)
            {
                path[i].PathCell.DistanceView.View(true);
                path[i].PathCell.DistanceView.ViewDistance(path[i].CurrentDistance);
            }
           
        }

        private void OnDestroy()
        {
            selectedCellFindPath.OnFindPath -= ViewPath;
        }
    }
}