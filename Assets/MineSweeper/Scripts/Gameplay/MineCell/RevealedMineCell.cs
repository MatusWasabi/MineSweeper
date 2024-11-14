using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// MineCell State where cell reveals what's under its hood.
/// </summary>
public class RevealedMineCell : IMineCellState
{
    private MineCell mineCell;
    private Color bombBackgroundColor = Color.red;
    private Color defaultBackgroundColor = Color.white;

    public RevealedMineCell(MineCell cell)
    {
        mineCell = cell;
        //Debug.Log("Revealed is constructed");
    }

    public void Enter()
    {
        if (mineCell.GetCellMark() == CellMarkType.BombMark)
        {
            mineCell.GetBackground().color = bombBackgroundColor;
        }
        mineCell.GetButton().gameObject.SetActive(false);

#if STATE_DEBUG
        Debug.Log("Enter Revealed State");
#endif
    }

    public void Execute()
    {
        // Revealing all bombs behind.
        if (mineCell.GetCellMark() == CellMarkType.BombMark)
        {
            foreach (MineCell otherCell in mineCell.GetAllInstances())
            {
                if (otherCell.GetCellMark() == CellMarkType.BombMark && otherCell.GetCellState() is UnrevealedMineCell)
                {
                    otherCell.Click();
                }
            }
            mineCell.NotifyController();
            return;
        }

        // Flood-fill revealing
        if (mineCell.GetCellMark() == 0)
        {
            foreach (MineCell neighbor in mineCell.GetNeighbors())
            {
                if (neighbor.GetCellState() is UnrevealedMineCell)
                {
                    neighbor.Click();
                }
            }
        }

        mineCell.NotifyController();
    }

    public void Exit()
    {
        mineCell.GetButton().gameObject.SetActive(false);
        mineCell.GetBackground().color = defaultBackgroundColor;
        IMineCellState unrevealedState = new UnrevealedMineCell(mineCell);

#if STATE_DEBUG
        Debug.Log("Revealed State Exit");
#endif
    }

}
