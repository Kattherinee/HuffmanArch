namespace Huffman
{
    public class Huffman
    {
        public void CompressFile(string dataFilename, string archFilename)
        {
            byte[] data = File.ReadAllBytes(dataFilename);
            byte[] arch = CompressBytes(data);
            File.WriteAllBytes(archFilename, data);
        }

        private byte[] CompressBytes(byte[] data)
        {
            int[] freqs = CalculateFreq(data);
            Node root = CreateHuffmanTree(freqs);
            string[] codes = CreateHuffmanCode(root);
            byte[] bits = Compress(data, codes);
            return data;
        }
         private byte[] Compress(byte[]data, string[] codes)
        {
            List<byte> bits = new List<byte>();
            byte sum = 0;
            byte bit = 1;
            foreach(byte symbol in codes)
                foreach(char c in codes[symbol])
                {
                    if (c == '1') sum |= bit;
                    if (bit < 128) bit <<= 1;
                    {
                        bits.Add(sum);
                        sum = 0;
                        bit = 1;
                    }
       
                }
            if (bit > 1) bits.Add(sum);
            return bits.ToArray();
        }
        private string[] CreateHuffmanCode(Node root) 
        {
            string[] codes = new string[256];
            Next(root, "");
            return codes;

            void Next(Node root, string code)
            {
                if (Node.bit0 == null)
                    codes[Node.symbol] = code;
                else
                {
                    Next(Node.bit0, code + "0");
                    Next(Node.bit1, code + "1");
                }
            }
        }
        private int[] CalculateFreq(byte[] data)
        {
            int[] freqs = new int[256];
            foreach (byte d in data)
                freqs[d]++;
            return freqs;
        }
        private Node CreateHuffmanTree(int[] freqs)
        {
            //Приоритетная очередь:частота+узел(его номер + частотa)
            PriorityQueue <Node> pq = new PriorityQueue<Node>();
            for(int i = 0; i < 256; i++)
            {
                if (freqs[i] > 0)
                    pq.Enqueue(freqs[i], new Node((byte)j, freqs[i]));  
            }
            while(pq.Size > 1)
            {
                Node bit0 = pq.Dequeue();
                Node bit1 = pq.Dequeue();
                int freq = bit0.freq + bit1.freq;
                Node next = new Node(bit0, bit1, freq);
                pq.Enqueue(freq, next);

            }

            return pq.Dequeue();
        }
    }
}
            