using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public GameObject towerObject;
    public Sprite towerSprite;

    public GameObject TowerObject
    {
        get
        {
            return towerObject;
        }
    }    
    
    public Sprite TowerSprite
    {
        get
        {
            return towerSprite;
        }
    }
}
