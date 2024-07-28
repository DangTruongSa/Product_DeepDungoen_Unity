using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{



    public float speed = 2;

    public GameObject pausepn, player1;
    public TMP_Text scoretext;

    float posix, posiy, posiz;
    public int diem;
    SavePositionScript savePositionScript;
    public GameObject bullet, bigbullet;
    int sldan = 10;
    float timer, timerb;
    public int lifepoint = 3;
    public TMP_Text txtsldan, txtlifepoint;
    public GameObject UIbulletpnsmall, UIbulletpnbig;


    // Start is called before the first frame update
    void Start()
    {
        SoundController.Instance.PlaySoundSoundTrack();

        int.TryParse(LoginScript.UserName.score, out diem);
        scoretext.text = diem + "";


        float.TryParse(LoginScript.UserName.posix, out posix);
        float.TryParse(LoginScript.UserName.posiy, out posiy);
        float.TryParse(LoginScript.UserName.posiz, out posiz);
        Debug.Log(posix + "");
        Debug.Log(posiy + "");
        Debug.Log(posiz + "");
        Debug.Log(diem);

        player1.transform.position = new Vector3(posix, posiy, posiz);
    }

    // Update is called once per frame
    void Update()
    {
        txtsldan.text = sldan + "";
        txtlifepoint.text = lifepoint + "";


        if (Input.GetKey(KeyCode.Escape))
        {
            pausepn.SetActive(true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Time.deltaTime * -speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, Time.deltaTime * -speed, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, Time.deltaTime * speed, 0);
        }

        UIbulletpnsmall.SetActive(true);
        if (Input.GetKeyDown(KeyCode.F) && sldan > 0)
        {
            timer = Time.time;
            SoundController.Instance.PlaySoundholdattack();
            SoundController.Instance.PlaySoundSoundTrack();

        }



        if (Input.GetKeyUp(KeyCode.F) && sldan > 0)
        {
            timerb = Time.time;
            // SoundController.Instance.PlaySoundattack();

            if (timerb - timer >= 2)
            {
                timer = 0;
                timerb = 0;

                SoundController.Instance.Stopholdattack();
                SoundController.Instance.PlaySoundattack();
                SoundController.Instance.PlaySoundSoundTrack();
                Vector3 playerposition = transform.position;
                playerposition.y += 0.5f;
                //Instantiate(bigbullet, playerposition, Quaternion.identity);
                GameObject att = Instantiate(bullet, playerposition, Quaternion.identity);
                att.transform.localScale *= 2;
                sldan--;
            }
            else
            {

                SoundController.Instance.Stopholdattack();
                SoundController.Instance.PlaySoundattack();
                SoundController.Instance.PlaySoundSoundTrack();
                timer = 0;
                timerb = 0;

                Vector3 playerposition = transform.position;
                playerposition.y += 0.5f;
                Instantiate(bullet, playerposition, Quaternion.identity);
                sldan--;
            }
        }




    }



    public void OnTriggerEnter2D(Collider2D collider)
    {



        if (collider.transform.CompareTag("coin"))
        {
            string name = collider.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            diem += 50;
            scoretext.text = diem + "";
        }

        if (collider.transform.CompareTag("chestbullet"))
        {
            string name = collider.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            sldan += 10;
            txtsldan.text = sldan + "";
        }
        if (collider.transform.CompareTag("bullet1"))
        {
            string name = collider.attachedRigidbody.name;
            Destroy(GameObject.Find(name));
            sldan += 1;
            txtsldan.text = sldan + "";
        }

    }

    public void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.transform.CompareTag("monter"))
        {

            lifepoint--;
            txtlifepoint.text = lifepoint + "";

            if (lifepoint == 0)
            {
                Destroy(gameObject);
                SoundController.Instance.StopSuondTrack();
                SoundController.Instance.PlaySoundplayerdie();

            }
        }
    }


    public static player Scoreplayer;
    void Awake()
    {
        Scoreplayer = this;
    }




}
