using UnityEngine;


/// <summary>
/// Applied Visitor pattern here. This is visitter
/// Rationale: If there is a class that cannot be edited. But want it to add functionality to it.
/// We can use Visitor<see cref="https://refactoring.guru/design-patterns/visitor"/> pattern in that case. 
/// </summary>
public class Resetter : MonoBehaviour
{
    public void ResetBase(IResettable resettable)
    {
        Debug.Log($"You need to implemented function for {resettable.GetType().Name} class");
    }

    public void ResetController(MineSweeperController controller)
    {
        controller.isGameFinished = false;
        controller.Generate();
        controller.ResetCells();
        controller.SetCellNeighbors();
    }

    public void ResetTimer(Timer timer)
    {
        timer.StartCount();
    }

    public void ResetHand(Hand hand)
    {
        hand.StopFlagHold();
    }
}
