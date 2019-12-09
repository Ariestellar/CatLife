using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMainMenu : MonoBehaviour
{
    [SerializeField] private LoadDate _load;
    [SerializeField] private bool _checkingFirstRun;
    [SerializeField] private GameObject _buttonContinue;
    public void Start()
    {
        _checkingFirstRun = _load.TutorialPanel();
        if (_checkingFirstRun)
        {
            _buttonContinue.GetComponent<Button>().interactable = true;
            _buttonContinue.GetComponent<Image>().color =  new Color(255, 255, 255, 255);
        }
    }
    public void PlayLevel(string LevelLabel)
    {
        SceneManager.LoadScene(LevelLabel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void newGame(string LevelLabel)
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(LevelLabel);
    }
}
