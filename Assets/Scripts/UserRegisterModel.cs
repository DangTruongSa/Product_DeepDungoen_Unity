using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserRegisterModel
{
    public UserRegisterModel(string username)
    {
        this.username = username;
    }

    public UserRegisterModel(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public UserRegisterModel(string username, string otp, string newpassword)
    {
        this.username = username;
        this.otp = otp;
        this.newpassword = newpassword;
    }

    public string password { get; set; }
    public string username { get; set; }
    public string otp { get; set; }
    public string newpassword { get; set; }

    public string positionX { get; set; }
    public string positionY { get; set; }
    public string positionZ { get; set; }
}
