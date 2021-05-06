using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Вьюшка блокировки клетки
    /// </summary>
    public class BlockedCellView : MonoBehaviour
    {
        [SerializeField] private HexCell hexCell;

        private void Awake()
        {
            EditorBoradSettings.OnViewBlockedCells += View;
            View(EditorBoradSettings.ViewBlocked);
            hexCell.OnBlock += View;
        }

        private void View()
        {
            View(true);
        }

        private void View(bool isShow)
        {
            gameObject.SetActive(isShow ? hexCell.Blocked : false);
        }

        private void OnDestroy()
        {
            EditorBoradSettings.OnViewBlockedCells -= View;
            hexCell.OnBlock -= View;
        }
    }
}