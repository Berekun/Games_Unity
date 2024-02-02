using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{

    public static SpawnEnemys Instance;

    [SerializeField] Transform enemy;
    private List<Transform> enemys = new List<Transform>();

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        enemys.Clear();

        for(int i = 7; enemys.Count < 4; i = i - 4)
        {
            enemys.Add(Instantiate(enemy, new Vector3(i,9), Quaternion.identity));
        }
    }
}
