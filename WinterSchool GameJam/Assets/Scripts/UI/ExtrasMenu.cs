using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayExtrasMenu : MonoBehaviour
{
    public void ExtrasMenu()
    {
        SceneManager.LoadSceneAsync("Extras");
    }
}
