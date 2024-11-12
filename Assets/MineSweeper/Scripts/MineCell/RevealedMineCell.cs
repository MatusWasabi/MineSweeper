using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// MineCell State where cell reveals what's under its hood.
/// </summary>
public class RevealedMineCell : IMineCellState, IDisposable
{
    private MineCell mineCell;
    private Color bombBackgroundColor = Color.red;
    private Color previousBackgroundColor;
    // Using Weak Ref so that it can be Garbage collected even if it is static collection.
    private static List<WeakReference<RevealedMineCell>> instances = new List<WeakReference<RevealedMineCell>>();

    public RevealedMineCell(MineCell cell)
    {
        mineCell = cell;
        previousBackgroundColor = cell.GetBackground().color;
        instances.Add(new WeakReference<RevealedMineCell>(this));
        // Debug.Log("Revealed is constructed");
    }

    ~RevealedMineCell()
    {
        Debug.Log("Revealed is deconstructed");
    }

    public void EnterState()
    {
        RevealMark();
    }

    private void RevealMark()
    {
        if (mineCell.GetCellMark() == CellMarkType.BombMark)
        {
            RevealAllBombs();
        }

        mineCell.NotifyController();
    }

    public void BackToDefault()
    {
        mineCell.GetBackground().color = previousBackgroundColor;
        mineCell.GetButton().gameObject.SetActive(true);
        IMineCellState unrevealedState = new UnrevealedMineCell(mineCell);
        mineCell.SetState(unrevealedState);
    }

    public void Dispose()
    {
        // _ representing that this code won't create any variable with "out" keyword.
        instances.RemoveAll(weakRef => !weakRef.TryGetTarget(out _));
    }


    // Reveal all bombs on the board including itself.
    private static void RevealAllBombs()
    {

        foreach (WeakReference<RevealedMineCell> weakRevealed in instances)
        {
            if (weakRevealed.TryGetTarget(out RevealedMineCell revealed))
            {
                if (revealed.mineCell.GetCellMark() != CellMarkType.BombMark) continue;
                IMineCellState cellState = revealed.mineCell.GetCellState();
                if (cellState is UnrevealedMineCell unrevealedCell)
                {
                    unrevealedCell.EnterState();
                }
                revealed.mineCell.GetBackground().color = revealed.bombBackgroundColor;
            }
        }
    }
}
