using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien_Verde : MonoBehaviour
{

    [SerializeField] Transform prefabDisparo;

    private float velocidadX = 5f;
    private float velocidadY = -5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disparar());
        float direccion = Random.Range(0.0f, 10.0f);
        if (direccion <= 5.0f)
            velocidadX = velocidadX * -1;
        else
            velocidadY = velocidadY * -1;
        StartCoroutine(RandomMovement());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidadX * Time.deltaTime, velocidadY * Time.deltaTime, 0);

        if ((transform.position.x < -7) || (transform.position.x > 7))
            velocidadX = -velocidadX;
        if ((transform.position.y < -12) || (transform.position.y > 12))
            velocidadY = -velocidadY;
    }

    IEnumerator Disparar()
    {
        float pausa = Random.Range(1.0f, 3.0f);
        yield return new WaitForSeconds(pausa);
        Instantiate(prefabDisparo, transform.position, Quaternion.identity);
        StartCoroutine(Disparar());
    }

    IEnumerator RandomMovement()
    {
        float direccion = Random.Range(0.0f, 10.0f);
        yield return new WaitForSeconds(0.5f);
        if (direccion <= 5.0f)
            velocidadX = velocidadX * -1;
        else
            velocidadY = velocidadY * -1;
        StartCoroutine(RandomMovement());
    }
}
