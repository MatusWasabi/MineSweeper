using UnityEngine;

/// <summary>
/// Singleton reference to mode of player clicking.
/// </summary>
public class Hand : MonoBehaviour, IResettable
{
    public static Hand Instance { get; private set; }

    private bool isHoldingFlag = false;
    public bool IsHoldingFlag
    {
        get { return isHoldingFlag; }
        private set
        {
            isHoldingFlag = value;
        }
    }

    private void Awake()
    {
        // Check if an instance already exists and destroy this one if it does
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set the instance to this instance
        Instance = this;

        // Optionally, make this instance persist across scenes
        DontDestroyOnLoad(gameObject);
    }

    public void StopFlagHold()
    {
        IsHoldingFlag = false;
    }

    public void StartFlagHold()
    {
        IsHoldingFlag = true;
    }

    public void AcceptResetter(Resetter resetter)
    {
        resetter.ResetHand(this);
    }
}
