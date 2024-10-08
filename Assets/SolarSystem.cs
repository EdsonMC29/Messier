using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    // Constante gravitacional
    readonly float G = 100f;
    GameObject[] celestials;
    Vector3[] initialPositions;  // Para almacenar las posiciones originales

    // Start is called before the first frame update
    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");

        // Guardar las posiciones iniciales
        initialPositions = new Vector3[celestials.Length];
        for (int i = 0; i < celestials.Length; i++)
        {
            initialPositions[i] = celestials[i].transform.position;
        }

        InitialVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Gravity();
    }

    void Gravity()
    {
        foreach (GameObject a in celestials)
        {
            Rigidbody rbA = a.GetComponent<Rigidbody>();
            foreach (GameObject b in celestials)
            {
                if (!a.Equals(b))
                {
                    Rigidbody rbB = b.GetComponent<Rigidbody>();
                    float m1 = rbA.mass;
                    float m2 = rbB.mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    // Aplicar la fuerza gravitacional
                    Vector3 force = (b.transform.position - a.transform.position).normalized * (G * (m1 * m2) / (r * r));
                    rbA.AddForce(force);
                }
            }
        }
    }

    void InitialVelocity()
    {
        GameObject sun = null;

        // Encontrar el objeto más masivo (como el Sol)
        foreach (GameObject celestial in celestials)
        {
            if (sun == null || celestial.GetComponent<Rigidbody>().mass > sun.GetComponent<Rigidbody>().mass)
            {
                sun = celestial;  // Asignar el objeto más masivo como el Sol
            }
        }

        if (sun == null)
        {
            Debug.LogError("No se encontró un objeto con masa suficiente para ser considerado el Sol.");
            return;
        }

        Rigidbody sunRb = sun.GetComponent<Rigidbody>();

        // Aplicar velocidad orbital a los planetas
        foreach (GameObject planet in celestials)
        {
            if (!planet.Equals(sun))
            {
                Rigidbody planetRb = planet.GetComponent<Rigidbody>();
                float distance = Vector3.Distance(planet.transform.position, sun.transform.position);

                // Dirigir el planeta hacia el Sol
                planet.transform.LookAt(sun.transform);

                // Calcular la velocidad inicial para una órbita estable (plano horizontal)
                Vector3 orbitalVelocity = planet.transform.right * Mathf.Sqrt((G * sunRb.mass) / distance);

                // Asignar la velocidad orbital
                planetRb.velocity = orbitalVelocity;
            }
        }
    }

    // Función para restablecer la posición de los objetos "Celestials" a su posición inicial
    public void ResetCelestialPositions()
    {
        for (int i = 0; i < celestials.Length; i++)
        {
            Rigidbody rb = celestials[i].GetComponent<Rigidbody>();

            // Detener cualquier movimiento actual
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Restablecer la posición inicial
            celestials[i].transform.position = initialPositions[i];
        }
        Debug.Log("Posiciones de los objetos 'Celestial' restauradas.");
    }

    // Función para activar/desactivar el movimiento de un objeto
    public void ActivarMovimiento()
    {
        // Verifica si el objeto está activo
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);  // Desactiva el objeto
        }
        else
        {
            gameObject.SetActive(true);   // Activa el objeto
        }
    }
}
