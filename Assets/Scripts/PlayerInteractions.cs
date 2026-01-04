using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] AudioClip dieFX;
    [SerializeField] CinemachineCamera followCamera;

    Animator anim;
    Vector3 initialPosition;
    Rigidbody2D rb;
    Collider2D col;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        initialPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el "Player" colisiona con la "Trampa" se cumple la condición y se lanza la co-rutina
        if (collision.gameObject.tag == "Trap")
        {
            // Llamamos a la co-rutina que controla las animaciones "die" y "reborn"
            StartCoroutine(DieAndReborn());
        }
    }

    // Co-rutina para controlar las animaciones de "die" y "reborn"
    IEnumerator DieAndReborn()
    {
        // Eliminar la velocidad del jugador
        rb.linearVelocity = Vector2.zero;

        // En el momento de la muerte del jugador , reproduciremos el sonido de muerte
        AudioSource.PlayClipAtPoint(dieFX, transform.position);

        // Activar la animación de muerte del jugador
        anim.SetTrigger("die");

        //Al moment de morir el jugador, desactivamos la camara
        followCamera.enabled = false;

        rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        col.enabled = false;
        // 2 segundos es mas rapidos y tiempo suficiente para mostrar la animación de muerte;
        yield return new WaitForSeconds(2f);

        // Reiniciamos la posición del jugador
        transform.position = initialPosition;
        anim.SetTrigger("reborn");
        col.enabled = true;
        followCamera.enabled = true;
    }
}
