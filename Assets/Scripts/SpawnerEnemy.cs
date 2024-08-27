using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    public GameObject spawnObject;
    public Vector3 spawnPoint;
    public int maxX = 10;
    public int maxY = 10;
    public float timeTilNextSpawn = 1f;
    int x = 0;
    int y = 0;
    float timer = 0;

    void Start()
    {
        timer = 0;
        spawnPoint.x = x;
        spawnPoint.y = y;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (GameObject.Find("Player")) {
            GameObject go = GameObject.Find("Player");
            PlayerHealth cs = go.GetComponent<PlayerHealth>();
            Spawn();
        }
       
    }

    void Spawn()
    {


        if (timer >= timeTilNextSpawn)
        {
            x = Random.Range(-10, maxX);
            y = Random.Range(12, maxY);
            spawnPoint.x = x;
            spawnPoint.y = y;
            Instantiate(spawnObject, spawnPoint, Quaternion.identity);
            timer = 0;
        }
    }
}
