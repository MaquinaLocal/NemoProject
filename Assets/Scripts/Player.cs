using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4.0f;

    private float screenLimit_x;
    private float screenLimit_y;

    private float size;
    private int playerPoints = 0;

    [SerializeField] private Transform fishSprite;
    [SerializeField] private PlayerUI playerUI;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bubbleImage;

    
    void Start()
    {
        // Inicialización de RigidBody
        rb = GetComponent<Rigidbody2D>();

        // Obtener los límites de pantalla
        screenLimit_x = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        screenLimit_y = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;

        // Obtener tamaño de jugador
        size = transform.localScale.x;

        bubbleImage.SetActive(false);
    }

  
    void Update()
    {
        MovePlayerToLocation();

        Vector3 currentPosition = transform.position;

        // Establecer el limite min y max de desplazamiento
        currentPosition.x = Mathf.Clamp(currentPosition.x, -screenLimit_x, screenLimit_x);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -screenLimit_y, screenLimit_y);

        transform.position = currentPosition;

    }


    // Colisión con otros peces
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Colisión con peces
        if (collision.gameObject.CompareTag("Fish"))
        {
            // Comparación de tamaños
            FishAI fish_ai = collision.gameObject.GetComponent<FishAI>();
            if (size >= fish_ai.GetSize())
            {
                Destroy(collision.gameObject);
                // Establecer condición de victoria
                playerPoints++;
                playerUI.UpdateScore(playerPoints);


                if (playerPoints >= 10)
                {
                    GameManager.Instance.UpdateStates(States.GameWin);
                    speed = 0.0f;
                }
                // Aumenta escala de jugador
                transform.localScale = size * new Vector3(1, 1, 1) * 1.05f;
                size = transform.localScale.x;
            } else
            {
                Destroy(gameObject);
                // Establecer condición de derrota
                GameManager.Instance.UpdateStates(States.GameOver);
            }
        }

        // Colisión con burbuja
        if (collision.gameObject.CompareTag("Bubble"))
        {
            bubbleImage.SetActive(true);
        }
    }


    // Movimiento de Jugador por Mouse
    private void MovePlayerToLocation()
    {
        if (Input.GetMouseButton(0))
        {
            // Click a posición en pantalla
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f;

            // Diferencia entre jugador y lugar del click
            Vector2 moveDirection = (targetPosition - transform.position).normalized;

            // Rotación
            if (moveDirection.x < 0) 
                fishSprite.rotation = Quaternion.Euler(0, 180, 0);
            else 
                fishSprite.rotation = Quaternion.Euler(0, 0, 0);

            // Movimiento usando Rigidbody
            rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
           
        }        
    }
}
