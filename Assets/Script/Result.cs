using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class Result : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI classText;
    public TextMeshProUGUI finishText;

    float alpha = 0;

    bool returnTitle = false;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "誤差：" + GameManager.diff.ToString("N2") + "度";
        if (GameManager.diff < 10)
        {
            classText.text = "OZIGI名人";
        }
        else if (GameManager.diff < 30)
        {
            classText.text = "OZIGI1級";
        }
        else if (GameManager.diff < 90)
        {
            classText.text = "OZIGI2級";
        }
        else if (GameManager.diff < 180)
        {
            classText.text = "OZIGI3級";
        }
        else if (GameManager.diff < 270)
        {
            classText.text = "OZIGI4級";
        }
        else
        {
            classText.text = "OZIGI5級";
        }
        StartCoroutine("Finish");
    }


    // Update is called once per frame
    void Update()
    {
        //finishテキストフェードイン
        finishText.color = new Color(0, 0, 0, alpha);

        //タイトルに戻る
        if (returnTitle && Input.GetMouseButtonDown(0))
        {
            Destroy(GameObject.Find("AudioManager"));
            GameManager.round = 0;
            SceneManager.LoadScene("Title");
        }
    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(2);

        //フェードイン用
        DOTween.To(() => alpha, (x) => alpha = x, 255, 3).SetEase(Ease.InExpo);
        returnTitle = true;
    }
}
