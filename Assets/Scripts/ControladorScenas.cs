using UnityEngine;
using UnityEngine.SceneManagement;
public class ControladorScenas : MonoBehaviour
{

    // Este método cierra la aplicación en Android
    public void ExitApplication()
    {
        #if UNITY_EDITOR
            // Para cerrar la aplicación en el editor de Unity
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_ANDROID
            // Para cerrar la aplicación en Android
            Application.Quit();
        #endif
    }

    public void SceneExoCG()
    {
        // Verifica que la escena esté incluida en el Build Settings
        if (Application.CanStreamedLevelBeLoaded("Exoplaneta_GJ"))
        {
            SceneManager.LoadScene("Exoplaneta_GJ");
        }
        else
        {
            Debug.LogError("La escena '" + "Exoplaneta_GJ" + "' no está en el Build Settings o no existe.");
        }
    }

    public void SceneMarte()
    {
        // Verifica que la escena esté incluida en el Build Settings
        if (Application.CanStreamedLevelBeLoaded("Exoplaneta_marte"))
        {
            SceneManager.LoadScene("Exoplaneta_marte");
        }
        else
        {
            Debug.LogError("La escena '" + "Exoplaneta_marte" + "' no está en el Build Settings o no existe.");
        }
    }

    public void SceneMenu()
    {
      
        SceneManager.LoadScene("MenuInicio");
    
    }
   
}

