using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float lifeTime = 3.0f;
    
    // Update is called once per frame
    void Update()
    {
        // Duración de la burbuja
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);
    }
}
