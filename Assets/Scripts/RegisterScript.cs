using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class RegisterScript : MonoBehaviour
{
    public TMP_InputField edtuser, edtpass, edtrepass;
    public TMP_Text txtMessage;


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

        StartCoroutine(Register());
        Register();
    }

    IEnumerator Register()
    {
        string user = edtuser.text;
        string pass = edtpass.text;
        string repass = edtrepass.text;
        txtMessage.text = "";

        if (pass.Equals(repass))
        {
            UserRegisterModel userRegisterModel = new UserRegisterModel(user, pass);

            string jsonStringRequest = JsonConvert.SerializeObject(userRegisterModel);

            var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/register", "POST");
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
        else
        {
            txtMessage.text = "Mật khẩu không trùng lặp!!!";
        }



    }
}
