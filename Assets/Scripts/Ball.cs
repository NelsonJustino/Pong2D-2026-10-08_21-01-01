using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 startingVelocity = new Vector2(5f, 5f);
    public GameManager gameManager;
    public float speedUp = 1.1f;

    public void ResetBall()
    {
        // trás o objeto para a posição zero nos 3 eixos.
        transform.position = Vector3.zero;

        //pega o Rigidbody do objeto.
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        // dá a velocidade do objeto.
        rb.velocity = startingVelocity;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto com o qual a bola colidiu tem a tag "Wall".
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Cria uma variável com a velocidade atual da bola.
            Vector2 newVelocity = rb.velocity;

            // Inverte a direção do movimento no eixo Y.
            newVelocity.y = -newVelocity.y;

            // Aplica a nova velocidade ao Rigidbody2D da bola.
            rb.velocity = newVelocity;
        }

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            rb.velocity *= speedUp;
        }

        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            rb.velocity *= speedUp;
        }

        if (collision.gameObject.CompareTag("PlayerPoint"))
        {
            gameManager.PlayerScore();
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("EnemyPoint"))
        {
            gameManager.EnemyScore();
            ResetBall();
        }

        if (collision.gameObject.CompareTag("Player1Wall"))
        {
            gameManager.Player2Score();
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("Player2Wall"))
        {
            gameManager.Player1Score();
            ResetBall();
        }
    }
}
