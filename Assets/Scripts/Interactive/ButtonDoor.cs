using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDoor : MonoBehaviour
{
    public bool goAnotherFloor;


    private void FixedUpdate()
    {
        goAnotherFloor = Bot.goAnotherFloor;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" )
        {
            gameObject.GetComponent<Image>().enabled = true;
        }

        if (other.tag == "Bot" && goAnotherFloor)
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
