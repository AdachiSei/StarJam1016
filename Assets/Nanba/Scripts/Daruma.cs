using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Daruma : MonoBehaviour
{
    public float AnimLength => _animClip.length;

    public float TurnSpeed => _turnSpeed;

    [SerializeField]
    AnimationClip _animClip;

    [SerializeField]
    ChangeText _changeText;

    Animation _animation;

    float _turnSpeed;

    private void Awake()
    {
        _animation = GetComponent<Animation>();
        _animation.Play();
    }

    //List<float> turnSpeeds = new List<float>()
    //{
    //    1.8f,
    //    2.0f,
    //    2.4f,
    //    2.8f,
    //    4f,
    //};

    //// Start is called before the first frame update
    //void Start()
    //{
    //    _animator = GetComponent<Animator>();
    //    _animator.SetFloat("Speed", turnSpeeds[0]);
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //public void ChangeTurnSpeed()
    //{
    //    _turnSpeed = turnSpeeds[Random.Range(0, turnSpeeds.Count)];
    //    _animator.SetFloat("Speed", _turnSpeed);
    //}

    //public void ChangeMessege()
    //{
    //    _changeText.ChangeDarumaMessege();
    //}
}
