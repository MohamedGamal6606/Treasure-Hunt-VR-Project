using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public static WinManager Instance { get; private set; }
    public bool isGameWon = false;
    public bool isShipWon = false;
    public bool isIslandWon = false;
    public bool isCaveWon = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (!isGameWon && isShipWon && isIslandWon && isCaveWon)
        {
            isGameWon = true;
            SceneManager.LoadScene("End Scene");
        }
    }
}