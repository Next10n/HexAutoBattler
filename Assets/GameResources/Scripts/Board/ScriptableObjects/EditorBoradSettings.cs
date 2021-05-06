using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Настройки поля для едитора
    /// </summary>
    public class EditorBoradSettings : MonoBehaviour
    {
        public static event Action<bool> OnViewCoordinated = delegate { };
        public static event Action<bool> OnViewDistance = delegate { };
        public static event Action<bool> OnViewSelected = delegate { };
        public static event Action<bool> OnViewBlockedCells = delegate { };

        [Header("Отображать координаты")]
        [SerializeField] private bool _viewCoordinates;

        [Header("Oтображение дистанции")]
        [SerializeField] private bool _viewDistance;

        [Header("Отображение выбора клеток")]
        [SerializeField] private bool _viewSelected;

        [Header("Отображать заблокированные клетки")]
        [SerializeField] private bool _viewBlocked;

        private static bool viewCoordinates;
        private static bool viewDistance;
        private static bool viewSelected;
        private static bool viewBloked;

        public static bool ViewCoordinates => viewCoordinates;
        public static bool ViewDistance => viewDistance;
        public static bool ViewSelected => viewSelected;
        public static bool ViewBlocked => viewBloked;

        private void OnValidate()
        {
            viewCoordinates = _viewCoordinates;
            viewDistance = _viewDistance;
            viewSelected = _viewSelected;
            viewBloked = _viewBlocked;
            OnViewCoordinated(_viewCoordinates);
            OnViewDistance(_viewDistance);
            OnViewSelected(_viewSelected);
            OnViewBlockedCells(ViewBlocked);
        }
    }
}