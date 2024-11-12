using TMPro;
using UnityEngine;


public class Timer : MonoBehaviour, IResettable
{
    private const int timeInterval = 1;
    private int timePlayed = 0;

    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private AudioSource tickSound;

    private int TimePlayed
    {
        get => timePlayed;
        set
        {
            timePlayed = value;
            textMeshPro.text = timePlayed.ToString();
        }
    }

    private void Start()
    {
        StartCount();
    }

    public void StartCount()
    {
        CancelInvoke();
        TimePlayed = 0;
        // Using nameof() instead of just hard-coded string. Just to avoid magic variable
        InvokeRepeating(nameof(Count), 0f, timeInterval);
    }

    public void StopCount()
    {
        CancelInvoke(nameof(Count));
    }

    public void AcceptResetter(Resetter resetter)
    {
        resetter.ResetTimer(this);
    }

    private void Count()
    {
        TimePlayed++;
        tickSound.Play();
    }
}
