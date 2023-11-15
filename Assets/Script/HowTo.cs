using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HowTo : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject HowToPlay;
    public AudioClip open;
    public AudioClip close;
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
        GetComponent<AudioSource>().PlayOneShot(open);
        HowToPlay.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
    public void Close()
    {
        GetComponent<AudioSource>().PlayOneShot(close);
    }
}
