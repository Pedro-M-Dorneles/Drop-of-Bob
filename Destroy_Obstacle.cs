using Unity.Cinemachine;
using UnityEngine;

public class Destroy_Obstacle : MonoBehaviour
{

    public CinemachineCamera virtualCamera;
    private float threshold;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Usar o .Lens para aumentar a dificuldade dando zoom out
        threshold = (virtualCamera.Lens.OrthographicSize * 2)+30;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Obstacle");
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Wall");

        destroy_object(walls);
        destroy_object(obstacles);
        
    }

    void destroy_object(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            if (obj.transform.position.y > (threshold+obj.GetComponent<SpriteRenderer>().bounds.size.y))
            {
                Destroy(obj);
                //Debug.Log("Destruiessa poha "+obj.tag);
            }
        }
    }
}
