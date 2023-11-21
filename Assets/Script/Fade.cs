using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Image fadeObj;
    float fade = 0;
    bool isfade = false;

    //最初のクリックでフェード＋シーンチェンジ
    void Update()
    {
        if(GameManager.round == 0 && Input.GetMouseButtonDown(0))
        {       
            StartCoroutine("SceneChange");
        }

        if(isfade)
        {
            Color new_color = fadeObj.color;
            new_color.a = fade;
            fadeObj.color = new_color;
        }
    }

    IEnumerator SceneChange()
    {
        //game画面の場合、シーンチェンジまでに猶予を持たせる
        if(1 <= GameManager.round && GameManager.round <= 3)
        {
            yield return new WaitForSeconds(2);
        }

        //α値をイージング
        DOTween.To (() => fade, (x) => fade = x, 255, 8).SetEase(Ease.InExpo);
        isfade = true;

        yield return new WaitForSeconds(5);

        //次ステージに移動
        GameManager.round++;
        switch(GameManager.round)
        {
            case 1:
                SceneManager.LoadScene("Game");
                break;
            case 4:
                SceneManager.LoadScene("Result");
                break;
            default:
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
        }
    }
}
