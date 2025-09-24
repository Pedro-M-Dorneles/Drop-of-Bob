using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Upping : MonoBehaviour
{
    public float y_vel = 5f;
    public Colision colision;

    private float tempoAtual;
    public float stopTime = 1f;
    private static float tempoRestante = 0f;

    public static bool gameOver = false;
    void Start()
    {
        colision = GetComponent<Colision>();
        tempoAtual = stopTime;
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
            foreach(GameObject obstaculo in obstaculos)
            {
                Upping script = obstaculo.GetComponent<Upping>();
                if (script != null)
                {
                    script.y_vel = 0f; // Zera velocidade
                }
            }
            
            gameOver = true;
            Debug.Log("Colidiu! Obstáculos pararam.");
        }
        if (gameOver)
        {
            // Só o primeiro obstáculo que detecta a colisão inicia o timer
            if (tempoRestante <= 0f)
            {
                tempoRestante = stopTime;
            }

            tempoRestante -= Time.deltaTime;

            if (tempoRestante <= 0f)
            {
                // Reseta as variáveis para próxima rodada
                gameOver = false;
                tempoRestante = 0f;

                // Reinicia a cena
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            return; // não move mais
        }
    }
}
