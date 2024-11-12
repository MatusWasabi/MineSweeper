using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Core function in implementing this minesweeper game. 
/// This is just a plain C# code that can be used in other places as well. Such as Command-line interface game.
/// </summary>
public class MineSweeper
{
    private readonly int width = 3;
    private readonly int height = 3;
    private readonly int mineCount = 20;
    private int[,] grid;
    private const int bombMark = CellMarkType.BombMark;


    public MineSweeper(int width, int height, int mineCount)
    {
        this.width = width;
        this.height = height;
        this.mineCount = mineCount;
        grid = new int[width, height];
    }

    public int[,] GetGrid() => grid;

    public void Generate()
    {
        for (int i = 0; i < mineCount; i++)
        {
            int x, y;
            do
            {
                x = Random.Range(0, width);
                y = Random.Range(0, height);
            } while (grid[x, y] == bombMark);
            grid[x, y] = bombMark;

            UpdateSurroundingCells(x, y);
        }
    }

    private void UpdateSurroundingCells(int x, int y)
    {
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                int newX = x + i;
                int newY = y + j;
                if (IsValidPosition(newX, newY) && grid[newX, newY] != bombMark)
                {
                    grid[newX, newY]++;
                }
            }
        }
    }


    public void PrintGrid()
    {
        StringBuilder sb = new StringBuilder();

        // Output the 2D array
        for (int i = 0; i < grid.GetLength(0); i++) // Iterate through rows
        {
            for (int j = 0; j < grid.GetLength(1); j++) // Iterate through columns
            {
                sb.Append(grid[i, j]); // Append each element to StringBuilder
            }
            sb.AppendLine(); // Add a new line after each row
        }

        // Output the built string to the console
        Debug.Log(sb.ToString());
    }

    public IEnumerable<(int, int)> GetNeighbors(int x, int y)
    {
        IEnumerable<(int, int)> neighbors = new List<(int, int)>();
        // Left, center, right
        for (int i = -1; i <= 1; i++)
        {
            // Top, center, bottom
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                {
                    continue;
                }

                int newX = x + i;
                int newY = y + j;

                if (IsValidPosition(newX, newY))
                {
                    neighbors = neighbors.Append((newX, newY));
                }
            }
        }
        return neighbors;
    }

    private bool IsValidPosition(int x, int y)
    {
        return x >= 0 && y >= 0 && x < width && y < height;
    }
}
