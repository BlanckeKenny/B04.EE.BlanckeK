using System;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;
using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.UWP.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(UwpTextToSpeech))]

namespace B04.EE.BlanckeK.UWP.Services
{
    public class UwpTextToSpeech : ITextToSpeech
    {
        public async void SpeakOut(string text)
        {
            MediaElement mediaElement = new MediaElement();

            try
            {
                using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
                {
                    var stream = await synthesizer.SynthesizeTextToStreamAsync(text);
                    mediaElement.SetSource(stream, stream.ContentType);
                    mediaElement.Play();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }               
        }
    }
}
