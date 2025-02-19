using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu1 : MonoBehaviour
{
    public void PlayGameFunc()
    {
        SceneManager.LoadSceneAsync("Levels");
    }
        public void ExtrasMenuFunc()
    {
        SceneManager.LoadSceneAsync("Extras");
    }
        public void QuitFunc()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
