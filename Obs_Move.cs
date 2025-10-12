using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections;

public class Upping : MonoBehaviour
{
    public float y_vel = 5f;
    public Colision colision;


    void Start()
    {
        colision = GetComponent<Colision>();
    }

    void Update()
    {

        Vector3 movement = Vector3.up*y_vel;

        movement = movement.normalized * y_vel *Time.deltaTime;

        GameObject[] obstaculos = GameObject.FindGameObjectsWithTag("Obstacle");

        transform.position += movement;


        // Se houve colisão com o player → ativa gameOver
        if (colision == null || colision.touchPlayer)
        {
            foreach (GameObject obstaculo in obstaculos)
            {
                Upping script = obstaculo.GetComponent<Upping>();
                if (script != null)
                {
                    script.y_vel = 0f; // Zera velocidade
                }
            }
        }
    }
}
