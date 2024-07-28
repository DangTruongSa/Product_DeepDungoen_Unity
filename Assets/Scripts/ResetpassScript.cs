using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ResetpassScript : MonoBehaviour
{
    public TMP_InputField edtgmail, edtotp, edtnewpass;
    public TMP_Text txtMessage;
    bool isActive;
    public GameObject loadingpn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        loadingpn.SetActive(isActive);


    }

    public void runfunction()
    {
        StartCoroutine(SendOTP());
        SendOTP();
        isActive = true;
    }

    public void runResetpass()
    {
        StartCoroutine(ResetPass());
        ResetPass();
    }
    IEnumerator SendOTP()
    {
        string gmail = edtgmail.text;
        txtMessage.text = "";


        UserRegisterModel OTPModel = new UserRegisterModel(gmail);
        string jsonStringRequest = JsonConvert.SerializeObject(OTPModel);

        var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/send-otp", "POST");
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
            isActive = false;
            var jsonString = request.downloadHandler.text.ToString();
            MessageModel message = JsonConvert.DeserializeObject<MessageModel>(jsonString);
            txtMessage.text = message.notification;
        }
        request.Dispose();
    }

    IEnumerator ResetPass()
    {
        string gmail = edtgmail.text;
        string otp = edtotp.text;
        string newpass = edtnewpass.text;
        txtMessage.text = "";

        UserRegisterModel userModel = new UserRegisterModel(gmail, otp, newpass);
        string jsonStringRequest = JsonConvert.SerializeObject(userModel);

        var request = new UnityWebRequest("https://hoccungminh.dinhnt.com/fpt/reset-password", "POST");
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
}
