using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Movement : MonoBehaviour
{
    public float vel = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int position = 0;
        if (Input.GetKey(KeyCode.A))
        {
            position = -1;
        }
        if (Input.GetKey(KeyCode.D)){ 
            position = 1; 
        }

        Vector3 movement = new Vector3(position, 0f, 0f);

        movement = movement.normalized * vel * Time.deltaTime;

        transform.position += movement;


    }
}
