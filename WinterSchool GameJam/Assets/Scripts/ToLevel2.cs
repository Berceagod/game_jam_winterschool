using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel2 : MonoBehaviour
{
    public void PlayLevel2()
    {
        SceneManager.LoadSceneAsync("Level2Cutscene");
    }
}