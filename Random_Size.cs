using UnityEngine;

public class Random_Size : MonoBehaviour
{
    public float min = 1f;
    public float max = 4f;

    void Start()
    {
        //Gerando um numero aleatorio
        transform.localScale = new Vector3(Random.Range(min, max), Random.Range(min, max), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
