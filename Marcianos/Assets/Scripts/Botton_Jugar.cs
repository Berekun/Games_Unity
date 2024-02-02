using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Botton_Jugar : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LanzarJuego()
    {
        SceneManager.LoadScene("Nivel1");
        gameManager.vida = 3;
        gameManager.score = 0;
    }

    public void CerrarJuego()
    {
        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();
    }

}
