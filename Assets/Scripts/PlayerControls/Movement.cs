using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private GameObject m_Player;

    [SerializeField] private float m_SpeedFactor = 1.0f;
    [SerializeField] private float m_JumpFactor = 1.0f;
    private Transform m_Transform;
    private Rigidbody m_Rb;
    [Header("JumpFactors")]
    [SerializeField] private bool m_Jumped;
    [SerializeField] private float m_LandDetectRange;
    private RaycastHit m_FloorHit;
    [SerializeField] private LayerMask m_FloorLayer;
    [Header("Controls")]
    [SerializeField] private KeyCode ForwardKey;
    [SerializeField] private KeyCode BackwardKey;
    [SerializeField] private KeyCode LeftKey;
    [SerializeField] private KeyCode RightKey;
    [SerializeField] private KeyCode JumpKey;

    // Start is called before the first frame update
    void Awake()
    {
        m_Transform = m_Player.transform;
        m_Rb = m_Player.GetComponent<Rigidbody>();
        StartCoroutine("LookForLand");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(ForwardKey))
        {
            MoveForward();
        }
        if (Input.GetKey(BackwardKey))
        {
            MoveBackward();
        }
        if (Input.GetKey(LeftKey))
        {
            MoveLeft();
        }
        if (Input.GetKey(RightKey))
        {
            MoveRight();
        }
        if (Input.GetKeyDown(JumpKey))
        {
            if (!m_Jumped)
            {
                Jump();
            }
        }
    }

    private void MoveLeft()
    {
        m_Transform.position -= m_Transform.right * m_SpeedFactor;
    }
    private void MoveRight()
    {
        m_Transform.position += m_Transform.right * m_SpeedFactor;
    }
    private void MoveForward()
    {
        m_Transform.position += m_Transform.forward * m_SpeedFactor;
    }
    private void MoveBackward()
    {
        m_Transform.position -= m_Transform.forward * m_SpeedFactor;
    }
    private void Jump()
    {
        m_Rb.AddForce(m_Transform.up * m_JumpFactor, ForceMode.Impulse);
        m_Jumped = true;
    }
    private IEnumerator LookForLand()
    {
        while (true)
        {
            //if hits collider, reset jump
            if (Physics.Raycast(m_Transform.position, -m_Transform.up, m_LandDetectRange, m_FloorLayer))
            {
                m_Jumped = false;
            }
            else
            {
                m_Jumped = true;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
