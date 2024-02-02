using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Boss : MonoBehaviour
{
    [SerializeField] float velocidadDisparo = 0;

    void Start()
    {
        Vector2 dir2player = (GameObject.Find("player").transform.position - transform.position).normalized;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir2player * velocidadDisparo;
    }

    void Update()
    {

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
