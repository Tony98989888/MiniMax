using System.Collections.Generic;

public struct role_meta 
{
    public string user_name;
    public string bot_name;
}

public struct messages 
{
    public string sender_type;
    public string text;
}

public class MiniMaxData
{
    public string model;
    public bool with_emotion;
    public bool stream;
    public bool use_standard_sse;
    public int beam_width;
    public string prompt;
    public role_meta role_meta;
    public List<messages> messages;
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
        role_meta = new role_meta();
        messages = new List<messages>();
        continue_last_message = false;
        tokens_to_generate = 128;
        temperature = 0.9f;
        top_p = 0.95f;
        skip_info_mask = false;
    }
}
