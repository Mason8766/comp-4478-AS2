using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//used for TextMeshProUGUI
using UnityEngine.UI;
using TMPro;
public class display : MonoBehaviour
{
    static private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>(); //sets text to the textbox
        
    }
    public static void gameText()
    {
        text.text = "GAME\nOVER";//set the text to appear on screen
    }
}
