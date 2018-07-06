using System;

using Xamarin.Forms;

namespace VRCalculator
{
	public interface ISpeechToText
	{
		void Start ();
		void Stop ();
		event EventHandler<EventArgsVoiceRecognition> textChanged;
	}
}

