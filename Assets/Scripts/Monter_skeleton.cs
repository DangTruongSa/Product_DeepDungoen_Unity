using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;



public class Monter_skeleton : MonoBehaviour
{
    public float left = 17, right = 21;


    bool isRight1 = true, isChase = false;
    public float speed = 5;
    public float chasespeed = 6;

    public float maxy, miny;

    public GameObject player;
    public GameObject coin;

    //float player.transform.position.y, player.transform.position.x;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float skeletonx = transform.position.x;
        float skeletony = transform.position.y;
        if (skeletonx < left)
        {
            isRight1 = true;
        }
        if (skeletonx > right)
        {
            isRight1 = false;
        }


        if (player.transform.position.y > miny && player.transform.position.y < maxy && player.transform.position.x >= left && player.transform.position.x <= right)
        {
            isChase = true;
        }
        else
        {
            isChase = false;
        }


        if (isChase)
        {
            if (player.transform.position.x < skeletonx)
            {
                transform.Translate(new Vector3(Time.deltaTime * -chasespeed, 0, 0));
                Vector2 v = transform.localScale;
                v.x = -4;
                transform.localScale = v;
            }
            else
            {
                transform.Translate(new Vector3(Time.deltaTime * chasespeed, 0, 0));
                Vector2 v = transform.localScale;
                v.x = 4;
                transform.localScale = v;
            }
        }
        else
        {
            if (isRight1)
            {
                transform.Translate(new Vector3(Time.deltaTime * speed, 0, 0));
                Vector2 v = transform.localScale;
                v.x = 4;
                transform.localScale = v;
            }
            else
            {
                transform.Translate(new Vector3(Time.deltaTime * -speed, 0, 0));
                Vector2 v = transform.localScale;
                v.x = -4;
                transform.localScale = v;
            }
        }



    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "bullet")
        {
            SoundController.Instance.PlaySoundKill();
            int rd = Random.Range(3, 5);
            Destroy(gameObject);
            for (int i = 0; rd >= i; i++)
            {
                float rdRangex = Random.Range(0.1f, 1f);
                float rdRangey = Random.Range(0.1f, 1f);
                Vector3 monterposition = transform.position;
                monterposition.x += rdRangex;
                monterposition.y += rdRangey;
                Instantiate(coin, monterposition, Quaternion.identity);
            }
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("monter"))
        {
            if (transform.localScale.x > 0)
            {
                isRight1 = false;
            }
            else
            {
                isRight1 = true;
            }


        }
    }






}










