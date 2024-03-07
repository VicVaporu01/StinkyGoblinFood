using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BtnController : MonoBehaviour
{

    void Start()
    {
        transform.DOScale(1.5f, 0.5f).SetLoops(-1, LoopType.Yoyo);

    }

}
