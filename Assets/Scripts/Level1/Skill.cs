using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

//Недоделал
public class Skill
{
    public int _costCard { get; private set; }//Стоимость карты
    public bool _usedСard;//Активность карты использованна или нет
    public string _name { get; private set; }//Имя карты
    private int _factor;//Множитель
    private bool _unlock;//Разблокированна ли карта в магазине    

    public Skill(string name, int _costCard)
    {
        this._costCard = _costCard;        
        this._name = name;
        this._unlock = false;
        this._factor = 1;        
    }
    //Действие карты
    //Принимает состояние бота человека(Свободен/занят)
    //Возвращает очки главного прогресса с +/-
    public float ActionCard(bool doNotDisturb, bool catClose = true)
    {
        float mainAccountPoints = 0;        
        if (doNotDisturb)
        {
            mainAccountPoints -= 0.1f* this._factor;
            
        }
        else if (!doNotDisturb && catClose) 
        {
            mainAccountPoints += 0.1f* this._factor;
        }
        _usedСard = true;//Карта использованна
        return mainAccountPoints;
    }
    //При улучшении карты скила множитель растет
    //Возвращает половину стоимости карты (Стоимость улучшения равна половине стоимости)
    public int UpgradeCards()
    {
        this._factor += 1;
        return this._costCard/2;
    }
    //Восстанавливает активность карты после использования
    //Возвращает 1/4 стоимости (Столько стоит восстановление карты)
    public int CardActivity()
    {
        this._usedСard = false;
        return this._costCard / 4;
    }
    //При использовании карта блокируется
    public void UsedCardDeActivity()
    {
        this._usedСard = true;        
    }

    //Разблокировать карту в магазине
    //Возвращает полную стоимость карты
    public int BuyUnlockCards()
    {
        this._unlock = true;
        return this._costCard;
    }    
}
