using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 4.0f;

    private float screenLimit_x;
    private float screenLimit_y;

    [SerializeField] private Transform fishSprite;

    // Start is called before the first frame update
    void Start()
    {
        // Obtener los límites de pantalla
        screenLimit_x = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        screenLimit_y = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        // Desplazamiento
        float inputRight = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float inputUp = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        Vector3 currentPosition = transform.position + new Vector3(inputRight, inputUp, 0);

        // Establecer el limite min y max de desplazamiento
        currentPosition.x = Mathf.Clamp(currentPosition.x, -screenLimit_x, screenLimit_x);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -screenLimit_y, screenLimit_y);

        transform.position = currentPosition;

        // Rotación
        if (inputRight == 0) return;
        if (inputRight < 0)
            fishSprite.rotation = Quaternion.Euler(0, 180, 0);
        else
            fishSprite.rotation = Quaternion.Euler(0, 0, 0);
        
        //Debug.Log(transform.position.x + " - " + Screen.width);
    }
}
