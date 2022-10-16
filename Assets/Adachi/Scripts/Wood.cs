using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField]
    [Header("ñÿÇÃÉTÉCÉY")]
    float _size = 1.5f;

    Vector3 _scale = new Vector3(ONE_F, ONE_F, ONE_F);

    const float ONE_F = 1;

    public void BigTree()
    {
        gameObject.transform.localScale = _scale * _size;
    }

    public void SmallTree()
    {
        gameObject.transform.localScale = _scale;
    }
}
