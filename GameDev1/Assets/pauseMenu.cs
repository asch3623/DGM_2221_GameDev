using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    public void ChangeTimeBack()
    {
        Time.timeScale = 1;
    }
}
