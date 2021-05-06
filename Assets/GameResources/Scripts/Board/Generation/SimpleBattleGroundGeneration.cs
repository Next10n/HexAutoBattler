using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{

    /// <summary>
    /// Генератор игрового поля
    /// </summary>
    public class SimpleBattleGroundGeneration : MonoBehaviour, IBattleGroundGenerator
    {
        [SerializeField] private HexCell cellPrefab;

        BattleLocation IBattleGroundGenerator.GenerateLocation(BattleGroundBoardSettings settings)
        {
            HexCell[,] generatedCells = new HexCell[settings.Width, settings.Heigth];
            for (int i = 0; i < settings.Width; i++)
            {
                for (int j = 0; j < settings.Heigth; j++)
                {
                    float yOffset = i % 2 == 0 ? 0 : 0.5f;
                    HexCell generatedCell = Instantiate(cellPrefab, new Vector3(i * 0.75f - settings.Width / 2, j + yOffset - settings.Heigth / 2), Quaternion.identity, transform);
                    generatedCell.name = "HexCell " + i + " " + j;
                    generatedCell.SetCoordinates(i, j);
                    generatedCells[i, j] = generatedCell;
                    if (j > 0)
                    {
                        generatedCell.SetNeighbor(Neighbour.South, generatedCells[i, j-1]);
                    }
                    if (i > 0)
                    {
                        if ((i & 1) == 1)
                        {
                            generatedCell.SetNeighbor(Neighbour.SouthWest, generatedCells[i - 1, j]);
                            if (j < settings.Heigth - 1)
                            {
                                generatedCell.SetNeighbor(Neighbour.NorthWest, generatedCells[i - 1, j + 1]);
                            }
                        }
                        else
                        {
                            if (j > 0)
                            {
                                generatedCell.SetNeighbor(Neighbour.SouthWest, generatedCells[i - 1, j - 1]);
                            }
                            generatedCell.SetNeighbor(Neighbour.NorthWest, generatedCells[i - 1, j]);

                        }
                    }
                }
            }
            return new BattleLocation(generatedCells);
        }
    }
}