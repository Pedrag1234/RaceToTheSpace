using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_JumpForce = 700f;

    [Range(0,1)] [SerializeField]
    private float m_MoveSmooth = 0.3f;

    [SerializeField]
    private float gravity = -9.8f;

    [SerializeField]
    private LayerMask m_CollisionLayer;

    [SerializeField]
    private Transform m_CeilingCheck;

    [SerializeField]
    private Transform m_FloorCheck;

    private float m_CheckRadius = 1f;

    private RigidBody2D body;

    [SerializeField]
    private Vector3 m_Velocity;

    [SerializeField]
    private bool isGrounded;

    [Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

    //Called only at Start
    private void Awake(){

        body = GetComponent<RigidBody2D>();

        if (OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
    }

    //Called when available
    //Deals with player inputs
    private void Update()
    {
        
    }

    //Called at Fixed Intervals
    //Deals with Updating Velocity, Position, etc
    private void FixedUpdate(){

    }

    

}
