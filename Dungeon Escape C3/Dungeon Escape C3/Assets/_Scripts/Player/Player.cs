using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //get ref to rb
    //get ref to playerAnim script
    private Rigidbody2D _rb;
    [SerializeField]
    private float _jumpForce = 5.0f;
    private bool _resetJump = false;
    [SerializeField]
    private bool _isGrounded = false;

    [SerializeField]
    private float _speed = 5.0f;

    private PlayerAnimation _playerAnim;
    private SpriteRenderer _playerSprite;
    private SpriteRenderer _swordSprite;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponent<PlayerAnimation>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _swordSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID
        Movement();
        Attack();
#endif
        
    }
    void Attack()
	{
        if (isGrounded() && Input.GetKeyDown(KeyCode.Mouse0))
            _playerAnim.Attack();
	}
    void FlipSprite(float h)
	{
        if (h < 0f)
		{
            _playerSprite.flipX = true;
            
            _swordSprite.flipX = true;
            _swordSprite.flipY = true;
            
            Vector3 newPos = _swordSprite.transform.localPosition;
            newPos.x = -1.01f;
            _swordSprite.transform.localPosition = newPos;
		}
        else
		{
            _playerSprite.flipX = false;

            _swordSprite.flipX = false;
            _swordSprite.flipY = false;

            Vector3 newPos = _swordSprite.transform.localPosition;
            newPos.x = 1.01f;
            _swordSprite.transform.localPosition = newPos;
        }
	}
    void Movement()
	{
        //GetAxisRaw is either -1,0, or 1; avoids gradual increase/decrease
        //reduces slide in animation from run to idle, etc
        float horizontal = Input.GetAxisRaw("Horizontal");
        _isGrounded = isGrounded();

        FlipSprite(horizontal);

        if(isGrounded() && Input.GetKeyDown(KeyCode.Space))
		{
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpCoroutine());
            _playerAnim.Jumping(true);
		}
        _rb.velocity = new Vector2(horizontal * _speed, _rb.velocity.y);

        _playerAnim.Movement(horizontal);
    }
    bool isGrounded()
	{   //1<<3 layer mask 3

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 3);
        Debug.DrawRay(transform.position, Vector3.down,Color.green);
        if(hitInfo.collider != null)
            if(!_resetJump)
			{
                _playerAnim.Jumping(false);
                return true;
			}

        return false;
	}
    IEnumerator ResetJumpCoroutine()
	{
        _resetJump = true;
        yield return new WaitForSeconds(0.9f);
        _resetJump = false;
	}
    
}
