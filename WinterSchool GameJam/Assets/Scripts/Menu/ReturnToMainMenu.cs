using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public void ReturnToMainMenuFunc()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}
