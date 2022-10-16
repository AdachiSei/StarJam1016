using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int CoolTime => _coolTime;

    public bool IsMoving => _isMoving;

    [SerializeField]
    [Header("����܁i���ʁj")]
    Sprite _dFace;

    [SerializeField]
    [Header("����܁i�w�ʁj")]
    Sprite _dBack;

    [SerializeField]
    [Header("�v���C���[")]
    PlayerController _player;

    [SerializeField]
    [Header("�ŒZ����")]
    int _minTime = 500;

    [SerializeField]
    [Header("�Œ�����")]
    int _maxTime = 5000;

    SpriteRenderer _spriteRenderer;

    int _coolTime;
    bool _isMoving = true;

    const int ONE_SECOND = 1000;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        Attack();
    }

    async void Attack()
    {
        _isMoving = true;
        _coolTime = Random.Range(_minTime, _maxTime);
        UIManager.Instance.ChangeMessege(_coolTime);
        await Task.Delay(_coolTime);
        _spriteRenderer.sprite = _dFace;
        _isMoving = false;
        await Task.Delay(ONE_SECOND);
        _spriteRenderer.sprite = _dBack;
        if (_player.IsGameOver)
        {
            UIManager.Instance.ResetMessege();
            return;
        }
        Attack();
    }
}
