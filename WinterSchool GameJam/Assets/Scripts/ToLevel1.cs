using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevel1 : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadSceneAsync("FinalGAME");
    }
}