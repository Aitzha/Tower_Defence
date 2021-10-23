using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public TowerButton towerButtonPressed = null;


    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePoint, Vector2.zero);


            if(hit.collider.tag == "TowerSpot")
            {
                PlaceTower(hit);
            }
        }
    }

    public void PlaceTower(RaycastHit2D hit)
    {
        if(towerButtonPressed != null)
        {
            GameObject newTower = Instantiate(towerButtonPressed.TowerObject);
            newTower.transform.position = hit.transform.position;
            towerButtonPressed = null;
        } else
        {
            Debug.Log("Please choose tower");
        }

    }

    public void SelectedTower(TowerButton towerSeleted)
    {
        towerButtonPressed = towerSeleted;
        Debug.Log("Pressed " + towerButtonPressed);
    }
}
