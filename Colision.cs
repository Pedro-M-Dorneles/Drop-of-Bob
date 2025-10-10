using UnityEngine;

public class Colision : MonoBehaviour
{
    public bool touchPlayer=false;
    public Upping upping_script;

    
    void Start()
    {
        upping_script = GetComponent<Upping>();
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            // Se a normal do contato aponta para cima (player em cima do objeto)
            if (contact.normal.y < -0.5f)
            {
                touchPlayer = true;
                Debug.Log("Parou o timer");
            }
        }
    }
}
