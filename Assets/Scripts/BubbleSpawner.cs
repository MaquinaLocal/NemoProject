using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{

    public float spawnTime = 5.0f;
    [SerializeField] private GameObject bubblePrefab;

    
    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            Instantiate(bubblePrefab, GetSpawnPosition(), Quaternion.identity);
            spawnTime = 5.0f;
        }

    }

    private Vector3 GetSpawnPosition()
    {
        float screenLimit_y = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float screenLimit_x = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        float rndVertical = Random.Range(-screenLimit_y, screenLimit_y);
        float rndHorizonal = Random.Range(-screenLimit_x, screenLimit_x);

        return new Vector3(rndHorizonal, rndVertical, 0);
    }
}
