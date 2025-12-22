using UnityEngine;
using UnityEngine.Timeline;

public class Paralax : MonoBehaviour
{
    // Campo serializado donde definiremos el efecto paralax, velocidad de scroll de la superficie concreta
    [SerializeField] float parallax;
    Material mat;

    // Componente transform de la camara
    Transform cam;
    Vector3 initialPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
        cam = Camera.main.transform;
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Sera la posición x e y de la imagen en cuestión
        transform.position = new Vector3(cam.position.x, initialPos.y, initialPos.x);

        mat.mainTextureOffset = new Vector2(cam.position.x * parallax, 0);
    }
}
