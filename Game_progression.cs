using System.Collections;
using System.Linq;
using Unity.Cinemachine;
using UnityEngine;

public class Game_progression : MonoBehaviour
{
    public ContadorFinal finalCountdown;
    public Upping obstacles_script;
    public Wall_spawner wall_script;


    [Header("Configurações de Progressão")]
    public float speed = 7f;
    public float newSpeed = 0;// Velocidade inicial
    public float timeConstant = 0f;
    private float acceleration = 0f;
    public float updateInterval = 0.5f;
    public float multiplier = 0.020f;


    public CinemachineCamera virtualCamera;



    void Start()
    {

        timeConstant = 0f;
        //Pegando o gameobject do contador e dos obstaculos
        GameObject countdown = GameObject.Find("UI");
        GameObject wall = GameObject.Find("Wall_Spawner");
        finalCountdown = countdown.GetComponent<ContadorFinal>();
        wall_script = wall.GetComponent<Wall_spawner>();


        StartCoroutine(aceleration());

    }

    // Update is called once per frame
    void Update()
    {
        timeConstant += Time.deltaTime;
    }

    //Corrotina para aumentar a velocidade
    IEnumerator aceleration()
    {
        while (true)
        {
            yield return new WaitForSeconds(updateInterval);

            float elapsedTime = timeConstant;

            // Fórmula logarítmica para a aceleração
            acceleration = Mathf.Log(1f + timeConstant) * multiplier;

            // Atualiza o multiplicador no contador
            finalCountdown.profundidade = speed * elapsedTime + (acceleration * Mathf.Pow(elapsedTime, 2f) / 2f);


            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");


            // calcula novo valor de velocidade uma vez
            newSpeed = speed + acceleration * elapsedTime;

            // aplica nos obstáculos
            foreach (GameObject obj in obstacles)
            {
                if (obj == null) continue;
                Upping up = obj.GetComponent<Upping>();
                if (up != null)
                {
                    up.y_vel = newSpeed;
                }
            }
            //Aplicando nas paredes
            wall_script.speed = newSpeed;

            StartCoroutine(FovTransitionRoutine(newSpeed));

        }
    }

    IEnumerator FovTransitionRoutine(float newSpeed)
    {
        float timeElapsed = 0;
        while (timeElapsed < 1)
        {

            if (newSpeed > 20)
            {
                virtualCamera.Lens.FieldOfView = Mathf.Lerp(virtualCamera.Lens.FieldOfView, 125f, timeElapsed / 1f);
            }
            timeElapsed += Time.deltaTime;

            yield return null;
        }
    }
}
