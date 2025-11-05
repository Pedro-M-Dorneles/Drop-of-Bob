using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Obs_spawn : MonoBehaviour
{
    public GameObject[] obstacles;
    public float minSpawnRate = 2f;
    public float maxSpawnRate = 4f;

    public float MinPos = -18f;
    public float MaxPos = 18f;
    private int randomObstacle;
    // Posições possíveis para o cano
    private float[] pipePositions = { 18f, -18f };

    private bool spawning = true;

    //Gap
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnRoutine()
    {
        while (spawning)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));

            randomObstacle = RandomObject();

            if (randomObstacle == 1)
            {
                Cano();
            }
            else
            {
                // Distância entre obstáculos depende da taxa de spawn (dinâmico)
                float spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
                float distanceFactor = Mathf.Lerp(7f, 10f, (maxSpawnRate - spawnRate) / maxSpawnRate);

                float posX = Random.Range(MinPos, MaxPos) + Random.Range(-distanceFactor, distanceFactor);
                Instantiate(obstacles[randomObstacle], new Vector2(posX, transform.position.y), transform.rotation);
            }
        }
    }




    private int RandomObject()
    {
        int randomNumber;

        randomNumber = Random.Range(0, obstacles.Length);
        return randomNumber;
    }

    //Função para soltar o cano
    private void Cano()
    {
        // Escolhe uma das duas posições possíveis
        float chosenPipePos = pipePositions[Random.Range(0, pipePositions.Length)];

        //Instanciando o cano
        GameObject pipe = Instantiate(obstacles[randomObstacle], new Vector2(chosenPipePos, transform.position.y), transform.rotation);
        Debug.Log("SOltei o cano");
        // Se for o cano de baixo, inverte a escala no eixo Y
        if (chosenPipePos < 0)
        {
            Vector3 scale = pipe.transform.localScale;
            scale.x *= -1;
            pipe.transform.localScale = scale;
        }
    }
}
