using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class bala : MonoBehaviour
{
    [SerializeField] float velocidadDisparo = 0;
    [SerializeField] Transform prefabExplosion;
    [SerializeField] Transform prefabExplosionSound;
    private Nave nave;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        nave = Nave.Instance;
        gameManager = GameManager.Instance;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, velocidadDisparo, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        gameManager.balas.Remove(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Alien Base")
        {
            nave.score += 100;
            nave.textoSaludo.text = nave.score.ToString();
            Transform explosion = Instantiate(prefabExplosion, other.transform.position, Quaternion.identity);
            Instantiate(prefabExplosionSound, other.transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            Destroy(explosion.gameObject, 1f);
            Destroy(gameObject);
            gameManager.balas.Remove(gameObject);

            if (nave.score == 400 || nave.score == 1200)
            {
                for (int i = 0; i < gameManager.balas.Count; i++)
                {
                    Destroy(gameManager.balas[i]);
                        gameManager.balas.Remove(gameObject);
                }

                SpawnEnemys.Instance.SpawnEnemy();
            }
                

            if (nave.score == 800)
            {
                GameManager.Instance.vida = Nave.Instance.vida;
                GameManager.Instance.score = Nave.Instance.score;
                SceneManager.LoadScene("Nivel2");
            }

            if (Nave.Instance.score == 1600)
            {
                GameManager.Instance.vida = Nave.Instance.vida;
                GameManager.Instance.score = Nave.Instance.score;
                SceneManager.LoadScene("Nivel3");
            }

        }

        if (other.tag == "Asteroid")
        {
            Transform explosion = Instantiate(prefabExplosion, other.transform.position, Quaternion.identity);
            Instantiate(prefabExplosionSound, other.transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            Destroy(explosion.gameObject, 1f);
            Destroy(gameObject);
            gameManager.balas.Remove(gameObject);
        }
    }

}
