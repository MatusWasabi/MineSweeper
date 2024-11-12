/// <summary>
/// Representing states of minecell, separate concerns into its own separate class
/// Following State Design Pattern. Being a state.
/// </summary>
public interface IMineCellState
{
    public void EnterState();

    // Reversing whatever happened on EnterState phrase.
    // Criticism: This function is not implemented in one of its children
    // This can be interpreted as violation to I in S.O.L.I.D Principle.
    public void BackToDefault();
}
