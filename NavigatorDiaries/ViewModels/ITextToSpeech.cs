using System;
using System.Collections.Generic;
using System.Text;

namespace NavigatorDiaries.Views
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
