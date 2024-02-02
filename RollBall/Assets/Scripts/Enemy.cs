using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] Transform[] wayPoints;
    bool returnBack = false;
    float velocidad = 5;
    float distanciaCambio = 0.2f;
    int numeroSiguientePosicion = 0;
    Vector3 siguientePosicion;
    // Start is called before the first frame update
    void Start()
    {
        siguientePosicion = wayPoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        // Nos movemos hacia la siguiente posición
        transform.position = Vector3.MoveTowards(transform.position,siguientePosicion,velocidad * Time.deltaTime);

        // Si la distancia al punto es corta cambiamos al siguiente
        if (Vector3.Distance(transform.position,siguientePosicion) < distanciaCambio)
        {
            IncreaseOrDecrease();
            ChangeReturnBack();
            ChangeRotation();
            NextPosition();
        }

    }

    //Cambia la rotacion del enemigo
    public void ChangeRotation()
    {
        if (numeroSiguientePosicion == 4 && !returnBack)
            transform.Rotate(0, 270, 0);

        if (numeroSiguientePosicion == 6)
            transform.Rotate(0, 180, 0);

        if (numeroSiguientePosicion == 2 && returnBack)
            transform.Rotate(0, 90, 0);

        if (numeroSiguientePosicion == 1 && !returnBack)
            transform.Rotate(0, 180, 0);
    }

    //Es la funcion que cambia la siguiente posicion
    public void NextPosition()
    {
        if (numeroSiguientePosicion == 6)
            siguientePosicion = wayPoints[numeroSiguientePosicion - 1].position;
        else
            siguientePosicion = wayPoints[numeroSiguientePosicion].position;
    }

    //Es la funcion que hace que vaya hacia delante o hacia detras
    public void ChangeReturnBack()
    {
        if (numeroSiguientePosicion >= wayPoints.Length)
            returnBack = true;


        if (numeroSiguientePosicion <= 0)
            returnBack = false;
    }

    //Es la funcion que incrementa o decrementa la siguiente posicion
    public void IncreaseOrDecrease() {
        if (!returnBack)
            numeroSiguientePosicion++;
        else
            numeroSiguientePosicion--;
    }
}
