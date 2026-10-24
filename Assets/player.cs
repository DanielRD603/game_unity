using UnityEngine;

public class player_controler : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;
    public float FuerzaSalto = 10f;
    public float LongitudRaycast = 0.1f;
    public LayerMask CapaSuelo;

    private bool enSuelo;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movimientox = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        animator.SetFloat("movement", movimientox * speed);

        if (movimientox > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (movimientox < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        Vector3 posicion = transform.position;

        transform.position = new Vector3(movimientox + posicion.x, posicion.y, posicion.z);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, LongitudRaycast, CapaSuelo);

        enSuelo = hit.collider != null;

        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(new Vector2(0f, FuerzaSalto), ForceMode2D.Impulse);
        }
        animator.SetBool("Ensuelo", enSuelo);

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * LongitudRaycast);
    }
}
