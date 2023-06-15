using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCtrl : MonoBehaviour
{
    // 이미지 번호
    int imgNum = 1;

    // 카드 뒷면 이미지 번호
    int backNum = 1;

    // 오픈된 카드의 판별여부
    bool isOpen = false;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // 카드 앞면의 이미지를 가지고 온다
    void ShowImage()
    {
        transform.GetComponent<Renderer>().material.mainTexture = Resources.Load("card" + imgNum) as Texture2D;
    }

    // 카드 뒷면 이미지를 가지고 온다
    void HideImage()
    {
        transform.GetComponent<Renderer>().material.mainTexture = Resources.Load("back" + backNum) as Texture2D;
    }
}
