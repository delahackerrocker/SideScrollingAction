﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyYusuf : MonoBehaviour
{
    public GameObject player;
    //Crated two variables

    public int EnemySpeed;

    public int XMoveDirection;


    // Update is called once per frame
    void Update()
    {
        //Changes direction when enemy hits Player
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(XMoveDirection, 0));

        if ((player.transform.position.x - this.transform.position.x) < 2f ) 
        {
            // flip around
            Flip();
        }

        //Defines enemy speed and position
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(XMoveDirection, 0) * EnemySpeed;

        //Define hit 
        if (hit.distance < 0.7f) {
            //Flip();
        }


      }
    
    void Flip() {
        if (XMoveDirection > 0) {

           XMoveDirection = -1;
        } else {
            XMoveDirection = -1;
        } 

    }
}