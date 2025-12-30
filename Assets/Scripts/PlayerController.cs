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

    // Referencia de animator que usaremos para poder acceder a los parametros de animación definidos
    Animator anim;
    float moveX;
    bool jump;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
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

        Vector2 vel1 = new Vector2(moveX * speed * Time.fixedDeltaTime, rb.linearVelocity.y);
        rb.linearVelocity = vel1;
        // Cuando la velocidad del personaje sea mayor que "0" , accederemos al componente 
        // animator para cargar la animación de correr de nuestro personaje
        // Establecemos el valor booleano de isRunning a "true" ó "false" en función
        // de la condición
        anim.SetBool("isRunning", Mathf.Abs(rb.linearVelocity.x) > Mathf.Epsilon);
    }

    void Flip()
    {
        float speed_x = rb.linearVelocity.x;
        if (Math.Abs(speed_x) > Mathf.Epsilon)
            transform.localScale = new Vector2(Mathf.Sign(speed_x), 1);
    }

    void Jump()
    {
        // Si no se pulso la tecla de salto, automaticamente salimos del metodo
        if (!jump) return;

        jump = false;
        // Si estoy intentando saltar pero no estamos tocando ninguno de los objetos 
        // de las capas indicadas, entonces tambien salimos del metodo.
        if (!col.IsTouchingLayers(LayerMask.GetMask("Terrain", "Platforms")))
            return;


        rb.linearVelocity += new Vector2(0, jumpSpeed);

        anim.SetTrigger("isJumping");
    }










}

