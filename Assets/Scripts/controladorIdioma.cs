using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections;

public class controladorIdioma : MonoBehaviour
{
    private static controladorIdioma instance;
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
    }
    // Este método cambia el idioma a español
    public void SwitchToSpanish()
    {
        StartCoroutine(SetLocale("es"));  // Código para español (es)
    }

    // Este método cambia el idioma a inglés
    public void SwitchToEnglish()
    {
        StartCoroutine(SetLocale("en"));  // Código para inglés (en)
    }

    // Coroutine para cambiar el idioma de manera asíncrona
    IEnumerator SetLocale(string localeCode)
    {
        // Busca el locale disponible en el proyecto basado en el código (es, en, etc.)
        var locale = LocalizationSettings.AvailableLocales.GetLocale(localeCode);
        
        if (locale != null)
        {
            // Cambia el locale actual al seleccionado
            LocalizationSettings.SelectedLocale = locale;
            Debug.Log("Idioma cambiado a: " + localeCode);
        }
        else
        {
            Debug.LogError("Locale no encontrado: " + localeCode);
        }
        
        yield return null;
    }
}

