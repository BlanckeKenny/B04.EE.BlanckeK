using System;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using B04.EE.BlanckeK.Interfaces;
using B04.EE.BlanckeK.UWP.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(UwpTextToSpeech))]

namespace B04.EE.BlanckeK.UWP.Services
{
    public class UwpTextToSpeech : ITextToSpeech
    {
        public async void Speak(string text)
        {
            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                synthesizer.Options.IncludeWordBoundaryMetadata = true;
                synthesizer.Options.IncludeSentenceBoundaryMetadata = true;
                MediaElement mediaElement = new MediaElement();
                var stream = await synthesizer.SynthesizeTextToStreamAsync(text);
                
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play();
            }
                
            
            


                
        }
    }
}
