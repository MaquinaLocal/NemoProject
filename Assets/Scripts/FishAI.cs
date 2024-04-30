using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour
{

    [SerializeField] private Transform fishSprite;
    [SerializeField] private GameObject player;

    public float speed = 1.5f;
    private float screenLimit_x;
    //private int dir = 1;
    private float size;

    // Start is called before the first frame update
    void Start()
    {
        screenLimit_x = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        /*
        if (transform.position.x <= screenLimit_x / 2)
            dir = 1;
        else
        {
            dir = -1;
            fishSprite.rotation = Quaternion.Euler(0, 180, 0);
        }
        */
        // Cambiar tamaño de forma aleatoria
        float randomSize = Random.Range(0.7f, 1.5f);
        size = randomSize;
        transform.localScale = new Vector3(randomSize, randomSize, randomSize);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 currentPosition = transform.position - player.position * dir * Time.deltaTime * speed;

        Vector2 direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

       

        /*
        if(currentPosition.x > screenLimit_x + 2 || currentPosition.x <= -screenLimit_x - 2)
        {
            Destroy(gameObject);
        }
        */

        //transform.position = currentPosition;
    }

    // Getter de variable tamaño
    public float GetSize()
    {
        return size;
    }
}
