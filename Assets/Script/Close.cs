using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Close : MonoBehaviour, IPointerDownHandler
{
    public HowTo Button;
    public GameObject HowToPlay;

    //遊び方ボタン非表示
    public void OnPointerDown(PointerEventData eventData)
    {
        //非表示にすると効果音が再生されないため、開く側のボタンから音を鳴らす
        Button.Close();
        HowToPlay.gameObject.SetActive(false);
    }
}
