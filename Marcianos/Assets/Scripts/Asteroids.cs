using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    float velocidadAsteroideX;
    float velocidadAsteroideY;

    // Start is called before the first frame update
    void Start()
    {
        velocidadAsteroideX = Random.Range(4.0f, 8.0f);
        velocidadAsteroideY = Random.Range(7.0f, 20.0f);
        if (transform.position.x > 0)
            velocidadAsteroideX = velocidadAsteroideX * -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidadAsteroideX * Time.deltaTime, -velocidadAsteroideY * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
