using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject spawnObject;
    public float timeTilNextSpawn = 1f;

    [Header("Spawn Area")]
    public int minX = -10;
    public int maxX = 10;
    public int minY = 12;
    public int maxY = 15;

    [Header("Enemy Sprites")]
    public Sprite[] enemySprites;

    private float timer;
    private Transform player;

    void Start()
    {
        timer = 0f;

        GameObject playerObj = GameObject.Find("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        timer += Time.deltaTime;

        if (timer >= timeTilNextSpawn)
        {
            Spawn();
            timer = 0f;
        }
    }

    void Spawn()
    {
        Vector3 spawnPoint = new Vector3(
            Random.Range(minX, maxX),
            Random.Range(minY, maxY),
            0f
        );

        GameObject enemy = Instantiate(spawnObject, spawnPoint, Quaternion.identity);

        // RANDOM SPRITE
        if (enemySprites.Length > 0)
        {
            SpriteRenderer sr = enemy.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.sprite = enemySprites[Random.Range(0, enemySprites.Length)];
            }
        }
    }
}
