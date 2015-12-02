//author: adrian
//helpers:
//last_checked: futz@20.11.2015

using TranslatoServiceLibrary.MODEL;

namespace TranslatoServiceLibrary.DAL
{
    public interface ISubmissions
    {
        int insertSubmission(Submission submission);
    }
}
