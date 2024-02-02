using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camea : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    // Se ejecuta después de hacer los Update y FixedUpdate. Ya tendríamos
    // los movimientos calculados del resto de elementos
    void LateUpdate()
    {
        
        transform.position = player.transform.position + offset;
    }
}
