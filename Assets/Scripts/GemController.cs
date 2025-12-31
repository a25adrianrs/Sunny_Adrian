using UnityEngine;

public class GemController : MonoBehaviour
{
    [SerializeField] AudioClip gemCollect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("El player atraviesa la gema");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("El player atraviesa la gema");
            // Lanzamos el sonido de recogida de las gemas
            AudioSource.PlayClipAtPoint(gemCollect, transform.position);

            // Lanzamos la animación de recogida de las gemas

            // Destruimos la gema
            Destroy(gameObject);
        }
    }
}
