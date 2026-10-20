using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionScript : MonoBehaviour
{
    public Button uiButton;
    public Image paddleReference;

    public bool isPlayer1 = false;

    public void OnButtonClick()
    {
        paddleReference.color = uiButton.colors.normalColor;

        if (isPlayer1)
        {
            SaveController.Instance.colorPlayer1 = paddleReference.color;
        }
        else
        {
            SaveController.Instance.colorPlayer2 = paddleReference.color;
        }
    }
}
