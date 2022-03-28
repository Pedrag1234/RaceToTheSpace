using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_JumpForce = 700f;

    [Range(0,1)] [SerializeField]
    private float m_MoveSmooth = 0.3f;

    [SerializeField]
    private LayerMask m_CollisionLayer;

    [SerializeField]
    private Transform m_CeilingCheck;

    [SerializeField]
    private Transform m_FloorCheck;

    private float m_CheckRadius = 1f;

    private Rigidbody2D m_body;

    [SerializeField]
    private bool m_IsGrounded;

    [SerializeField]
    private Vector3 m_Velocity;

    [SerializeField]
    private bool m_AirControl = true;

    private bool m_facingRight = true;

    [Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

    //Called only at Start
    private void Awake(){

        m_body = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
    }


    //Called at Fixed Intervals
    //Deals with Updating Velocity, Position, etc
    private void FixedUpdate(){
        bool wasGrounded = m_IsGrounded;
        m_IsGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_FloorCheck.position, m_CheckRadius, m_CollisionLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject != gameObject)
            {
                 m_IsGrounded=true;

                if(!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    public void MoveCharacter(float move, bool jump)
    {

       if(m_IsGrounded || m_AirControl)
        {
            Vector3 target = new Vector2(move * 10f, m_body.velocity.y);

            m_body.velocity = Vector3.SmoothDamp(m_body.velocity, target, ref m_Velocity, m_MoveSmooth);
        }
        
       if(jump && m_IsGrounded)
        {
            m_IsGrounded = false;
            m_body.AddForce(new Vector2(0f, m_JumpForce));
        }

        //Add logic to flip sprites here
        if(move > 0 && !m_facingRight)
        {
            FlipSprite();
        }

        if(move < 0 && m_facingRight)
        {
            FlipSprite();
        }
    }

    public bool isGrounded()
    {
        return m_IsGrounded;
    }

    public float getFallSpeed()
    {
        return m_body.velocity.y;
    }


    private void FlipSprite()
    {
        m_facingRight = !m_facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public bool getIsFacingRight()
    {
        return m_facingRight;
    }

}
