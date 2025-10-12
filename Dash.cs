using UnityEngine;

public class Dash : MonoBehaviour
{   
    public float dashForce = 20f;
    public float dashDuration = 0.25f;
    public float dashCooldown = 0.75f;

    
    public bool canDash;
    private bool isDashing = false;

    private Rigidbody2D rb;
    private Movement movement;

    // Squish
    private Vector3 originalScale;
    private Vector3 squishScale;
    public float squishX = 1f;
    public float squishY = 0.7f;
    public float stretchSpeed = 10f;   // rapidez para esticar
    public float returnSpeed = 5f;     // rapidez para voltar

    private bool returningToNormal = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<Movement>();
        originalScale = transform.localScale;
        squishScale = new Vector3(originalScale.x * squishX, originalScale.y * squishY, originalScale.z);
    }

    void Update()
    {
        HandleDashInput();
        AnimateSquish();
    }

    private void HandleDashInput()
    {
        if (!canDash || isDashing) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float direction = GetDashDirection();
            StartCoroutine(PerformDash(direction));
        }
    }

    private float GetDashDirection()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if (moveInput != 0)
            return moveInput; // segue o input
        else
            return Mathf.Sign(transform.localScale.x); // segue direção atual do personagem
    }

    private System.Collections.IEnumerator PerformDash(float direction)
    {
        canDash = false;
        isDashing = true;
        returningToNormal = false;

        // Armazena o sinal da direção (1 = direita, -1 = esquerda)
        float directionSign = Mathf.Sign(transform.localScale.x);

        // Inicia o efeito de squish (mantendo a direção atual)
        StartCoroutine(SquishEffect(directionSign));

        Vector2 originalVelocity = rb.linearVelocity;
        rb.linearVelocity = new Vector2(direction * dashForce, 0f);

        yield return new WaitForSeconds(dashDuration);

        rb.linearVelocity = new Vector2(0f, originalVelocity.y);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    private System.Collections.IEnumerator SquishEffect(float directionSign)
    {
        // Define o squish baseado no sinal (mantém a orientação horizontal correta)
        Vector3 targetScale = new Vector3(directionSign * squishX * Mathf.Abs(originalScale.x),
                                          squishY,
                                          originalScale.z);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * stretchSpeed;
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, t);
            yield return null;
        }

        returningToNormal = true;
    }

    private void AnimateSquish()
    {
        if (returningToNormal)
        {
            // Volta suavemente para o tamanho original
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, Time.deltaTime * returnSpeed);

            // Quando estiver quase no tamanho original, trava para evitar jitter
            if (Vector3.Distance(transform.localScale, originalScale) < 0.01f)
            {
                transform.localScale = originalScale;
                returningToNormal = false;
            }
        }
    }
}
