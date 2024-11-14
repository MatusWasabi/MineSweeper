using UnityEngine;

/// <summary>
/// When player wants to visually mark a cell as bomb cell by flagging it.
/// </summary>
public class FlaggedMineCell : IMineCellState
{
    private MineCell mineCell;

    public FlaggedMineCell(MineCell mineCell)
    {
        this.mineCell = mineCell;
    }

    public void Enter()
    {
        mineCell.GetOverlay().gameObject.SetActive(true);
    }


    public void Execute()
    {
        if (!Hand.Instance.IsHoldingFlag) return;
        IMineCellState unrevealedState = new UnrevealedMineCell(mineCell);
        mineCell.SetState(unrevealedState);
    }

    public void Exit()
    {
        mineCell.GetOverlay().gameObject.SetActive(false);
    }


}
