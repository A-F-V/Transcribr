using System;

namespace Transcribr
{
    internal class Captions
    {
        public DateTime timeStamp;
        public string content;

        public Captions(string content, DateTime timeStamp)
        {
            this.content = content;
            this.timeStamp = timeStamp;
        }
    }
}