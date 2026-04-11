using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public List<string> isTorchLit = new List<string>();
    public GameObject flintlock;
    private bool isSolved = false;
    public KnockoutTarget[] targets;      // Assign all dummies in Inspector
    public GameObject winObject;          // GameObject to activate when all hit
    public GameObject Chest;


    // Update is called once per frame
    void Update()
    {

        if (!isSolved && isTorchLit.Count == 3)
        {
            isSolved = true;
            showFlintlock();
        }

        if(WinManager.Instance.isGameWon)
        {
            Chest.SetActive(true);
        }


    }

    void showFlintlock()
    {
        flintlock.SetActive(true);
    }

    public void OnTargetKnockedOut()
    {
        foreach (KnockoutTarget target in targets)
        {
            if (!target.IsKnockedOut) return;
        }

        winObject.SetActive(true);
        WinManager.Instance.isIslandWon = true;
    }


}
