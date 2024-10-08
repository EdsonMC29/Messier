using UnityEngine;

public class Rotacion : MonoBehaviour
{
    // Velocidad de rotación
    public float rotationSpeed = 50f; // Velocidad en grados por segundo

    // Ángulo de inclinación ajustable desde el Inspector
    public Vector3 inclination = new Vector3(13f, 0f, 0f);  // Inclinación inicial predeterminada en el eje X

    void Start()
    {
        // Aplicar la inclinación inicial al objeto
        transform.rotation = Quaternion.Euler(inclination);
    }

    void Update()
    {
        // Rotar sobre su propio eje Y, manteniendo la inclinación
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
