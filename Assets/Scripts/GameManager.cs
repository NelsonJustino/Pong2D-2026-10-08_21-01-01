using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Game Objects
    public GameObject player;
    public GameObject enemy;
    public GameObject panel;
    public Ball ball;
    #endregion

    #region Variables
    public int playerScore = 0;
    public int enemyScore = 0;
    public int player1Score = 0;
    public int player2Score = 0;
    public int endGamePoints = 10;
    #endregion

    #region TMP UI
    public TextMeshProUGUI textPlayerScore;
    public TextMeshProUGUI textEnemyScore;
    public TextMeshProUGUI textPlayer1Score;
    public TextMeshProUGUI textPlayer2Score;
    public TextMeshProUGUI result;
    #endregion

    InputName inputName;

    private void Awake()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;

        panel.SetActive(false);

        player.transform.position = new Vector3(-8, 0, 0);
        enemy.transform.position = new Vector3(8, 0, 0);
        ball.ResetBall();

        playerScore = 0;
        enemyScore = 0;
        player1Score = 0;
        player2Score = 0;

        textPlayerScore.text = playerScore.ToString();
        textEnemyScore.text = enemyScore.ToString();
        textPlayer1Score.text = player1Score.ToString();
        textPlayer2Score.text = player2Score.ToString();
    }

    #region Score
    public void PlayerScore()
    {
        playerScore++;
        textPlayerScore.text = playerScore.ToString();
        EndGame();
    }
    public void EnemyScore()
    {
        enemyScore++;
        textEnemyScore.text = enemyScore.ToString();
        EndGame();
    }
    public void Player1Score()
    {
        player1Score++;
        textPlayer1Score.text = player1Score.ToString();
        EndGame();
    }
    public void Player2Score()
    {
        player2Score++;
        textPlayer2Score.text = player2Score.ToString();
        EndGame();
    }
    #endregion

    public void EndGame()
    {
        string winner = "";

        if (playerScore >= endGamePoints)
        {
            winner = "Player";
            panel.SetActive(true);
            result.text = "You win!";
        }
        else if (enemyScore >= endGamePoints)
        {
            winner = "Enemy";
            panel.SetActive(true);
            result.text = "You lost!";
        }
        else if (player1Score >= endGamePoints)
        {
            winner = SaveController.Instance.GetName(true);

            if (string.IsNullOrWhiteSpace(winner))
                winner = "Player 1";

            panel.SetActive(true);
            result.text = winner + " wins!";
        }
        else if (player2Score >= endGamePoints)
        {
            winner = SaveController.Instance.GetName(false);

            if (string.IsNullOrWhiteSpace(winner))
                winner = "Player 2";

            panel.SetActive(true);
            result.text = winner + " wins!";
        }
        else
        {
            return;
        }

        // Salva o vencedor para a próxima abertura do menu
        SaveController.Instance.SaveWinner(winner);

        Time.timeScale = 0f;
    }
}
