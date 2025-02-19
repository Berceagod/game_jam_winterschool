using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyMusicOnSceneChange : MonoBehaviour
{
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Menu" || scene.name!="Levels") 
        {
            Destroy(gameObject); 
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
