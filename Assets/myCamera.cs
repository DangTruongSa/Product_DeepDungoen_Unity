using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCamera : MonoBehaviour
{
    public Transform player;

    public float minX, maxX, miny, maxy;
    internal static object current;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;
            temp.y = player.position.y;


            if (temp.x < minX)
            {
                temp.x = minX;
            }
            if (temp.x > maxX)
            {
                temp.x = maxX;
            }

            if (temp.y < miny)
            {
                temp.y = miny;
            }
            if (temp.y > maxy)
            {
                temp.y = maxy;
            }

            transform.position = temp;
        }


    }
}
