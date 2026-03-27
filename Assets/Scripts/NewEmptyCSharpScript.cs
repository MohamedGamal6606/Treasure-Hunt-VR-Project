using System;
using UnityEngine;

public class NewEmptyCSharpScript : MonoBehaviour
{
    public GameObject uiPanel; // assign in inspector



    public void Hello()
    {
        uiPanel.SetActive(!uiPanel.activeSelf);
        Debug.Log("Hello, World!");
    }


}
