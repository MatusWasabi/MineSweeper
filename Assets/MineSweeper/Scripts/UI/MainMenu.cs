using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

/// <summary>
/// UI Toolkit functionality, specifically for Main Menu
/// </summary>
public class MainMenu : MonoBehaviour
{
    [SerializeField] private UIDocument document;
    [SerializeField] private UnityEvent onStartGameClicked;
    [SerializeField] private UnityEvent onButtonStartTransit;
    private VisualElement root;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        // Reference to button of UI Toolkit with its name.
        Button startButton = root.Q<Button>("Start");
        Button exitButton = root.Q<Button>("Exit");

        // Registering its callback (Observer pattern here.)
        startButton.RegisterCallback<ClickEvent>(StartClick);
        exitButton.RegisterCallback<ClickEvent>(ExitClick);

        var buttons = root.Query<Button>().ToList();
        foreach (var button in buttons)
        {
            button.RegisterCallback<TransitionStartEvent>(ButtonTransit);
        }
    }

    private void StartClick(ClickEvent clickEvent)
    {
        onStartGameClicked.Invoke();
        Debug.Log("Start Game!");
    }

    private void ButtonTransit(TransitionStartEvent startEvent)
    {
        onButtonStartTransit.Invoke();
    }

    private void ExitClick(ClickEvent clickEvent)
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Exit play mode in the editor
#else
        Application.Quit();  //Quit application if in a build
#endif

    }


}
