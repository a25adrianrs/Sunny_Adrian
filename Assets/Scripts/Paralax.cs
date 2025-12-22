using UnityEngine;
using UnityEngine.Timeline;

public class Paralax : MonoBehaviour
{
    // Campo serializado donde definiremos el efecto paralax, velocidad de scroll de la superficie concreta
    [SerializeField] float paralax;
    Material mat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mat.mainTextureOffset += new Vector2(paralax * Time.deltaTime, 0);
    }
}
