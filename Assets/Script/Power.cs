using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Power : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]GameObject body;
    float power = 0;

    [SerializeField]float add = 1f;
    [SerializeField]AudioClip Charge;

    bool isClick = false;
    bool Clicked = false;

    void FixedUpdate()
    {
        //クリックしている間パワーを貯める
        if(isClick && !Clicked)
        {
            power += add;
        }
    }

    //クリック開始
    public void OnPointerDown(PointerEventData eventData)
    {
        if(power == 0)
        {
            isClick = true;
            GetComponent<AudioSource>().PlayOneShot(Charge);
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    //クリック終了
    public void OnPointerUp(PointerEventData eventData)
    {
        isClick = false;
        Clicked = true;
        GetComponent<AudioSource>().Stop();
        body.GetComponent<Bow>().iv = power; //お辞儀の初速度をパワーに設定
        body.GetComponent<Bow>().bow();
        this.gameObject.SetActive(false);
    }
}
