using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public float spawnTime = 1.5f;
    [SerializeField] private GameObject fishPrefab;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0 )
        {
            Instantiate(fishPrefab, GetSpawnPosition(), Quaternion.identity);
            spawnTime = 1.5f;
        }
    }

    // Obtener posición vertical aleatoria
    private Vector3 GetSpawnPosition()
    {
        float screenLimit_y = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float screenLimit_x = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        float rndVertical = Random.Range(-screenLimit_y, screenLimit_y);
        float rndHorizonal = Random.Range(0, 2) == 0 ? -screenLimit_x - 1 : screenLimit_x + 1;

        return new Vector3(rndHorizonal, rndVertical, 0);
    }
}
