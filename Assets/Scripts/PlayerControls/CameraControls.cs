using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    private Camera m_mainCamera;
    [SerializeField] private float m_rotateSpeed = 0.5f;
    [SerializeField] private float m_verticalClamp = 80.0f;
    private float xRot = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        m_mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * m_rotateSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * m_rotateSpeed * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -m_verticalClamp, m_verticalClamp);

        m_mainCamera.transform.localRotation = Quaternion.Euler(xRot, 0.0f, 0.0f);
        m_player.transform.Rotate(m_player.transform.up * mouseX);

        Debug.DrawRay(m_mainCamera.transform.position, m_mainCamera.transform.forward * 3.0f, Color.red);
    }
}
