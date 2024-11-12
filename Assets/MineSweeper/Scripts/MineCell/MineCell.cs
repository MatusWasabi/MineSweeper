using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MineCell : MonoBehaviour
{
    private IMineCellState currentState;
    private int cellMark = 999; // If it's 999, means it's not set. 
    private HashSet<MineCell> neighbors = new HashSet<MineCell>();
    public UnityAction OnDestroyed;

    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI stateDisplay;
    [SerializeField] private Image background;
    [SerializeField] private Image overlay;
    [HideInInspector] public UnityEvent<int> onRevealed;

    public int GetCellMark() => cellMark;
    public Button GetButton() => button;
    public Image GetBackground() => background;
    public Image GetOverlay() => overlay;
    public IEnumerable<MineCell> GetNeighbors() => neighbors;
    public IMineCellState GetCellState() => currentState;

    public void SetState(IMineCellState state)
    {
        currentState = state;
    }

    public void SetMark(int mark)
    {
        cellMark = mark;
        stateDisplay.text = mark.ToString();

        Color textColor = Color.white;

        // Setting text color based on how many bombs are around.
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
    private void Start()
    {
        button.onClick.AddListener(Click);
        currentState = new UnrevealedMineCell(this);
    }

    private void OnDestroy()
    {
        // Ensuring that .Net Object will be derefed and Garbage collected.
        currentState = null;
    }

    public void SetNeighbors(IEnumerable<MineCell> mineCells)
    {
        neighbors = new HashSet<MineCell>(mineCells);
    }

    public void Click()
    {
        currentState.EnterState();
    }

    public void ResetCell()
    {
        currentState.BackToDefault();
    }

    public void NotifyController()
    {
        onRevealed.Invoke(cellMark);
    }

}
