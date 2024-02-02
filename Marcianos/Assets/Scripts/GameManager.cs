using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<GameObject> balas = new List<GameObject>();
    public int vida = 3;
    public int score = 0;
    public List<Transform> corazones;
    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(gameObject);

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
