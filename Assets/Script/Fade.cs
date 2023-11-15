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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        if(1 <= GameManager.round && GameManager.round <= 3)
        {
            yield return new WaitForSeconds(2);
        }
        DOTween.To (() => fade, (x) => fade = x, 255, 8).SetEase(Ease.InExpo);
        isfade = true;

        yield return new WaitForSeconds(5);

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
