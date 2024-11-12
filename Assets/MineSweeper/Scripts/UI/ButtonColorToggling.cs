using UnityEngine;
using UnityEngine.UI;

public class ButtonColorToggling : MonoBehaviour
{

    private bool isToggled = false;
    [SerializeField] private Button button;
    [SerializeField] private Color untoggledColor;
    [SerializeField] private Color toggledColor;

    public void Toggle()
    {
        isToggled = !isToggled;
        button.image.color = isToggled ? toggledColor : untoggledColor;
    }


}

