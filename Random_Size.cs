using UnityEngine;

public class Random_Size : MonoBehaviour
{
    public float min = 5f;
    public float max = 10f;
    private float randomNumber = 0f;

    void Start()
    {
        //Gerando um numero aleatorio
        randomNumber = Random.Range(min, max);
        transform.localScale = new Vector3(randomNumber, randomNumber, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
