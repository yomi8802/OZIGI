using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Close : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public HowTo Button;
    public GameObject HowToPlay;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Button.Close();
        HowToPlay.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
