using UnityEngine;

public class KillEnemy : MonoBehaviour
{


    [SerializeField] AudioClip dieFx;
    [SerializeField] GameObject dieAnim;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(dieAnim, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
