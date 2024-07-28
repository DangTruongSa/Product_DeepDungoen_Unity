using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
public class LoginScript : MonoBehaviour
{
    public TMP_InputField edtuser, edtpass;
    public TMP_Text txtMessage;

    public string user, posix, posiy, posiz, score;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void runfunction()
    {
        StartCoroutine(Login());
        Login();
        StartCoroutine(GetPosition());
        GetPosition();
    }


    IEnumerator Login()
    {
        user = edtuser.text;
        string pass = edtpass.text;
        txtMessage.text = "";


        UserRegisterModel userLoginModel = new UserRegisterModel(user, pass);

        string jsonStringRequest = JsonConvert.SerializeObject(userLoginModel);

        var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/login", "POST");
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



            if (txtMessage.text.Equals("Đăng nhập thành công"))
            {
                SceneManager.LoadScene("SampleScene");
            }


        }
        request.Dispose();
    }

    IEnumerator GetPosition()
    {
        user = edtuser.text;

        // SavePositionModel userLoginModel = new SavePositionModel(user, posix, posiy, posiz);
        // string jsonStringRequest = JsonConvert.SerializeObject(userLoginModel);

        var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/details?id=" + user, "GET");
        //byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        //request.uploadHandler = new UploadHandlerRaw(bodyRaw);
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

            GetAccountDetailsModel data = JsonConvert.DeserializeObject<GetAccountDetailsModel>(jsonString);
            posix = data.positionX;
            posiy = data.positionY;
            posiz = data.positionZ;
            score = data.score;
        }
        request.Dispose();



    }




    public static LoginScript UserName;
    void Awake()
    {
        UserName = this;
    }

}
