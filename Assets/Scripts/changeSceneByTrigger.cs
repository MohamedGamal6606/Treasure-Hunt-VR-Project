using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSceneByTrigger : MonoBehaviour
{
   public GameObject sceneManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sceneManager.GetComponent<SceneChangeScript>().Load();
        }
    }

}
