using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class SavePositionScript : MonoBehaviour
{
    public TMP_Text usernametag, txtMessage;

    string user, posix, posiy, posiz;
    int score;
    public GameObject player1;
    public TMP_Text scoretext;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Exit()
    {
        SceneManager.LoadScene("LRScene");
    }

    public void runfunction()
    {
        StartCoroutine(SavePosition());
        SavePosition();
        StartCoroutine(SaveScore());
        SaveScore();
    }

    IEnumerator SavePosition()
    {
        user = LoginScript.UserName.user;
        string positionX = player1.transform.position.x + "";
        string positionY = player1.transform.position.y + "";
        string positionZ = player1.transform.position.z + "";

        SavePositionModel userLoginModel = new SavePositionModel(user, positionX, positionY, positionZ);

        string jsonStringRequest = JsonConvert.SerializeObject(userLoginModel);

        var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/save-position", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            MessageModel message = JsonConvert.DeserializeObject<MessageModel>(jsonString);
            txtMessage.text = message.notification;


        }
        request.Dispose();
    }

    IEnumerator SaveScore()
    {
        user = LoginScript.UserName.user;

        score = player.Scoreplayer.diem;


        SaveScoreModel saveScoreModel = new SaveScoreModel(user, score);

        string jsonStringRequest = JsonConvert.SerializeObject(saveScoreModel);

        var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/save-score", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            MessageModel message = JsonConvert.DeserializeObject<MessageModel>(jsonString);
            txtMessage.text = message.notification;


        }
        request.Dispose();
    }


    public void indiem(int score)
    {
        scoretext.text = score.ToString();
    }





}
