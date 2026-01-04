using System.Collections;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
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
        anim.SetTrigger("die");
        yield return new WaitForSeconds(1);
    }
}
