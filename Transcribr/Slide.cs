using System;

namespace Transcribr
{
    internal class Slide
    {
        public DateTime timeStamp;
        public string header;

        public Slide(string header, DateTime timeStamp)
        {
            this.header = header;
            this.timeStamp = timeStamp;
        }

    }
}