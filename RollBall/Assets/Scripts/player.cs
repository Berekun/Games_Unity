using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{             
    Rigidbody rb;
    Renderer r;
    GameManager gameManager;
    public Transform pickUpExplosion;
    public Transform WallExplosion;
    public TMP_Text scoreText;
    private bool canJump = false;
    private float fuerzaDeSalto = 7;
    public int speed = 0;
    void Start()
    {
        gameManager = GameManager.Instance;
        r = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (transform.position.y < 0)
        {
            ResetPosition();
        }

        if (Input.GetButtonDown("Jump") && canJump)
        {
            canJump = false;
            rb.AddForce(Vector3.up * fuerzaDeSalto, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            InteractWithPickUp(other);
        }

        if (other.gameObject.CompareTag("Win"))
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            Debug.Log("colision");
            canJump = true;
        }

        if (collision.collider.CompareTag("Nord") || collision.collider.CompareTag("Sur"))
        {
            ChangeSize(0.2f, 0.2f, 0.2f, collision);
        }

        if (collision.collider.CompareTag("Este") || collision.collider.CompareTag("Oeste"))
        {
            ChangeSize(-0.2f, -0.2f, -0.2f, collision);
        }

        if (collision.collider.CompareTag("Walls"))
        {
            InteractWithLaberinto();
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            ResetPosition();
            FixHearts();
        }
    }

    //Cambia el tamaño de la pelota y de las paredes, tambien cambia el color de la pelota
    public void ChangeSize(float x, float y, float z, Collision collision)
    {
        r.material.color = new Color(Random.value, Random.value, Random.value);
        Instantiate(WallExplosion, transform.position, Quaternion.identity);
        transform.localScale += new Vector3(x, y, z);
        FixScale();
        collision.gameObject.transform.position -= new Vector3(0, 1f, 0);
    }

    //Devuelve el jugador a su posicion en la escena del laberinto
    public void InteractWithLaberinto()
    {
        transform.position = new Vector3(-8.0f, 0.5f, -8.0f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        FixHearts();
    }

    //Funcion que controla todo lo relacionado con los pickUps (subir score, instanciar la explosion, pone el sonido, elimina el pickUp,
    //y si llega a 100 cambia la escena)
    public void InteractWithPickUp(Collider other)
    {
        gameManager.score += 10;
        Instantiate(pickUpExplosion, other.transform.position, Quaternion.identity);
        scoreText.text = gameManager.score.ToString();
        GetComponent<AudioSource>().Play();
        other.gameObject.SetActive(false);

        if (gameManager.score == 100)
            SceneManager.LoadScene("Laberinto");
    }

    //Devuelve el jugador a su posicion en la escena de los pickUps
    public void ResetPosition() {
        transform.position = new Vector3(3.0f, 0.5f, 0.0f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        FixHearts();
    }

    //Controla las vidas
    public void FixHearts()
    {
        gameManager.vida--;
        gameManager.corazones[gameManager.vida].gameObject.SetActive(false);

        if (gameManager.vida <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
    
    //Controla los limites del jugador
    public void FixScale()
    {
        float x = Mathf.Clamp(transform.localScale.x, 0.6f, 1.6f);
        float y = Mathf.Clamp(transform.localScale.y, 0.6f, 1.6f);
        float z = Mathf.Clamp(transform.localScale.z, 0.6f, 1.6f);

        transform.localScale = new Vector3(x, y, z);
    }


}
