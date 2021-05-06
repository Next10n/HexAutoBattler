using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BattleSystem
{
    /// <summary>
    /// Дистанция до текущей клетки
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class CellDistanceView : MonoBehaviour
    {
        private Text _distanceToCellView;

        private void Awake()
        {
            _distanceToCellView = GetComponent<Text>();
            EditorBoradSettings.OnViewDistance += View;
            View(EditorBoradSettings.ViewDistance);
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            EditorBoradSettings.OnViewDistance -= View;
        }

        public void View(bool isShow)
        {
            gameObject.SetActive(isShow);
        }

        /// <summary>
        /// Отобразить дистанцию до клетки
        /// </summary>
        public void ViewDistance(int distance)
        {
            _distanceToCellView.text = distance.ToString();
        }
    }
}
