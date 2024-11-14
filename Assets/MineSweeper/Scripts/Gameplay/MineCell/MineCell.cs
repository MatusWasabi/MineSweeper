using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Script for composing up a minecell for a prefab so that it can be controlled as low-level code
/// by MineSweeperController.
/// </summary>
public class MineCell : MonoBehaviour
{
    private IMineCellState currentState;
    private int cellMark = 999; // If it's 999, means it's not set. 
    private HashSet<MineCell> neighbors = new HashSet<MineCell>();
    // Instead of simple static collection, weak reference is used as it will be garbaged collected on same cycle as this mono
    // Preventing memory leakage and unused strong reference.
    private static List<WeakReference<MineCell>> instances = new List<WeakReference<MineCell>>();
    public UnityAction OnDestroyed;

    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI stateDisplay;
    [SerializeField] private Image background;
    [SerializeField] private Image overlay;
    [HideInInspector] public UnityEvent<int> onRevealed; // Used for communicate with controller.

    public int GetCellMark() => cellMark;
    public Button GetButton() => button;
    public Image GetBackground() => background;
    public Image GetOverlay() => overlay;
    public IEnumerable<MineCell> GetNeighbors() => neighbors;
    public IMineCellState GetCellState() => currentState;

    public IEnumerable<MineCell> GetAllInstances()
    {
        // Clean out unused ref.
        instances.RemoveAll(weakRef => !weakRef.TryGetTarget(out _));
        return instances
            .Select(weakRef => weakRef.TryGetTarget(out MineCell target) ? target : null)
            .Where(instance => instance != null)
            .ToList();
    }

    public void SetState(IMineCellState state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }

    public void SetMark(int mark)
    {
        cellMark = mark;
        stateDisplay.text = mark.ToString();

        Color textColor = Color.white;

        // Setting text color based on how many bombs are around.
        // Criticism: This is not designer-friendly method.
        switch (cellMark)
        {
            case CellMarkType.BombMark:
                stateDisplay.text = "";
                break;
            case 0:
                textColor = Color.clear;
                break;
            case 1:
                textColor = Color.blue;
                break;
            case 2:
                textColor = Color.green;
                break;
            case 3:
                textColor = Color.red;
                break;
            case 4:
                textColor = Color.magenta;
                break;
            case 5:
                textColor = Color.yellow;
                break;
            case 6:
                textColor = Color.cyan;
                break;
            case 7:
                textColor = Color.black;
                break;
            case 8:
                textColor = Color.grey;
                break;
        }

        stateDisplay.color = textColor;

    }

    public void SetNeighbors(IEnumerable<MineCell> mineCells)
    {
        neighbors = new HashSet<MineCell>(mineCells);
    }

    private void Start()
    {
        instances.Add(new WeakReference<MineCell>(this));
        button.onClick.AddListener(Click);
        SetState(new UnrevealedMineCell(this));
    }

    private void OnDestroy()
    {
        // Ensuring that .Net Object will be derefed and Garbage collected.
        instances.Clear();
        currentState = null;
    }

    public void Click()
    {
        currentState.Execute();
    }

    public void ResetCell()
    {
        SetState(new UnrevealedMineCell(this));
    }

    public void NotifyController()
    {
        onRevealed.Invoke(cellMark);
    }

}
