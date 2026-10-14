using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public Ball ball;

    public int playerScore = 0;
    public int enemyScore = 0;
    public int endGamePoints = 10;

    public TextMeshProUGUI textPlayerScore;
    public TextMeshProUGUI textEnemyScore;
    private void Awake()
    {
        ResetGame();
    }

    private void ResetGame()
    {
        player.transform.position = new Vector3(-8, 0, 0);
        enemy.transform.position = new Vector3(8, 0, 0);
        ball.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        textPlayerScore.text = playerScore.ToString();
        textEnemyScore.text = enemyScore.ToString();
    }
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

    public void EndGame()
    {
        if(playerScore >= endGamePoints)
        {
            textPlayerScore.text = "You win!";
            ResetGame();
        }
        else if(enemyScore >= endGamePoints)
        {
            textEnemyScore.text = "Enemy win!";
            ResetGame();
        }
    }
}
