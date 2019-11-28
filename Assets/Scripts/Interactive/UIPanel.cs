using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreTotalText = null;
    [SerializeField] private LoadDate _load = null;  

    private void Start()
    {
        
    }
    private void Update()
    {
        _scoreTotalText.text = Convert.ToString(_load.Score());
    }
    public void ShowProgressBar(Animator animator)
    {
        animator.SetBool("isOpen",!animator.GetBool("isOpen"));
    }
    public void ShowDownPanel(Animator animator)
    {
        animator.SetBool("isOpen", !animator.GetBool("isOpen"));
    }
}
