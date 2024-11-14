using UnityEngine;

/// <summary>
/// Base state of Mine Cell.
/// </summary>
public class UnrevealedMineCell : IMineCellState
{
    private MineCell mineCell;

    public UnrevealedMineCell(MineCell cell)
    {
        this.mineCell = cell;
        //Debug.Log("Unrevealed is consutructed");
    }

    // Ensuring that states created is garbaged collected.
    // If states are not freed, it can cause memory leak and runtime null ref error when changing scene.
    ~UnrevealedMineCell()
    {
        mineCell = null;
    } 

    public void Enter()
    {
        mineCell.GetButton().gameObject.SetActive(true);
    }

    public void Execute()
    {
        // When player is in flagging mode.
        if (Hand.Instance.IsHoldingFlag)
        {
            IMineCellState flaggedState = new FlaggedMineCell(mineCell);
            mineCell.SetState(flaggedState);
            return;
        }

        IMineCellState revealedState = new RevealedMineCell(mineCell);
        mineCell.SetState(revealedState);

        // Criticism: This one is not your typically usage of state pattern. 
        // State Execution should be called through high-level controller.
        revealedState.Execute();
    }

    public void Exit()
    {
#if STATE_DEBUG
        Debug.Log("Unrevealed Cell is Exited");
#endif 
    }
}
