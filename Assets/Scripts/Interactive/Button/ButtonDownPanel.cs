using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonDownPanel : MonoBehaviour
{
    public void ExitLevel(string LevelLabel)
    {
        SceneManager.LoadScene(LevelLabel);
    }


}
