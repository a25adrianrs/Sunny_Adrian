using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;
    Rigidbody2D rb;
    // Para implementar el salto y detectar si el personaje esta tocando una de las capas (IsTouchingLayers),
    // necesitamos obtener una referencia al collider
    Collider2D col;
    float moveX;
    bool jump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        // Cuando actuamos sobre el motor de fisica es adecuado
        // usar este metodo que se actualiza con una velocidad de refreso constante

        Run();
        Flip();
        Jump();
    }


    void Update()
    {
        // Hacemos una llamada al metodo GetAxis para determinar
        // si se pulsan las teclas de desplazamiento lateral y en caso
        // de que se estén pulsando las teclas de desplazamiento
        // lateral se guarden dentro de la variable moveX.

        // (1) = tecla derecha, (-1) = tecla izquierda, (0)= ninguna tecla
        moveX = Input.GetAxisRaw("Horizontal");
        // Accedemos a uno de los ejes y accedemos a la tecla que Unity ya tiene asignada para tal acción
        // si la variable booleana para controlar el salto es "false" y estamos pulsando la tecla
        // asignada a la acción de salto entonces cambiamos el valor del booleano a "true"
        if (!jump && Input.GetButtonDown("Jump"))
            jump = true;

    }

    void Run()
    {
        Vector2 vel1 = new Vector2(moveX * speed * Time.deltaTime, rb.linearVelocity.y);
        rb.linearVelocity = vel1;
    }

    void Flip()
    {
        float speed_x = rb.linearVelocity.x;
        if (Math.Abs(speed_x) > Mathf.Epsilon)
            transform.localScale = new Vector2(Mathf.Sign(speed_x), 1);
    }

    void Jump()
    {
        if (jump)
        {
            jump = false;
            rb.linearVelocity += new Vector2(0, jumpSpeed);
        }
    }
}
