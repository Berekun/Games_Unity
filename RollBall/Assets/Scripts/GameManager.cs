using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int vida = 3;
    public int score = 0;
    public List<Transform> corazones;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        


        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int indiceEscenaActual = SceneManager.GetActiveScene().buildIndex;

        string nombreEscena = SceneManager.GetSceneByBuildIndex(indiceEscenaActual).name;

        if(nombreEscena == "ParkourScene" || nombreEscena == "Laberinto")
        {
            corazones.Clear();

            GameObject vidas = GameObject.Find("vidas");


            foreach (Transform c in vidas.transform)
            {
                corazones.Add(c);
            }

            for (int i = 0; i < vida; i++)
            {
                corazones[i].gameObject.SetActive(true);
            }
        }
    }
}
