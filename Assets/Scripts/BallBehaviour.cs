using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private bool isPressed = false;
    public Rigidbody2D rb;
    public Rigidbody2D hook;

    public TrailRenderer trail;

    public float releaseTime = .15f;
    public float maxDistance = 6f;

    void Update(){
        if(isPressed){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition);
            if(Vector3.Distance(mousePos,hook.position)> maxDistance)
                rb.position = hook.position + (mousePos -hook.position ).normalized * maxDistance;
            else
                rb.position = mousePos; 
        }
    }
    void OnMouseDown(){
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp(){
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
        trail.enabled = true;
    }

    IEnumerator Release(){
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
    }
}
