using UnityEngine;

public class WinManager : MonoBehaviour
{
    public static WinManager Instance { get; private set; }
    public bool isGameWon = false;
    public bool isShipWon = false;
    public bool isIslandWon = false;
    public bool isCaveWon = false;

    void Awake()
    {
        // If an instance already exists, destroy this duplicate
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isShipWon && isIslandWon && isCaveWon)
        {
                        isGameWon = true;
        }
    }
}
