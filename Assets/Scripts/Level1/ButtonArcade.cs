using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonArcade : MonoBehaviour
{   
    public void PlayArcade01()
     {
        SceneManager.LoadScene("Arcade01");   
     }

    public void PlayArcade02()
    {
        SceneManager.LoadScene("Arcade02");
    }

    public void PlayArcade03()
    {
        SceneManager.LoadScene("Arcade03");
    }


}
