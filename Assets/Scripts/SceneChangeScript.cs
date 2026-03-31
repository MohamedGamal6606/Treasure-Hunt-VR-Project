using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeScript : MonoBehaviour
{
    [Tooltip("Type the exact name of the scene here")]
    public string sceneName;

    public void Load()
    {
        Debug.Log("Entered load function");
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene Name is empty in the Inspector!");
        }
    }

}
