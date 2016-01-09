using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;
using System.IO;
using NAudio.Wave;
using CUETools.Codecs;
using CUETools.Codecs.FLAKE;
using Newtonsoft.Json.Linq;

namespace Bot
{
    class Recognition
    {
               // WaveIn - поток для записи
        WaveIn waveIn;
        //Класс для записи в файл
        WaveFileWriter writer;
        //Имя файла для записи
        string outputFilename = "tmp.wav";
        Process process = new Process();
        private int sampleRate = 0;
        public bool recording=false;
        //private float levelPhone;
        //public string result;
        public static string GoogleSpeechRequest(String flacName, int sampleRate)
        {

            WebRequest request = WebRequest.Create("https://www.google.com/speech-api/v2/recognize?output=json&lang=ru-RU&key=AIzaSyCMteuWBLgM87mfC_P8pYtYI9ncJ7TDMOU");

            request.Method = "POST";

            byte[] byteArray = File.ReadAllBytes(flacName);

            // Set the ContentType property of the WebRequest.
            request.ContentType = "audio/x-flac; rate=" + sampleRate; //"16000";        
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);

            dataStream.Close();

            // Get the response.
            WebResponse response = request.GetResponse();

            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }
        public static int Wav2Flac(String wavName, string flacName)
        {
            int sampleRate = 0;
            IAudioSource audioSource = new WAVReader(wavName, null);
            AudioBuffer buff = new AudioBuffer(audioSource, 0x10000);

            FlakeWriter flakewriter = new FlakeWriter(flacName, audioSource.PCM);
            sampleRate = audioSource.PCM.SampleRate;
            FlakeWriter audioDest = flakewriter;
            while (audioSource.Read(buff, -1) != 0)
            {
                audioDest.Write(buff);
            }
            audioDest.Close();

            audioDest.Close();
            audioSource.Close();
            return sampleRate;
        }
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
                    writer.WriteData(e.Buffer, 0, e.BytesRecorded);
        }
        //Завершаем запись
        void StopRecording()
        {
            waveIn.StopRecording();
        }
        //Окончание записи
        private void waveIn_RecordingStopped(object sender, EventArgs e)
        {
                waveIn.Dispose();
                waveIn = null;
                writer.Close();
                writer = null;
        }

        public void startRecord()
        {
            try
            {
                recording = true;
                waveIn = new WaveIn();
                //Дефолтное устройство для записи (если оно имеется)
                //встроенный микрофон ноутбука имеет номер 0
                waveIn.DeviceNumber = 0;
                //Прикрепляем к событию DataAvailable обработчик, возникающий при наличии записываемых данных
                waveIn.DataAvailable += waveIn_DataAvailable;
                //Прикрепляем обработчик завершения записи
                waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped);
                //Формат wav-файла - принимает параметры - частоту дискретизации и количество каналов(здесь mono)
                waveIn.WaveFormat = new WaveFormat(8000, 1);
                //Инициализируем объект WaveFileWriter
                writer = new WaveFileWriter(outputFilename, waveIn.WaveFormat);
                //Начало записи
                waveIn.StartRecording();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void stopRecord()
        {
            if (waveIn != null)
            {
                StopRecording();
                recording = false;
            }

        }

        public string recognition()
        {
            sampleRate = Wav2Flac("tmp.wav", "tmp.flac");
            string answer= GoogleSpeechRequest("tmp.flac", sampleRate);
            string readyAnswer;
            answer=answer.Replace("\n", "");
            answer=answer.Replace("{\"result\":[]}", "");
            try
            {
                JObject answerJObject = JObject.Parse(answer);
                readyAnswer = (string)answerJObject["result"][0]["alternative"][0]["transcript"];
            }
            catch (Exception exception)
            {
                readyAnswer = "";
            }
            return readyAnswer;
            /*
            {"result":[]}{"result":[{"alternative":[{"transcript":"Привет","confidence":0.93204647}],"final":true}],"result_index":0}
            */
        }

        /*private void timerSpeak_Tick(object sender, EventArgs e)
        {
            timerSpeak.Enabled = false;
            recording = false;
        }*/

    }
}
