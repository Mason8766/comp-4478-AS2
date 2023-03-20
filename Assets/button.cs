using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//allows to start new activity
public class button : MonoBehaviour
{
    public void OnButtonPress()//Onclick Event
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//changes the activity (Refreshes)
    }
}
