using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    public void Level1Func()
    {
        SceneManager.LoadSceneAsync("BerceaTest");
    }
}
