using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Daruma : MonoBehaviour
{
    public float AnimLength => _clip.length;

    public float TurnSpeed => _turnSpeed;

    Animator darumaAnimator;

    [SerializeField]
    AnimationClip _clip;

    [SerializeField]
    ChangeText _changeText;

    float _turnSpeed;

    List<float> turnSpeeds = new List<float>()
    {
        1.8f,
        2.0f,
        2.4f,
        2.8f,
        4f,
    };

    // Start is called before the first frame update
    void Start()
    {
        darumaAnimator = GetComponent<Animator>();
        darumaAnimator.SetFloat("Speed", turnSpeeds[0]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeTurnSpeed()
    {
        _turnSpeed = turnSpeeds[Random.Range(0, turnSpeeds.Count)];
        darumaAnimator.SetFloat("Speed", _turnSpeed);
    }

    public void ChangeMessege()
    {
        _changeText.ChangeDarumaMessege();
    }
}
