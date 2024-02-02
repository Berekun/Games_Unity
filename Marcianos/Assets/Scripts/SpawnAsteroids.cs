using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    [SerializeField] Transform prefabAsteroids;
    void Start()
    {
        StartCoroutine(Disparar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Disparar()
    {
        float pause = Random.Range(1f, 3f);
        yield return new WaitForSeconds(pause);
        Instantiate(prefabAsteroids, transform.position, Quaternion.identity);
        StartCoroutine(Disparar());
    }
}
