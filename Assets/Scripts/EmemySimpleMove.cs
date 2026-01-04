using UnityEngine;

public class EmemySimpleMove : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float speed;
    [SerializeField] float maxDistance;
    [SerializeField] bool moveRight;

    float initialPosition;
    float direction;
    float distanceTravelled;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        // Posición de partida
        initialPosition = transform.position.x;

        // Sentido de movimiento
        direction = moveRight ? 1 : -1;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculamos el nuevo incremento en la posición
        // Nos dara el valor "positivo" ó "negativo" según nos estemos desplazando
        float movement = speed * Time.deltaTime * direction;
        transform.Translate(new Vector2(movement, 0));

        // Actualizamos la distancia recorrida
        distanceTravelled += Mathf.Abs(movement);

        // Si la distancia recorrida es "mayor o igual" a la distancia máxima
        if (distanceTravelled >= maxDistance)
        {
            // Invertimos el sentido de desplazamiento de nuestro enemigo
            direction *= -1;
            // Reiniciamos la distancia viajada a "0".
            distanceTravelled = 0;
            // Cambiamos la orientación del sprite
            // Accedemos a la propiedad "flipX" que controla la orientación del sprite en el eje X.
            // Invertimos el valor actual (booleano)
            sr.flipX = !sr.flipX;
        }
    }


}
