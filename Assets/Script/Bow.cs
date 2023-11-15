using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Bow : MonoBehaviour
{
    public Fade fade;

    public GameObject MoveBar;
    public GameObject Bar;

    public TextMeshProUGUI Bartext;

    //初速度
    public float iv = 50;

    //抵抗
    public float res = 10;

    //目標角度
    public float target = 0;

    public float degree = 0;

    public float result = 0;

    float bar = 0;
    float before = 0;

    //中心座標
    Vector3 center = new(1.8f, -1, 0);

    //回転軸
    Vector3 axis = Vector3.forward;

    bool isbow = false;
    bool isBarMove = false;

    public void Start()
    {
        Bar.transform.RotateAround(center, axis, -target);
    }

    // Update is called once per frame
    public void bow()
    {
        iv /= res;
        float dulation = iv * 0.1f;
        isbow = true;
        DOTween.To(() => iv, (x) => iv = x, 0, dulation).SetEase(Ease.OutCirc).OnComplete(GetAngle);
    }

    void Update()
    {
        if (isbow)
        {
            transform.RotateAround(center, axis, -iv / res);
        }
        if (isBarMove)
        {
            if (degree - target < 180 && degree > target)
            {
                MoveBar.transform.RotateAround(center, axis, bar - before);
            }
            else
            {
                MoveBar.transform.RotateAround(center, axis, before - bar);
            }
            Bartext.text = "誤差:" + bar.ToString("N2") + "度";
            before = bar;
        }
    }

    //角度取得
    void GetAngle()
    {
        Vector3 dt = transform.position - center;
        float rad = Mathf.Atan2(dt.y, dt.x);
        degree = rad * Mathf.Rad2Deg;

        //上方向を0°に変換
        degree = 360 - (degree + 180);
        if (degree < 90)
        {
            degree += 270;
        }
        else
        {
            degree -= 90;
        }

        result = Mathf.Abs(degree - target);
        if (result > 180)
        {
            result = 360 - result;
        }

        GameManager.diff += result;

        StartCoroutine("BarMove");
    }

    IEnumerator BarMove()
    {
        MoveBar.transform.RotateAround(center, axis, -degree);

        DOTween.To(() => bar, (x) => bar = x, result, 3).SetEase(Ease.OutCirc);

        isBarMove = true;

        yield return new WaitForSeconds(5);

        fade.StartCoroutine("SceneChange");
    }
}
