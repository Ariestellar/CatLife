using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [Header("Потребности")]
    [SerializeField] private int _naturalNeed;
    [SerializeField] private int _hunger;
    [SerializeField] private int _instincts;

    [Header("Карточки навыков")]
    [SerializeField] private int _card1;
    [SerializeField] private int _card2;
    [SerializeField] private int _card3;

    void Start()
    {
       
    }

}
