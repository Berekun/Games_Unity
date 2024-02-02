using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(PlaySound());
    }

    void Update()
    {
        
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
