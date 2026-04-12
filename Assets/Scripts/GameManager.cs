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

    public AudioClip flintlockAppearSound;

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

    public void disappear()
    {
        winObject.SetActive(false);
        WinManager.Instance.isIslandWon = true;
    }

    void showFlintlock()
    {
        flintlock.SetActive(true);
        flintlock.GetComponent<AudioSource>().PlayOneShot(flintlockAppearSound);
    }

    public void OnTargetKnockedOut()
    {
        foreach (KnockoutTarget target in targets)
        {
            if (!target.IsKnockedOut) return;
        }

        winObject.SetActive(true);
        
    }


}
