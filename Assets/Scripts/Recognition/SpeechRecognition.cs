using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class SpeechRecognition : MonoBehaviour
{
    private bool m_micSupport;
    private KeywordRecognizer m_KeywordRecognizer;
    private Dictionary<string, Action> m_actions = new Dictionary<string, Action>();

    [Header("DebugClasses")]
    [SerializeField] private string m_debugVoice;
    [SerializeField] private RawImage m_debugImage;

    // Start is called before the first frame update
    private void Awake()
    {
        if(PhraseRecognitionSystem.isSupported)
        {
            m_micSupport = true;
        }
        else
        {
            m_micSupport = false;
        }
    }

    private void Start()
    {
        m_actions.Add("test", Debugging);
        m_actions.Add("left", Left);
        m_actions.Add("right", Right);
        m_actions.Add("back", Behind);
        m_actions.Add("behind", Behind);

        m_KeywordRecognizer = new KeywordRecognizer(m_actions.Keys.ToArray());
        m_KeywordRecognizer.OnPhraseRecognized += PhraseRecognized;
        m_KeywordRecognizer.Start();

    }

    void PhraseRecognized(PhraseRecognizedEventArgs speech)
    {
        m_debugVoice = speech.text;
        Debug.Log(speech.text);
        m_actions[speech.text].Invoke();
    }

    void Debugging()
    {
        if(m_debugImage.color == Color.white)
        {
            m_debugImage.color = Color.cyan;
        }
        else
        {
            m_debugImage.color = Color.white;
        }
    }

    void Left()
    {
        Debug.Log("AI Look Left");
        HelperAIControls.m_Instance.LookLeft();
    }

    void Right()
    {
        Debug.Log("AI Look Right");
        HelperAIControls.m_Instance.LookRight();
    }

    void Behind()
    {
        Debug.Log("AI Look Behind");
        HelperAIControls.m_Instance.LookBehind();
    }
}
