using System;
using System.Collections.Generic;
using System.Globalization;
using Dash;

namespace Transcribr
{
    internal class CaptionConverter
    {
        internal static void PanoptoRun(PastelConsole pc)
        {
            pc.WriteQuestion("Please insert the time stamps (Contents bar) followed by 'END SLIDES':");
            var slide = GetSlides();
            pc.WriteQuestion("Please insert the captions (Captions bar) followed by 'END CAPTIONS'");
            var captions = GetCaptions();
            String doc = DocumentMaker.FormattedDocumment(slide, captions);

            pc.WriteEmpty();
            pc.WriteStatement("Below is the transcript for the slides:\n");
            pc.WriteLine("START\n");
            pc.WriteLine(doc);
            pc.WriteLine("\nEnd");

        }

        private static List<Slide> GetSlides()
        {
            var output = new List<Slide>();
            var timestamp = DateTime.MinValue;
            var title = "";
            var foundTitle = false;
            while (true)
            {
                var trial = Console.ReadLine();
                if (trial == "END SLIDES")
                    return output;
                if (foundTitle)
                {
                    try
                    {
                        timestamp = DateTime.ParseExact(trial, "m:ss", CultureInfo.InvariantCulture);
                        foundTitle = false;
                        output.Add(new Slide(title, timestamp));
                    }
                    catch (FormatException fe)
                    {
                        try
                        {
                            timestamp = DateTime.ParseExact(trial, "h:mm:ss", CultureInfo.InvariantCulture);
                            foundTitle = false;
                            output.Add(new Slide(title, timestamp));
                        }
                        catch (FormatException f)
                        {
                        }
                    }
                }
                else
                {
                    if (trial != "")
                    {
                        title = trial;
                        foundTitle = true;
                    }
                }
            }
        }

        private static List<Captions> GetCaptions()
        {
            var output = new List<Captions>();
            var timestamp = DateTime.MinValue;
            var content = "";
            var foundTitle = false;
            while (true)
            {
                var trial = Console.ReadLine();
                if (trial == "END CAPTIONS")
                    return output;
                if (foundTitle)
                {
                    try
                    {
                        timestamp = DateTime.ParseExact(trial, "m:ss", CultureInfo.InvariantCulture);
                        foundTitle = false;
                        output.Add(new Captions(content, timestamp));
                    }
                    catch (FormatException fe)
                    {
                        try
                        {
                            timestamp = DateTime.ParseExact(trial, "h:mm:ss", CultureInfo.InvariantCulture);
                            foundTitle = false;
                            output.Add(new Captions(content, timestamp));
                        }
                        catch (FormatException f)
                        {
                        }
                    }
                }
                else
                {
                    if (trial != "")
                    {
                        content = trial;
                        foundTitle = true;
                    }
                }
            }
        }
    }
}