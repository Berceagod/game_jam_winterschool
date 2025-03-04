using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel1 : MonoBehaviour
{
    public void PlayLevels()
    {
        SceneManager.LoadSceneAsync("Levels");
    }
}