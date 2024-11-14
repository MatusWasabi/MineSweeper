using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Core Controller of minesweeper that will connect .NET C# with Monobehavior
/// </summary>
public class MineSweeperController : MonoBehaviour, IResettable
{
    private int cleanCell;
    public bool isGameFinished;
    private MineSweeper mineSweeper;
    // References to all cells that we will created from this
    private List<MineCell> cells = new List<MineCell>();

    [SerializeField] private int width = 0;
    [SerializeField] private int height = 0;
    [SerializeField] private int mineCount = 0;
    [SerializeField] private MineCell cellPrefab;
    [SerializeField] private Transform cellParent;

    [SerializeField] private UnityEvent onGameLose;
    [SerializeField] private UnityEvent onGameWin;


    private void Start()
    {
        InitializeGame();
    }

    public void Generate()
    {
        mineSweeper = new MineSweeper(width, height, mineCount);
        mineSweeper.Generate();
        mineSweeper.PrintGrid(); // For debugging purpose.
    }

    public void ResetCells()
    {
        int index = 0;
        // Doing this instead of nested for-loop.
        foreach (int grid in mineSweeper.GetGrid())
        {
            cells[index].SetMark(grid);
            cells[index].ResetCell();
            index++;
        }
    }

    public void SetCellNeighbors()
    {
        // Mimicking 2d array behavior of original cell.
        MineCell[,] cellGrids = new MineCell[width, height];
        ReshapingArray(cellGrids, cells);


        // Loop for each element in 2D array to set each and individual neighbor reference.
        IterativeSetCellNeightbor(cellGrids);

        cleanCell = (width * height) - mineCount;
    }

    private void IterativeSetCellNeightbor(MineCell[,] cellGrids)
    {
        for (int i = 0; i < cellGrids.GetLength(0); i++)
        {
            for (int j = 0; j < cellGrids.GetLength(1); j++)
            {
                // Get possible locations from board.
                IEnumerable neighborLocations = mineSweeper.GetNeighbors(i, j);

                IEnumerable<MineCell> neighbors = new List<MineCell>();
                foreach ((int, int) neighborLocation in neighborLocations)
                {
                    neighbors = neighbors.Append(cellGrids[neighborLocation.Item1, neighborLocation.Item2]);
                }
                cellGrids[i, j].SetNeighbors(neighbors);
            }
        }
    }

    private void ReshapingArray(MineCell[,] destinationArray, List<MineCell> sourceArray)
    {
        for (int i = 0; i < sourceArray.Count(); i++)
        {
            int x = i / width;
            int y = i % width;
            destinationArray[x, y] = sourceArray[i];
        }
    }

    public void AcceptResetter(Resetter resetter)
    {
        resetter.ResetController(this);
    }

    private void CheckIfBomb(int state)
    {
        if (isGameFinished) return;

        if (state == CellMarkType.BombMark)
        {
            Debug.Log("Game Over");
            onGameLose.Invoke();
            isGameFinished = true;
            return;
        }

        cleanCell--;
        Debug.Log($"{cleanCell} Clean cells left");
        if (cleanCell <= 0)
        {
            Debug.Log("Game Won");
            onGameWin.Invoke();
            isGameFinished = true;
            return;
        }
    }

    private void InitializeGame()
    {
        Generate();
        InitializeCells();
        SetCellNeighbors();
    }

    private void InitializeCells()
    {
        foreach (int grid in mineSweeper.GetGrid())
        {
            MineCell instance = Instantiate(cellPrefab, cellParent);
            instance.SetMark(grid);
            instance.onRevealed.AddListener(CheckIfBomb);
            cells.Add(instance);
        }
    }




}
