using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BattleSystem
{
    /// <summary>
    /// Вьюшка координат клетов
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class CellCoordinatesView : MonoBehaviour
    {
        [SerializeField] private HexCell hexCell;

        private Text text;

        private void Awake()
        {
            text = GetComponent<Text>();
            EditorBoradSettings.OnViewCoordinated += View;
            View(EditorBoradSettings.ViewCoordinates);
        }

        private void View(bool isShow)
        {
            gameObject.SetActive(isShow);
        }

        private void Start()
        {
            text.text = hexCell.Coordinates.X + "\n" + hexCell.Coordinates.Y + "\n";// + hexCell.Coordinates.Z;
        }

        private void OnDestroy()
        {
            EditorBoradSettings.OnViewCoordinated -= View;
        }
    }
}