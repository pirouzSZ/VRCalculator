using System;
using AVFoundation;
using Foundation;
using Speech;
using VRCalculator.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(SpeechToTextImplementation))]
namespace VRCalculator.iOS
{
    public class SpeechToTextImplementation : ISpeechToText
    {
        public event EventHandler<EventArgsVoiceRecognition> textChanged;

        private AVAudioEngine AudioEngine = new AVAudioEngine();
        private SFSpeechRecognizer SpeechRecognizer = new SFSpeechRecognizer();
        private SFSpeechAudioBufferRecognitionRequest LiveSpeechRequest = new SFSpeechAudioBufferRecognitionRequest();
        private SFSpeechRecognitionTask RecognitionTask;


        public void InitializeProperties()
        {
            AudioEngine = new AVAudioEngine();
            SpeechRecognizer = new SFSpeechRecognizer();
            LiveSpeechRequest = new SFSpeechAudioBufferRecognitionRequest();
        }

        public void Start()
        {
            InitializeProperties();
            StartRecordingSession();
        }
        public void Stop()
        {
            CancelRecording();
        }
        public void StartRecordingSession()
        {
            // Start recording
            AudioEngine.InputNode.InstallTapOnBus(bus: 0, bufferSize: 1024,
                                                  format: AudioEngine.InputNode.GetBusOutputFormat(0),
                                                  tapBlock: (buffer, when) => LiveSpeechRequest?.Append(buffer));
            AudioEngine.Prepare();

            NSError error;
            AudioEngine.StartAndReturnError(out error);

            if (error != null)
            {

                return;
            }

            try
            {
                CheckAndStartReconition();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void CheckAndStartReconition()
        {
            if (RecognitionTask?.State == SFSpeechRecognitionTaskState.Running)
            {
                CancelRecording();
            }
            StartVoiceRecognition();
        }
        public void StartVoiceRecognition()
        {
            RecognitionTask = SpeechRecognizer.GetRecognitionTask(LiveSpeechRequest, (SFSpeechRecognitionResult result, NSError err) =>
            {
                if (result == null)
                {
                    CancelRecording();
                    return;
                }

                if (err != null)
                {
                    CancelRecording();
                    return;
                }

                if (result != null && result.BestTranscription != null && result.BestTranscription.FormattedString != null)
                {
                    TextChanged(result.BestTranscription.FormattedString);
                }
                if (result.Final)
                {
                    TextChanged(result.BestTranscription.FormattedString, true);
                    CancelRecording();
                    return;
                }
            });
        }
        public void StopRecording()
        {
            AudioEngine?.Stop();
            LiveSpeechRequest?.EndAudio();
        }

        public void CancelRecording()
        {
            AudioEngine?.Stop();
            RecognitionTask?.Cancel();
        }
        public void TextChanged(string text, bool isFinal = false)
        {
            textChanged?.Invoke(this, new EventArgsVoiceRecognition(text, isFinal));
        }


    }
}
