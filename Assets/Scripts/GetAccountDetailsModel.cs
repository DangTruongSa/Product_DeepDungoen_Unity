using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAccountDetailsModel
{
    public GetAccountDetailsModel(string username, string password, string score, string positionX, string positionY, string positionZ, string otp)
    {
        this.username = username;
        this.password = password;
        this.score = score;
        this.positionX = positionX;
        this.positionY = positionY;
        this.positionZ = positionZ;
        this.otp = otp;
    }

    public string username { get; set; }
    public string password { get; set; }
    public string score { get; set; }
    public string positionX { get; set; }
    public string positionY { get; set; }
    public string positionZ { get; set; }
    public string otp { get; set; }

}
