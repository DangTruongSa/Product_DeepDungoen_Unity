using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScoreModel
{
    public SaveScoreModel(string username, int score)
    {
        this.username = username;
        this.score = score;
    }

    public string username { get; set; }
    public int score { get; set; }
}