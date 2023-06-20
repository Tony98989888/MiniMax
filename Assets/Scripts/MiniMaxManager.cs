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
        data.SetRoleMeta("我", "Rook");
        data.AppendMessage("USER", "你好，请你自我介绍一下？");
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
        //    ""prompt"": ""古斯塔夫是xxx"",
        //    ""role_meta"": {
        //        ""bot_name"": ""古斯塔夫"",
        //        ""user_name"": ""小明""
        //    },
        //    ""messages"": [
        //        {
        //            ""sender_type"": ""USER"",
        //            ""text"": ""用10种编程语言编写贪吃蛇游戏的代码""
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
