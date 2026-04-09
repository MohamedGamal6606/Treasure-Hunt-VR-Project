using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public List<string> isTorchLit = new List<string>();
    public GameObject flintlock;
    private bool isSolved = false;
    // Update is called once per frame
    void Update()
    {

        if (!isSolved && isTorchLit.Count == 3)
        {
            isSolved = true;
            showFlintlock();
        }




    }

    void showFlintlock()
    {
        flintlock.SetActive(true);
    }

}
