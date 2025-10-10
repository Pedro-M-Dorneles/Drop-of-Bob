using UnityEngine;

public class Obs_spawn : MonoBehaviour
{
    public GameObject obstacle;
    public float SpawnRate = 5;
    public float timer = 0;
    public float MinPos = -20;
    public float MaxPos = 20;
    void Start()
    {
        Instantiate(obstacle, new Vector2(Random.Range(MinPos, MaxPos), transform.position.y), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < SpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Instantiate(obstacle, new Vector2(Random.Range(MinPos, MaxPos), transform.position.y), transform.rotation);
            timer = 0;
        }
    }
}
