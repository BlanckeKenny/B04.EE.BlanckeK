using System.Linq;
using Android.Content;
using Android.Speech.Tts;
using Android.Support.V4.App;
using B04.EE.BlanckeK.Interfaces;
using Java.Util;
using Xamarin.Forms;


[assembly:Dependency(typeof(B04.EE.BlanckeK.Droid.Services.DroidTextToSpeach))]
namespace B04.EE.BlanckeK.Droid.Services
{
    public class DroidTextToSpeach  : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech _speaker;
        string _toSpeak;


        public void SpeakOut(string text)
        {
            _toSpeak = text;
            if (_speaker == null)
            {
                _speaker = new TextToSpeech(MainActivity.Instance, this);
                _speaker.SetLanguage(Locale.Default);
            }
            else
            {
                _speaker.Speak(_toSpeak, QueueMode.Flush, null, null);
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                _speaker.Speak(_toSpeak, QueueMode.Flush, null, null);
            }
        }
    }
}