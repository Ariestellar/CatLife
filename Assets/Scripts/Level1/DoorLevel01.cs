using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Реализует состояние кнопок-дверей на сцене
public class DoorLevel01 : MonoBehaviour
{
    public bool goAnotherFloor;//для проверки актуальности анимации двери

    private void FixedUpdate()
    {       
        goAnotherFloor = GameObject.Find("Bot").GetComponent<BotLevel01>().goAnotherFloor;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" )
        {
            gameObject.GetComponent<Image>().enabled = true;
        }

        if (other.tag == "Bot" && goAnotherFloor)//Если бот которому нужно на другой этаж проходят возле двери
        {
            gameObject.GetComponent<Image>().enabled = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Bot")
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
    }
}
