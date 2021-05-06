using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    /// <summary>
    /// Гексовая клетка игрового поля
    /// </summary>
    public class HexCell : MonoBehaviour
    {
        public event Action OnBlock = delegate { };

        [SerializeField]
        private HexCoordinates _hexCoordinates;

        [SerializeField]
        private CellSelectHandler _cellSelectHandler;

        [SerializeField]
        private CellDistanceView _cellDistanceView;

        [SerializeField]
        private List<CellNeighbour> _cellNeighbours;

        [SerializeField]
        private bool _blocked;

        public HexCoordinates Coordinates => _hexCoordinates;
        public CellSelectHandler Selector => _cellSelectHandler;
        public CellDistanceView DistanceView => _cellDistanceView;
        public List<CellNeighbour> CellNeighbours => _cellNeighbours;
        public bool Blocked => _blocked;

        public int SearchHeuristic { get; set; }
        public Character Character { get; private set; }

        public int SearchPriority
        {
            get
            {
                return pathElemet.CurrentDistance + SearchHeuristic;
            }
        }

        public HexCell NextWithSamePriority { get; set; }

        public PathElement pathElemet;

        private void Awake()
        {
            ResetPaths();
        }

        public void ResetPaths()
        {
            pathElemet = new PathElement(this, this, 0);
        }

        public void SetCoordinates(int x, int y)
        {
            _hexCoordinates = HexCoordinates.FromOffsetCoordinates(x, y);
        }

        public HexCell GetNeighbor(Neighbour neighbour)
        {
            return _cellNeighbours.Find(x => x.Neighbour == neighbour).Cell;
        }

        public void SetNeighbor(Neighbour neighbour, HexCell cell)
        {
            if(_cellNeighbours.Find(x => x.Neighbour == neighbour) == null)
            {
                _cellNeighbours.Add(new CellNeighbour(neighbour, cell));
                cell.SetNeighbor(neighbour.Opposite(), this);
            }                      
        }

        public void Block()
        {
            _blocked = true;
            OnBlock();
        }

        public void UnBlock()
        {
            _blocked = false;
            OnBlock();
        }

        public void SetCharacter(Character character)
        {
            Character = character;
        }

        public void RemoveCharacter()
        {
            Character = null;
        }


    }
}