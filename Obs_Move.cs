using UnityEngine;
using UnityEngine.UIElements;

public class Upping : MonoBehaviour
{
    public float y_vel = 5f;
    void Start()
    {

    }

    void Update()
    {
        Vector3 movement = Vector3.up*y_vel;

        movement = movement.normalized * y_vel *Time.deltaTime;
        

        transform.position += movement;

    }
}
