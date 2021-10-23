using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public TowerButton towerButtonPressed = null;

    public SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
                hit.collider.tag = "TowerPlaced";
                PlaceTower(hit);
            }
        }

        if(spriteRenderer.enabled)
        {
            spriteRenderer.enabled = true;
            FollowMouse();
        }
    }

    public void PlaceTower(RaycastHit2D hit)
    {
        if(towerButtonPressed != null)
        {
            GameObject newTower = Instantiate(towerButtonPressed.TowerObject);
            newTower.transform.position = hit.transform.position;
            towerButtonPressed = null;
            DisableDrag();
        } else
        {
            Debug.Log("Please choose tower");
        }

    }

    public void SelectedTower(TowerButton towerSeleted)
    {
        if(towerButtonPressed == null)
        {
            towerButtonPressed = towerSeleted;
            EnableDrag(towerButtonPressed.TowerSprite);
            Debug.Log("Pressed " + towerButtonPressed);
        } else
        {
            towerButtonPressed = null;
            DisableDrag();
        }
    }

    public void FollowMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    public void EnableDrag(Sprite sprite)
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = sprite;
    }    
    
    public void DisableDrag()
    {
        spriteRenderer.enabled = false;
    }
}
