using MiniMax;
using System;
using System.Net.Http;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MiniMaxUI : MonoBehaviour
{
    [SerializeField]
    InputField m_prompt;

    [SerializeField]
    InputField m_senderType;

    [SerializeField]
    InputField m_message;

    [SerializeField]
    UnityEngine.UI.Button m_postButton;

    [SerializeField]
    Text m_responseText;

    [SerializeField]
    InputField m_userName;

    [SerializeField]
    InputField m_botName;

    MiniMaxData m_data;
    Messages m_msg;
    RoleMeta m_roleMeta;

    private void OnEnable()
    {
        m_data = new MiniMaxData();
        m_msg = new Messages();
        m_roleMeta = new RoleMeta();
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
        m_userName.onValueChanged.AddListener(OnUserNameChanged);
        m_botName.onValueChanged.AddListener(OnBotNameChanged);
    }

    private void OnBotNameChanged(string bot_name)
    {
        m_roleMeta.bot_name = bot_name;
        m_data.role_meta = m_roleMeta;
    }

    private void OnUserNameChanged(string user_name)
    {
        m_roleMeta.user_name = user_name;
        m_data.role_meta = m_roleMeta;
    }

    async void OnPostButtonClicked()
    {
        if (m_data == null) { return; }
        HttpClient client = new HttpClient();
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, MiniMaxConst.URL);
        request.Headers.Add(MiniMaxConst.Authorization, MiniMaxConst.APIKEY);
        var content = new StringContent(m_data.ToJson(), null, "application/json");
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        MiniMaxResponseData responseData = JsonUtility.FromJson<MiniMaxResponseData>(result);
        m_responseText.text = m_responseText.text + "\n" + responseData.reply;
        Debug.Log(responseData.reply);
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
