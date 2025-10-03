using UnityEngine;

public class Wall_spawner : MonoBehaviour
{
    public GameObject wallPrefab; // Prefab da parede
    public Transform leftWallParent;
    public Transform rightWallParent;
    public float speed = 5f;

    private float wallHeight;

    void Start()
    {
        wallHeight = wallPrefab.GetComponent<SpriteRenderer>().bounds.size.y;
        
        // Inicializa a primeira parede de cada lado
        SpawnWall(leftWallParent);
        SpawnWall(rightWallParent);
    }

    void Update()
    {
        MoveWalls(leftWallParent);
        MoveWalls(rightWallParent);
    }

    void MoveWalls(Transform parent)
    {
        foreach (Transform wall in parent)
        {
            wall.position += Vector3.up * speed * Time.deltaTime;
        }

        // Checa se precisa spawnar novo pedaço
        Transform lastWall = parent.GetChild(parent.childCount - 1);
        if (lastWall.position.y >= -1*wallHeight)
        {
            SpawnWall(parent, lastWall.position.y - wallHeight);
        }
    }

    void SpawnWall(Transform parent, float yPos = 10)
    {
        Vector3 spawnPos = new Vector3(parent.position.x, yPos, 0);
        Instantiate(wallPrefab, spawnPos, Quaternion.identity, parent);
    }
}
