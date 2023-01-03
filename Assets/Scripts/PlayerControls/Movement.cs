using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float m_SpeedFactor = 1.0f;
    [SerializeField] private float m_JumpFactor = 1.0f;
    private CharacterController m_CharControls;
    private Rigidbody m_Rb;

    // Start is called before the first frame update
    void Awake()
    {
        m_CharControls = this.GetComponent<CharacterController>();
        m_Rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveBackward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.Space)) 
        {
            Jump();
        }
    }

    private void MoveLeft()
    {
        m_CharControls.Move(-this.transform.right * m_SpeedFactor);
    }
    private void MoveRight()
    {
        m_CharControls.Move(this.transform.right * m_SpeedFactor);
    }
    private void MoveForward()
    {
        m_CharControls.Move(this.transform.forward * m_SpeedFactor);
    }
    private void MoveBackward()
    {
        m_CharControls.Move(-this.transform.forward * m_SpeedFactor);
    }
    private void Jump()
    {
        m_Rb.AddForce((this.transform.up * m_JumpFactor), ForceMode.Impulse);
    }
}
