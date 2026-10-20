using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;

    public bool isPlayer1 = true;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer1)
            spriteRenderer.color = SaveController.Instance.colorPlayer1;
        else
            spriteRenderer.color = SaveController.Instance.colorPlayer2;
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    private void Movement()
    {
        // Captura da entrada vertical (seta para cima, seta para baixo, teclas W e S)
        float moveInput = Input.GetAxis("Vertical");

        // Calcula a nova posição da raquete baseada na entrada e na velocidade
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;

        // Limita a posição vertical da raquete para que ela não saia da tela
        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

        // Atualiza a posição da raquete
        transform.position = newPosition;
    }
}
