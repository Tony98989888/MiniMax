using MiniMax;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MiniMaxUI : MonoBehaviour
{
    [SerializeField]
    InputField m_prompt;

    [SerializeField]
    InputField m_senderType;

    [SerializeField]
    InputField m_message;

    [SerializeField]
    Button m_postButton;

    [SerializeField]
    Text m_responseText;

    MiniMaxData m_data;
    Messages m_msg;

    private void OnEnable()
    {
        m_data = new MiniMaxData();
        m_msg = new Messages();
    }

    private void OnDisable()
    {
        m_data = null;
    }

    private void Start()
    {
        m_prompt.onValueChanged.AddListener(OnPromptValueChanged);
        m_senderType.onValueChanged.AddListener(OnSenderTypeValueChanged);
        m_message.onValueChanged.AddListener(OnMessageValueChanged);
        m_postButton.onClick.AddListener(OnPostButtonClicked);
    }

    private void OnPostButtonClicked()
    {
        
    }

    private void OnMessageValueChanged(string message)
    {
        m_msg.text = message;
        m_data.messages.Clear();
        m_data.messages.Add(m_msg);
    }

    private void OnSenderTypeValueChanged(string senderType)
    {
        m_msg.sender_type = senderType;
        m_data.messages.Clear();
        m_data.messages.Add(m_msg);
    }

    private void OnPromptValueChanged(string prompt)
    {
        m_data.prompt = prompt;
    }
}
