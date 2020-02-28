using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public int xTiles = 5;
    public int zTiles = 5;

    Tile[,] tiles;
    int[,] spawnMap;

    float tileOffset = -0.25f;

    float timeBetweenWaves = 5f;
    int enemiesPerWave = 3;

    public Tile tile;

    void Start()
    {
        tileOffset = -tile.transform.lossyScale.y / 2;
        tiles = new Tile[xTiles, zTiles];

        MapGenerate();
        InvokeRepeating("SpawnEnemies", timeBetweenWaves, timeBetweenWaves);
    }

    void MapGenerate()
    {
        for (int z = 0; z < zTiles; z++)
        {
            GameObject row = new GameObject($"{z}");
            row.transform.parent = gameObject.transform;

            for (int x = 0; x < xTiles; x++)
            {
                Tile tile = Instantiate(this.tile, new Vector3(x, tileOffset, z), Quaternion.identity);
                tile.transform.name = $"{x}";
                tile.transform.parent = row.transform;

                tiles[x, z] = tile;
            }
        }
    }
    void SpawnEnemies()
    {
        spawnMap = new int[xTiles, zTiles];
        for (int i = 0; i < enemiesPerWave; i++)
        {
            ChooseEnemySpawnPosition();
        }

        enemiesPerWave++;
    }
    void ChooseEnemySpawnPosition()
    {
        int xCord = Random.Range(0, xTiles - 1);
        int zCord = Random.Range(0, xTiles - 1);

        if (spawnMap[xCord, zCord] != 1){
            spawnMap[xCord, zCord] = 1;
            tiles[xCord, zCord].SpawnEnemy();
        }else{
            ChooseEnemySpawnPosition();
        }
    }

}
