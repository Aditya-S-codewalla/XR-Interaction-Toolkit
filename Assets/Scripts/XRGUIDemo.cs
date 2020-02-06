using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class XRGUIDemo : MonoBehaviour
{
    [SerializeField] private Image background;

    [SerializeField] private Button exampleButton;
    [SerializeField] private Slider exampleSlider;
    [SerializeField] private Toggle exampleToggle;

    [SerializeField] private TextMeshProUGUI textField;

    [SerializeField]private float fixedFontSize = 20f;

    private static readonly string testString1 = "__̴ı̴̴̡̡̡ ̡͌l̡̡̡ ̡͌l̡*̡̡ ̴̡ı̴̴̡ ̡̡͡|̲̲̲͡͡͡ ̲▫̲͡ ̲̲̲͡͡π̲̲͡͡ ̲̲͡▫̲̲͡͡ ̲|̡̡̡ ̡ ̴̡ı̴̡̡ ̡͌l̡̡̡̡.___";
    private static readonly string testString2 = "♫♪.ılılıll|̲̅̅●̲̅̅|̲̅̅=̲̅̅|̲̅̅●̲̅̅|llılılı.♫♪";
    private bool textFieldValueChanger = false;

    private void Awake()
    {
        textField.fontSize = fixedFontSize;

        exampleButton.onClick.AddListener(() =>
        {
            textFieldValueChanger = !textFieldValueChanger;
            textField.text = textFieldValueChanger ? testString1 : testString2;
            
        });

        exampleSlider.onValueChanged.AddListener((float value) => {
            textField.fontSize = fixedFontSize * value;
        });

        exampleToggle.onValueChanged.AddListener((bool value) =>
        {
            Color currentColor = background.color;
            currentColor.a = value ? 24 : 0;
            background.color = currentColor;
        });
    }

    
}
