using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int round = 0;

    public static float diff = 0;

    public Bow bow;

    public TextMeshProUGUI Situation;
    public TextMeshProUGUI Degree;
    public TextMeshProUGUI Resistance;

    public void Awake()
    {
        switch(GameManager.round)
        {
            case 0:
                break;
            case 1:
                bow.res = 40;
                bow.target = 15;
                Situation.text = "同僚に挨拶をする";
                Degree.text = "目標:会釈(十五度)";
                Resistance.text = "抵抗感:普通";
                break;
            case 2:
                bow.res = 200;
                bow.target = 30;
                Situation.text = "嫌いな上司のお出迎え";
                Degree.text = "目標:敬礼(三十度)";
                Resistance.text = "抵抗感:高め";
                break;
            case 3:
                bow.res = 1;
                bow.target = 45;
                Situation.text = "社長にお礼をする";
                Degree.text = "目標:最敬礼(四十五度)";
                Resistance.text = "抵抗感:無";
                break;
            default:
                Debug.Log("roundの値に問題があります");
                break;
        }
    }
}
