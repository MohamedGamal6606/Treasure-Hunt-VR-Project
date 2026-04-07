using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public List<string> isTorchLit = new List<string>();

    // Update is called once per frame
    void Update()
    {
        if (isTorchLit.Count == 3)
        {
            Debug.Log("All torches are lit! Puzzle solved!");
            // You can add additional logic here, such as opening a door or triggering an event.
        }




    }
}
