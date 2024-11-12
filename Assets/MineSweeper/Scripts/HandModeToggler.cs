using UnityEngine;
using UnityEngine.UIElements;

public class HandModeToggler : MonoBehaviour
{
    [SerializeField] private Button button;

    private void Start()
    {
        Hand.Instance.StopFlagHold();
    }
    public void Toggle()
    {
        if (Hand.Instance.IsHoldingFlag)
        {
            Hand.Instance.StopFlagHold();
            return;
        }

        if (!Hand.Instance.IsHoldingFlag)
        {
            Hand.Instance.StartFlagHold();
            return;
        }
    }
}
