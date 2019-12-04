using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Рендеринг цвета кота на разных сценах
public class ColorCatRenderer : MonoBehaviour
{
    public Color SetColor(string color)
    {
        switch (color)
        {
            case "Red":
                return new Color(255, 0, 0, 255);
            case "Blue":
                return new Color(0, 0, 255, 255);
            case "Black":
                return new Color(0, 0, 0, 255);
            case "Orange":
                return new Color(255, 100, 0, 255);
            case "White":
                return new Color(255, 255, 255, 255);
            default:
                return new Color(255, 255, 255, 255);
        }
    }
}
