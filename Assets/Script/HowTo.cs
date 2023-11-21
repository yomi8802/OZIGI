using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HowTo : MonoBehaviour, IPointerDownHandler
{
    public GameObject HowToPlay;
    public AudioClip open;
    public AudioClip close;

    //遊び方パネル表示
    public void OnPointerDown(PointerEventData eventData)
    {
        GetComponent<AudioSource>().PlayOneShot(open);
        HowToPlay.SetActive(true);
    }

    public void Close()
    {
        GetComponent<AudioSource>().PlayOneShot(close);
    }
}
