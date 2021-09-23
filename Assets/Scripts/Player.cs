using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Transform transform;
    private Animator animator;

    public bool andando;
    public bool viradoDireita;

    private float eixo;
    public float velocidade;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        viradoDireita = true;    
    }

    void Update()
    {
        eixo = Input.GetAxisRaw("Horizontal");
        andando = Mathf.Abs(eixo) > 0f;

        AlteraEixo(eixo);

        AlteraMovimento(andando);        
    }

    void Virar()
    {
        viradoDireita = !viradoDireita;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    void AlteraEixo(float eixo)
    {
        if (eixo > 0f && !viradoDireita)
            Virar();
        else if(eixo < 0f && viradoDireita)
            Virar();
    }

    void AlteraMovimento(bool andando)
    {
        if (andando && viradoDireita)
            rigidBody.velocity = new Vector2(velocidade, rigidBody.velocity.y);
        else if(andando && !viradoDireita)
            rigidBody.velocity = new Vector2(-velocidade, rigidBody.velocity.y);
    }
}
