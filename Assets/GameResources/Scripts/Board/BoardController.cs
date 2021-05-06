using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Контроллер локации для боя
    /// </summary>
    public class BoardController : MonoBehaviour
    {
        [Header("Объект для генерации локации")]
        [SerializeField] private GameObject battleGroundGeneratorObject;
        [SerializeField] private BattleGroundBoardSettings settings;
        private IBattleGroundGenerator _battleGroundGenerator;

        public BattleLocation BattleLocation { get; private set; }

        private void OnValidate()
        {
            if (battleGroundGeneratorObject.TryGetComponent(out IBattleGroundGenerator battleGrountGenerator))
            {
                _battleGroundGenerator = battleGrountGenerator;
            }
            else
            {
                battleGroundGeneratorObject = null;
            }
        }

        private void Awake()
        {
            _battleGroundGenerator = battleGroundGeneratorObject.GetComponent<IBattleGroundGenerator>();
            BattleLocation =_battleGroundGenerator.GenerateLocation(settings);
        }
    }
}