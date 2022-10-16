using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsGameOver => _isGameOver;

    [SerializeField]
    [Header("�X�s�[�h")]
    float _speed = 5;

    [SerializeField]
    [Header("�����Ă���C���X�g")]
    Sprite _run;

    [SerializeField]
    [Header("�����Ă���")]
    Sprite _wark;

    [SerializeField]
    [Header("�����Ă���C���X�g")]
    Sprite _stand;

    [SerializeField]
    [Header("�����")]
    Enemy _enemy;

    Rigidbody2D _rb;
    SpriteRenderer _spriteRenderer;
    bool _isHide;
    bool _Move;
    bool _isGameOver;

    const float ONE_F = 1f;
    const float TEN_F = 10f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!_isGameOver)
        {
            OnMove();
            ChangeSprite();

            _Move = _rb.velocity.x != 0f || _rb.velocity.y != 0f;

            if (_Move && !_enemy.IsMoving && !_isHide)//�����Ă��違�����Ă͂����Ȃ����B��Ă��Ȃ�
            {
                _isGameOver = true;
                GameOver();
            }
        }
        else
        {
            TimeManager.Instance.StopTimer();
            _rb.velocity = Vector2.zero;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {    
        if(collision.TryGetComponent(out Wood wood))
        {
            wood.BigTree();
            SoundManager.Instance.PlaySFX(SFXType.Hide);
            _spriteRenderer.sprite = _stand;
            _isHide = true;
        }
        else if(collision.TryGetComponent(out Enemy daruma))
        {
            SoundManager.Instance.PlaySFX(SFXType.Tatch);
            SoundManager.Instance.PlayBGM(BGMType.Clear);
            Debug.Log("Clear");
            _isGameOver = true;
            _rb.velocity = Vector2.zero;
            TimeManager.Instance.StopTimer();
            UIManager.Instance.ClearTime();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Wood wood))
        {
            wood.SmallTree();
            _isHide = false;
        }
    }

    void OnMove()
    {

        if(Input.GetButton("Left") & Input.GetButton("Right"))
        {
            _rb.velocity = Vector2.zero;
        }
        else if (Input.GetButton("Left"))
        {
            _rb.velocity = new Vector2(ONE_F, TEN_F).normalized * _speed;
        }
        else if (Input.GetButton("Right"))
        {
            _rb.velocity = new Vector2(ONE_F, -TEN_F).normalized * _speed;
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }

    void ChangeSprite()
    {
        if(_isHide)//�B��Ă���
        {
            _spriteRenderer.sprite = _wark;
        }
        else if (_Move)//�����Ă��違�B��Ă��Ȃ�
        {
            _spriteRenderer.sprite = _run;
        }
        else if(!_Move)//�����Ă��Ȃ�������
        {
            _spriteRenderer.sprite = _stand;
        }
    }

    void GameOver()
    {
        Debug.Log("GameOver");
        SoundManager.Instance.PlaySFX(SFXType.Look);
        SoundManager.Instance.PlayBGM(BGMType.GameOver);
        UIManager.Instance.GameOver();
    }
}
