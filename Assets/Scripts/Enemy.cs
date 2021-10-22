using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //target index enemy is moving to
    public int target = 0;

    //variable to save finish gameobject
    public Transform exit;

    //array of wayPoints
    public Transform[] wayPoints;

    //enemy speed
    public float speed = 1;

    //enemy itself
    private Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wayPoints != null)
        {
            if (target < wayPoints.Length)
            {
                enemy.position = Vector2.MoveTowards(enemy.position, wayPoints[target].position, speed * Time.deltaTime);
            }
            else
            {
                enemy.position = Vector2.MoveTowards(enemy.position, exit.position, speed * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "MovingPoint")
        {
            target += 1;
        } 
        else if(col.tag == "Finish")
        {
            Manager.instance.removeEnemyFromScreen();
            Destroy(gameObject);
        }
    }
}
