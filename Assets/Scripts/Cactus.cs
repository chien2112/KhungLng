using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    float xPos;
    float yPos;
    private void Start()
    {
        yPos = transform.position.y;
        xPos = transform.position.x;
    }
    void Update()
    {
        xPos -= 5* Time.deltaTime;

        transform.position = new Vector2(xPos, yPos);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            GameController.instance.Lose();
        }
    }
}
