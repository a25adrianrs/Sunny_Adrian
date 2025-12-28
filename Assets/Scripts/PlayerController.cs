using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    Rigidbody2D rb;
    float moveX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Cuando actuamos sobre el motor de fisica es adecuado
        // usar este metodo que se actualiza con una velocidad de refreso constante

        Run();
    }


    void Update()
    {
        // Hacemos una llamada al metodo GetAxis para determinar
        // si se pulsan las teclas de desplazamiento lateral y en caso
        // de que se estén pulsando las teclas de desplazamiento
        // lateral se guarden dentro de la variable moveX.

        // (1) = tecla derecha, (-1) = tecla izquierda, (0)= ninguna tecla
        moveX = Input.GetAxisRaw("Horizontal");

    }

    void Run()
    {
        Vector2 vel1 = new Vector2(moveX * speed * Time.deltaTime, rb.linearVelocity.y);
        rb.linearVelocity = vel1;
    }
}
