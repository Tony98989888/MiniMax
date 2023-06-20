using MiniMax;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using UnityEngine;

public class MiniMaxManager : MonoBehaviour
{
    private void Start()
    {
        TryPost();
    }

    MiniMaxData GenerateData() 
    {
        var data = new MiniMaxData();
        data.model = "abab5-chat";
        // TODO [Emotion Prediction]
        data.prompt = MiniMaxConst.PROMPT;
        data.SetRoleMeta("��", "Rook");
        data.AppendMessage("USER", "��ã��������ҽ���һ�£�");
        return data;
    }

    async void TryPost()
    {
        HttpClient client = new HttpClient();
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, MiniMaxConst.URL);
        request.Headers.Add("Authorization", MiniMaxConst.APIKEY);
        //        var content = new StringContent(content: @"{
        //    ""model"": ""abab5.5-chat"",
        //    ""tokens_to_generate"": 3000,


        //    ""use_standard_sse"": true,
        //    ""beam_width"": 1,
        //    ""prompt"": ""��˹������xxx"",
        //    ""role_meta"": {
        //        ""bot_name"": ""��˹����"",
        //        ""user_name"": ""С��""
        //    },
        //    ""messages"": [
        //        {
        //            ""sender_type"": ""USER"",
        //            ""text"": ""��10�ֱ�����Ա�д̰������Ϸ�Ĵ���""
        //        }
        //    ]
        //}", null, "application/json");
        var data = GenerateData();
        Debug.Log(data.ToJson());
        var content = new StringContent(data.ToJson(), null, "application/json");
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Debug.Log(await response.Content.ReadAsStringAsync());
    }
}
