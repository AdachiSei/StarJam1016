using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    [Header("スピード")]
    float _speed = 5;

    Rigidbody2D _rb;
    bool _isHide;

    const float ONE_F = 1f;
    const float Three_F = 3f;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        OnMove();
        bool dontMove = _rb.velocity.x > 0f || _rb.velocity.y > 0f;
        if(dontMove && false && !_isHide)
        {
            GameOver();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.TryGetComponent(out Wood wood))
        {
            wood.BigTree();
            _isHide = true;
        }
        else if(collision.TryGetComponent(out SpriteRenderer sprite))
        {
            Debug.Log("Clear");
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
        if (Input.GetButton("Left"))
        {
            Debug.Log("Left");
            _rb.velocity = new Vector2(ONE_F, Three_F).normalized * _speed;
        }
        else if (Input.GetButton("Right"))
        {
            Debug.Log("Right");
            _rb.velocity = new Vector2(ONE_F, -Three_F).normalized * _speed;
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }
    }

    void GameOver()
    {
        Debug.Log("GameOver");
    }
}
