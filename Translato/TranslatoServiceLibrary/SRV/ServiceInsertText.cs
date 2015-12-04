//author: futz
//helpers:
//last_cheked: futz@04.12.2015

using TranslatoServiceLibrary.BLL;
using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.SRV
{
    internal sealed class ServiceInsertText : IServiceInsertText
    {
        public int insertText(Text text)
        {
            CtrText _CtrText = new CtrText();
            return _CtrText.insertText(text);
        }
    }
}
