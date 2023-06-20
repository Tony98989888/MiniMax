using System;
using System.Collections.Generic;
using UnityEngine;

namespace MiniMax
{
    [Serializable]
    public struct RoleMeta
    {
        public string user_name;
        public string bot_name;
        public RoleMeta(string user_name, string bot_name) 
        {
            this.user_name = user_name;
            this.bot_name = bot_name;
        }
    }
    [Serializable]
    public struct Messages
    {
        public string sender_type;
        public string text;

        public Messages(string sender_type, string text) 
        {
            this.sender_type = sender_type;
            this.text = text;
        }
    }
    [Serializable]
    public class MiniMaxData
    {
        public string model;
        public bool with_emotion;
        public bool stream;
        public bool use_standard_sse;
        public int beam_width;
        public string prompt;
        public RoleMeta role_meta;
        public List<Messages> messages;
        public bool continue_last_message;
        public System.Int64 tokens_to_generate;
        public float temperature;
        public float top_p;
        public bool skip_info_mask;

        public MiniMaxData()
        {
            model = "abab5-chat";
            with_emotion = false;
            stream = false;
            use_standard_sse = false;
            beam_width = 1;
            prompt = string.Empty;
            role_meta = new RoleMeta();
            messages = new List<Messages>();
            continue_last_message = false;
            tokens_to_generate = 128;
            temperature = 0.9f;
            top_p = 0.95f;
            skip_info_mask = false;
        }

        public string ToJson() 
        {
            return JsonUtility.ToJson(this);
        }

        public void AppendMessage(string sender_type, string text) 
        {
            var msg = new Messages(sender_type, text);
            messages.Add(msg);
        }

        public void SetRoleMeta(string user_name, string bot_name) 
        {
            role_meta = new RoleMeta(user_name, bot_name);
        }
    }

}
