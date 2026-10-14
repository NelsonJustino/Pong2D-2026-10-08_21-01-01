using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 3f;
    public Vector2 limits = new Vector2(-4.5f, 4.5f); 

    private GameObject ball;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball"); //Encontra a bola
    }

    private void Update()
    {
        if(ball  != null)
        {
            float targetY = Mathf.Clamp(ball.transform.position.y, limits.x, limits.y); //limita a posição Y
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed); 
            //Move gradulmente para posição Y da bola
        }
    }
}
