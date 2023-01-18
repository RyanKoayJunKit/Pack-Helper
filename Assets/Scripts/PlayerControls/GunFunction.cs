using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFunction : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float m_FireRate = 1.0f;
    private bool m_Fired = false;
    private Camera m_mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        m_mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(m_Fired)
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        //Fire at enemies. Debug purpose. Hit enemies change color
        RaycastHit hit;
        if(Physics.Raycast(m_mainCamera.transform.position, m_mainCamera.transform.forward, out hit))
        {
            if(hit.collider.tag == "Enemy")
            {
                //change color
                MeshRenderer collidedGO = hit.collider.GetComponent<MeshRenderer>();
                if (collidedGO.material.color == Color.red)
                {
                    collidedGO.material.color = Color.blue;
                }
                else
                {
                    collidedGO.material.color = Color.red;
                }
            }
        }
    }
}
