using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quitter()
    {
        
        Application.Quit();
        Debug.Log("EXIT");
        
    }
}
