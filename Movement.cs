using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Movement : MonoBehaviour
{
    private float vel;
    private float direction = 1.3f;
    private bool can_move;

    //Pegando o script de reiniciar o jogo
    public Restart restart;
    //Pegando o script do dash
    public Dash dash;

    [SerializeField] private Animator animator;
    void Start()
    {
        //Dizendo que o personagem pode se mover, velocidade 5 e que a sprite dele é de vivo 
        can_move = true;
        animator.SetBool("isDeath", false);
        vel = 5f;

        //Pegando o script de reiniciar o jogo
        restart = GetComponent<Restart>();
        //Pegando o script do dash e permitindo ele
        dash = GetComponent<Dash>();
        dash.canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        int position = 0;
        if (can_move)
        {
            if (Input.GetKey(KeyCode.A))
            {
                direction = -1.3f;
                position = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction = 1.3f;
                position = 1;
            }
        }

        Vector3 movement = new Vector3(position, 0f, 0f);

        movement = movement.normalized * vel * Time.deltaTime;

       
        transform.localScale = new Vector3(direction, 1.3f, 1);
        transform.position += movement;
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //Percorrendo o collision.contacts que representa todos as direções em que o objeto pode sofrer uma colisão
            foreach (ContactPoint2D contact in collision.contacts)
            {
                // Se a normal do contato aponta para cima (player em cima do objeto)
                if (contact.normal.y > 0.5f)
                {
                    //O player não se move
                    can_move = false;
                    //Rodando a animação
                    animator.SetBool("isDeath", true);
                    //Reiniciando o jogo
                    restart.gameOver = true;
                    //Fazer o player nao poder Dash
                    dash.canDash = false;
                }
            }
        }
    }
}
