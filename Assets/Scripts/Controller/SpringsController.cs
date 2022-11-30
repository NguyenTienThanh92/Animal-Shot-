using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringsController : MonoBehaviour
{
    [SerializeField] private float bounce = 20f;

   private void OnCollisionEnter2D(Collision2D colision)
   {
       if (colision.gameObject.CompareTag("Player"))
       {
           colision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
       }
   }
}
