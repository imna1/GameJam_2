using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRules : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            GameManager.Instance.TurnOnLewer();
            Destroy(gameObject);
        }
    }
}
