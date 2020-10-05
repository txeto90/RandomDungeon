using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public GameObject hitEffect;

    //OnTriggerEnter2D(Collision2D collision)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == null) return;
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        if(collision.gameObject.tag == "RoomObstacles")
        {

            Destroy(gameObject);
            return;

        }else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>()?.Attacked();
            //colisiona amb el enemic
            Destroy(gameObject);
            //collision.gameObject.SendMessage("Attacked");
            return;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
