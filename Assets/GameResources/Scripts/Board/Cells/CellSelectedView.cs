using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Вью выбранной клетки
    /// </summary>
    public class CellSelectedView : MonoBehaviour
    {
        [SerializeField] private CellSelectHandler cellSelectHandler;

        private void Awake()
        {
            cellSelectHandler.OnSelectCell += View;
            View(false);
        }

        private void View(bool isShow)
        {
            gameObject.SetActive(EditorBoradSettings.ViewSelected ? isShow : false);
        }

        private void OnDestroy()
        {
            cellSelectHandler.OnSelectCell -= View;
        }
    }
}