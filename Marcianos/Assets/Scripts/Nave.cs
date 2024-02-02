using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Nave : MonoBehaviour
{
    public static Nave Instance;

    [SerializeField] float velocidad = 6;
    [SerializeField] Transform prefabDisparo;
    private GameManager gameManager;
    private bool canShoot = true;
    public int score;
    public int vida;
    public TMP_Text textoSaludo;

    private void Awake()
    {
        gameManager = GameManager.Instance;

        score = gameManager.score;
        vida = gameManager.vida;
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        textoSaludo.text += score;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * velocidad * Time.deltaTime, 0, 0);

        if (transform.position.x > 7)
            transform.position = new Vector3(7, transform.position.y);
        if (transform.position.x < -7)
            transform.position = new Vector3(-7, transform.position.y);

        if (Input.GetButton("Fire1") && canShoot)
        {
            gameManager.balas.Add(Instantiate(prefabDisparo, transform.position, Quaternion.identity).gameObject);
            GetComponent<AudioSource>().Play();
            StartCoroutine(Disparar());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Alien Base" || collision.tag == "Bala Alien" || collision.tag == "Asteroid")
        {
            Destroy(collision.gameObject);
            PerderVidas();
        }
            
    }

    private void PerderVidas()
    {
        vida--;
        gameManager.corazones[vida].gameObject.SetActive(false);

        if(vida <= 0)
            SceneManager.LoadScene("Game Over");
    }

    IEnumerator Disparar()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
}
