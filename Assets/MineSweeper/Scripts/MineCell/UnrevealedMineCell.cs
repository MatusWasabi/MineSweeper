using UnityEngine;

/// <summary>
/// Base state of Mine Cell.
/// </summary>
public class UnrevealedMineCell : IMineCellState
{
    private MineCell cell;
    private RevealedMineCell revealedState;
    private IMineCellState flaggedState;

    public UnrevealedMineCell(MineCell cell)
    {
        this.cell = cell;
        revealedState = new RevealedMineCell(cell);
        flaggedState = new FlaggedMineCell(cell);
        // Debug.Log("Unrevealed is consutructed");
    }

    // Ensuring that states created is garbaged collected.
    // If states are not freed, it can cause memory leak and runtime null ref error when changing scene.
    ~UnrevealedMineCell()
    {
        revealedState.Dispose();
        cell = null;
        Debug.Log("Unrevealed is descontructed");
    } 

    public void EnterState()
    {
        if (Hand.Instance.IsHoldingFlag)
        {
            cell.SetState(flaggedState);
            flaggedState.EnterState();
            return;
        }

        Disclose();
        revealedState.EnterState();

        if (cell.GetCellMark() == 0)
        {
            FillNeighborCells();
        }
    }
    private void Disclose()
    {
        if (!cell)
        {
            Debug.Log("Cell is missing");
        }
        cell.GetButton().gameObject.SetActive(false);
        cell.SetState(revealedState);
    }

    /// This can be viewed as I violation in SOLID.
    public void BackToDefault()
    {
        Debug.Log("This is base state");
    }

    private void FillNeighborCells()
    {
        foreach (MineCell neighbor in cell.GetNeighbors())
        {
            if (neighbor.GetCellState() is UnrevealedMineCell)
            {
                neighbor.Click();
            }
        }
    }
}
