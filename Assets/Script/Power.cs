using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Power : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject body;
    public float power;

    public float add = 1f;
    public AudioClip Charge;

    bool isClick = false;
    bool Clicked = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isClick && !Clicked)
        {
            power += add;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(power == 0)
        {
            isClick = true;
            GetComponent<AudioSource>().PlayOneShot(Charge);
            GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClick = false;
        Clicked = true;
        GetComponent<AudioSource>().Stop();
        GetComponent<SpriteRenderer>().color = new Color32(123,214,64,255);
        body.GetComponent<Bow>().iv = power;
        body.GetComponent<Bow>().bow();
        this.gameObject.SetActive(false);
    }
}
