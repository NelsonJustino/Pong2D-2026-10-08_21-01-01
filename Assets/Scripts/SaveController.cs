using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public Color colorPlayer1 = Color.white;
    public Color colorPlayer2 = Color.white;
    // Start is called before the first frame update
    private static SaveController _instance;
    // Propriedade estática para acessar a instância

    public string namePlayer1;
    public string namePlayer2;
    public string savedName = "Last winner";

    private void Awake()
    {
        // Garanta que apenas uma instância do Singleton exista
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        // Mantenha o Singleton vivo entre as cenas
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayer1 : namePlayer2;
    }

    public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
                // Procure a instância na cena
                _instance = FindObjectOfType<SaveController>();
                // Se não encontrar, crie uma nova instância
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }
    public void ResetSave()
    {
        namePlayer1 = "";
        namePlayer2 = "";
        colorPlayer1 = Color.white;
        colorPlayer2 = Color.white;
    }
    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(savedName, winner);
        PlayerPrefs.Save();
    }
    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(savedName, "");
    }
    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
