using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    [SerializeField]
    Daruma _daruma;

    [SerializeField]
    Text _text;

    [SerializeField]
    string _messege = "‚¾‚é‚Ü‚³‚ñ‚ª‚±‚ë‚ñ‚¾";

    float _coolTime;

    const float TWO_F = 2f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeDarumaMessege()
    {
        StopAllCoroutines();
        StartCoroutine(ChangeMessege());
    }

    IEnumerator ChangeMessege()
    {
        _coolTime = _daruma.AnimLength / _messege.Length / TWO_F * _daruma.TurnSpeed;
        //Debug.Log(Daruma.turnSpeed);
        Debug.Log(_coolTime);
        _text.text = "";
        for (var i = 0; i < _messege.Length; i++)
        {
            _text.text += _messege[i];
            yield return new WaitForSeconds(_coolTime);
        }
        yield return new WaitForSeconds(0.9f);
        _text.text = "";
    }
}
