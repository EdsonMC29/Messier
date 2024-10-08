using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Referencia al componente AudioSource
    private AudioSource audioSource;

    void Start()
    {
        // Obtener el componente AudioSource del objeto
        audioSource = GetComponent<AudioSource>();

        // Verificar si hay un AudioSource y si tiene un clip asignado
        if (audioSource == null)
        {
            Debug.LogError("No se encontró AudioSource en el objeto.");
        }
        else if (audioSource.clip == null)
        {
            Debug.LogError("El AudioSource no tiene un audio clip asignado.");
        }
    }

    void Update()
    {
        // Verifica si se presiona la tecla "P" para reproducir el audio
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayAudio();
        }
    }

    // Método para reproducir el audio
    public void PlayAudio()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
