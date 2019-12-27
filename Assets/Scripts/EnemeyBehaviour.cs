using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyBehaviour : MonoBehaviour
{

    public Animation anim;
    public float health = 1000f;
    void OnCollisionEnter2D(Collision2D collision2D){
        print(collision2D.relativeVelocity.magnitude);
        Debug.Log(collision2D.relativeVelocity.magnitude);
        if(collision2D.relativeVelocity.magnitude > health){
            StartCoroutine(DeathAnimation());
            
        }
    }

    IEnumerator DeathAnimation(){
        anim.Play();
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }
}
