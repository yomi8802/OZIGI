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

    //抵抗感
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

    //目標角度設定
    void Start()
    {
        Bar.transform.RotateAround(center, axis, -target);
    }

    //お辞儀
    public void bow()
    {
        iv /= res; //抵抗に応じて初速度を減速
        
        //初速度に応じた長さでお辞儀を実行
        //お辞儀終了後GetAngleを実行
        float duration = iv * 0.1f;
        isbow = true;
        DOTween.To(() => iv, (x) => iv = x, 0, duration).SetEase(Ease.OutCirc).OnComplete(GetAngle);
    }

    void Update()
    {
        if (isbow)
        {
            transform.RotateAround(center, axis, -iv / res); //上半身回転
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
        //この手法だとx軸正の向きを0度として+-180度で計算される
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

    //結果表示
    IEnumerator BarMove()
    {
        //上半身位置にバー表示
        MoveBar.transform.RotateAround(center, axis, -degree);

        //上半身位置から目標角度まで動く
        DOTween.To(() => bar, (x) => bar = x, result, 3).SetEase(Ease.OutCirc);

        isBarMove = true;

        yield return new WaitForSeconds(5);

        //次ステージへ
        fade.StartCoroutine("SceneChange");
    }
}
