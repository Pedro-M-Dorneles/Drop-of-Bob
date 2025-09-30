using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dash = 20f;
    public float duration = 0.25f;
    public float cooldown = 0.75f;
    private bool dashing = false;
    private bool notdashing = true;
    private float direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && notdashing)
        {
            float moveInput = Input.GetAxisRaw("Horizontal");

            if (moveInput != 0)
            {
                direction = moveInput;
            }

            else
            { 
                direction = transform.localScale.x; 
            }

            StartCoroutine(Investida());
        }
    }

    private System.Collections.IEnumerator Investida()
    {
        dashing = true;
        notdashing = false;

        rb.linearVelocity = new Vector2(direction * dash, 0f);
        yield return new WaitForSeconds(duration);
        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);

        dashing = false;
        yield return new WaitForSeconds(cooldown);
        notdashing = true;
    }
}
