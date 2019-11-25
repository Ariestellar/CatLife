using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    public void ShowProgressBar(Animator animator)
    {
        animator.SetBool("isOpen",!animator.GetBool("isOpen"));
    }
    public void ShowDownPanel(Animator animator)
    {
        animator.SetBool("isOpen", !animator.GetBool("isOpen"));
    }
}
