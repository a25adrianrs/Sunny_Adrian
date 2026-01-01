using UnityEngine;

public class ItemCollectAnim : MonoBehaviour
{

    void Start()
    {
        //  Una vez se crea el objeto lanzamos su destrucción la cual estara
        // retrasada un determinado tiempo
        Destroy(gameObject, 0.5f);
    }

}
