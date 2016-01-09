using System.Speech.Synthesis;

namespace Bot
{
    class Synthesizer
    {
        public void Synthes(string textToSpeech)
        {
            SpeechSynthesizer ss = new SpeechSynthesizer();
            var voiceList = ss.GetInstalledVoices();
            ss.SelectVoice(voiceList[2].VoiceInfo.Name); //[0,1] - std english synthesizers, [2] - Nikolay
            ss.Volume = 100; // от 0 до 100
            ss.Rate = 0; //от -10 до 10
            ss.SpeakAsync(textToSpeech);
        }
    }
}
