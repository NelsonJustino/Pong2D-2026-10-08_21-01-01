
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public TextMeshProUGUI uiWinner;
    public GameObject resetNameButton;

    void Start()
    {
        string lastWinner = SaveController.Instance.GetLastWinner();

        if (!string.IsNullOrEmpty(lastWinner))
        {
            uiWinner.text = "Last winner: " + lastWinner;
            resetNameButton.SetActive(true);
        }
        else
        {
            uiWinner.text = "";
            resetNameButton.SetActive(false);
        }
    }

    public void ClearData()
    {
        PlayerPrefs.DeleteKey("Last winner");
        PlayerPrefs.Save();

        uiWinner.text = "";
        resetNameButton.SetActive(false);
    }
}
