using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Enemigo : MonoBehaviour
{
    [SerializeField] float velocidadDisparo = 0;

    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -velocidadDisparo * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
