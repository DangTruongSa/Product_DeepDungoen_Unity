using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject addbullet;

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * 6f * Time.deltaTime);

    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "monter")
        {
            Destroy(gameObject);
        }
        if (collider2D.gameObject.tag == "wall")
        {
            if (gameObject.transform.localScale.x > 3)
            {
                Vector3 bulletposition = transform.position;
                bulletposition.y -= 0.5f;
                Destroy(gameObject);

                GameObject att = Instantiate(addbullet, bulletposition, Quaternion.identity);
                att.transform.localScale *= 2;
            }
            else
            {
                Vector3 bulletposition = transform.position;
                bulletposition.y -= 0.5f;
                Destroy(gameObject);

                Instantiate(addbullet, bulletposition, Quaternion.identity);
            }



        }

    }




}
