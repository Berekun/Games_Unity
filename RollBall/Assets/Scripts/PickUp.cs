using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Vector3 giro;
    private int velocidadGiro;
    public Renderer r;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        giro = new Vector3(Random.Range(30, 90), Random.Range(30, 90), Random.Range(30, 90));
        StartCoroutine(ChangeColor());
        velocidadGiro = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((giro * velocidadGiro) * Time.deltaTime);
    }

    //Funcion que cambia el color de los pickUps de manera aleatoria
    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(4f);
        r.material.color = new Color(Random.value, Random.value, Random.value);
        StartCoroutine(ChangeColor());
    }
}
