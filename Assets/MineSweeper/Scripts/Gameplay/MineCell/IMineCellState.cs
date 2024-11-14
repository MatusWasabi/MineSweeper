/// <summary>
/// Representing states of minecell, separate concerns into its own separate class
/// Following State <see cref="https://refactoring.guru/design-patterns/state"/> Design Pattern. Being a state.
/// </summary>
public interface IMineCellState
{
    /// <summary>
    /// Used for initialization and UI handling ONLY
    /// </summary>
    public void Enter();

    /// <summary>
    /// Used for handling logics and state specfic.
    /// </summary>
    public void Execute();

    /// <summary>
    /// Used for finalization and UI handling ONLY
    /// </summary>
    public void Exit();
}
