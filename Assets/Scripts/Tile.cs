using UnityEngine;

public class Tile : MonoBehaviour
{
    public Enemy enemy;

    Vector3 spawnPosition;

    void Start()
    {
        spawnPosition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
    }

    public void SpawnEnemy()
    {
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }

}
