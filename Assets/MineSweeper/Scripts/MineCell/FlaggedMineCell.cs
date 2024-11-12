using UnityEngine;

public class FlaggedMineCell : IMineCellState
{
    private bool isFlagged = false;
    private MineCell mineCell;

    public FlaggedMineCell(MineCell mineCell)
    {
        // Debug.Log("Flagged is constructed");
        this.mineCell = mineCell;
    }

    ~FlaggedMineCell()
    {
        Debug.Log("Flagged is deconstructed");
    }

    public void BackToDefault()
    {
        IMineCellState unrevealedMinecell = new UnrevealedMineCell(mineCell);
        mineCell.GetOverlay().gameObject.SetActive(false);
        mineCell.SetState(unrevealedMinecell);
    }

    public void EnterState()
    {
        if (!Hand.Instance.IsHoldingFlag) { return; }

        isFlagged = !isFlagged;
        mineCell.GetOverlay().gameObject.SetActive(isFlagged);
    }

    private void OnMineCellDestroyed()
    {
        mineCell = null;
    }


}
