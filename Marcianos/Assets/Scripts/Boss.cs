using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int vida = 20;
    public float velocidadX = 10f;
    public float rotation = 0;
    private bool EnableRotation = false;
    public TMP_Text textVida;
    [SerializeField] Transform prefabDisparo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disparar());
        StartCoroutine(RandomAtack());
        textVida.text = vida.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidadX * Time.deltaTime, 0, 0);

        if ((transform.position.x < -7) || (transform.position.x > 7))
            velocidadX = -velocidadX;

        if (EnableRotation)
        {
            transform.Rotate(0, 0, rotation * Time.deltaTime);
        }
            
    }

    IEnumerator RandomAtack()
    {
        yield return new WaitForSeconds(5f);
        EnableRotation = true;
        yield return new WaitForSeconds(3f);
        EnableRotation = false;
        transform.rotation = Quaternion.identity;

        StartCoroutine(RandomAtack());
    }

    IEnumerator Disparar()
    {
        float pausa;

        if (!EnableRotation)
            pausa = Random.Range(0.5f, 1.0f);
        else
            pausa = Random.Range(0.3f, 0.7f);

        yield return new WaitForSeconds(pausa);
        Instantiate(prefabDisparo, transform.position, Quaternion.identity);
        StartCoroutine(Disparar());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bala")
        {
            vida--;
            textVida.text = vida.ToString();
            Destroy(other.gameObject);
        }
            

        if(vida == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("You Win");
        }

    }
}
