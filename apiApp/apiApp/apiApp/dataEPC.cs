namespace apiApp
{
    public class dataEPC
    {
        public string EPC { get; set; }
        public int Count { get; set; }
        public string Timestamp { get; set; }
        public dataEPC(string epc, int ctn, string timestamp)
        {
            EPC = epc;
            Count = ctn; 
            Timestamp = timestamp;
        }


    }
}
