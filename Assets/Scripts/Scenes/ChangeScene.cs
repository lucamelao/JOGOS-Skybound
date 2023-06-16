using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void Change(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}