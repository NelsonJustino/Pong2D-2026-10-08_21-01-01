using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        Movement();
    }


    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            // Calcula a nova posição da raquete baseada na entrada e na velocidade
            Vector3 newPosition = transform.position + Vector3.up * speed * Time.deltaTime;

            // Limita a posição vertical da raquete para que ela não saia da tela
            newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

            // Atualiza a posição da raquete
            transform.position = newPosition;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // Calcula a nova posição da raquete baseada na entrada e na velocidade
            Vector3 newPosition = transform.position + Vector3.down * speed * Time.deltaTime;

            // Limita a posição vertical da raquete para que ela não saia da tela
            newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

            // Atualiza a posição da raquete
            transform.position = newPosition;
        }       
    }
}
