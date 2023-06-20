namespace MiniMax 
{
    public struct Choices 
    {
        public string text;
        public System.Int64 index;
        public float logprobes;
        public string finish_reason;
        public string emotion;
        public string delta;
    }

    public struct Usage 
    {
        public System.Int64 total_tokens;
    }

    public struct BaseResp 
    {
        public System.Int64 status_code;
        public string status_msg;
    }

    public class MiniMaxResponseData
    {
        public System.Int64 created;
        public string model;
        public string reply;
        public bool input_sensitive;
        public System.Int64 input_sensitive_type;
        public bool output_sensitive;
        public System.Int64 output_sensitive_type;
        public BaseResp base_resp;
        public Usage usage;
        public Choices choices;
    }
}
