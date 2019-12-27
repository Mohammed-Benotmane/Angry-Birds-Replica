using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private bool isPressed = false;
    public Rigidbody2D rb;

    void Update(){
        if(isPressed){
            rb.position = Camera.main.ScreenToWorldPoint( Input.mousePosition);
        }
    }
    void OnMouseDown(){
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp(){
        isPressed = false;
        rb.isKinematic = false;
    }
}
