using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperAIControls : MonoBehaviour
{
    public static HelperAIControls m_Instance;
    [SerializeField]private GameObject m_PlayerChar;
    [SerializeField]private GameObject m_AIChar;
    [SerializeField]private float m_TurnSpeed = 0.1f;
    private bool m_inUse;

    [Header("Controls")]
    [SerializeField] private KeyCode m_GoLeft;
    [SerializeField] private KeyCode m_GoBack;
    [SerializeField] private KeyCode m_GoRight;

    private void Awake()
    {
        if (m_Instance == null && m_Instance != this)
        {
            m_Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(m_GoLeft))
        {
            LookLeft();
        }
        if (Input.GetKeyDown(m_GoBack))
        {
            LookRight();
        }
        if (Input.GetKeyDown(m_GoRight))
        {
            LookBehind();
        }
    }

    public void LookLeft()
    {
        StartCoroutine(SlowTurn(m_AIChar.transform.eulerAngles, 270.0f));
    }
    public void LookRight()
    {
        StartCoroutine(SlowTurn(m_AIChar.transform.eulerAngles, 90.0f));
    }
    public void LookBehind()
    {
        StartCoroutine(SlowTurn(m_AIChar.transform.eulerAngles, 180.0f));
    }

    private IEnumerator SlowTurn(Vector3 OriginRot, float TargetVal)
    {
        if (!m_inUse)
        {
            m_inUse = true;
            float timer = 0.0f;

            Vector3 TargetRot = new Vector3(0.0f, TargetVal, 0.0f);

            while (timer < 1.0f)
            {
                Debug.Log("Slow Turn");
                m_AIChar.transform.localEulerAngles = Vector3.Lerp(OriginRot, TargetRot, timer);
                yield return new WaitForEndOfFrame();
                timer += m_TurnSpeed;
            }
            m_inUse = false;
        }
        else
        {
            yield return null;
        }
    }
}
