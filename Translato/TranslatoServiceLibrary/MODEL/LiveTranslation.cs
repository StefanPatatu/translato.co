//author: futz
//helpers:
//last_checked: futz@14.12.2015
//talked about with Alex

using System;
using System.Runtime.Serialization;

namespace TranslatoServiceLibrary.MODEL
{
    [DataContract]
    internal sealed class LiveTranslation
    {
        //private attributes
        private int p_liveTranslationId;
        private DateTimeOffset p_dateCreated;
        private User p_provider;
        private decimal p_pricePerHour;
        private Language p_language1;
        private Language p_language2;
        private Language p_language3;
        private Language p_language4;
        private Language p_language5;
        private DateTimeOffset? p_dateStarted;
        private User p_requester;
        private DateTimeOffset? p_dateEnded;

        //empty constructor
        internal LiveTranslation()
        {

        }

        //full constructor
        internal LiveTranslation(
            int liveTranslationId,
            DateTimeOffset dateCreated,
            User provider,
            decimal pricePerHour,
            Language language1,
            Language language2,
            Language language3,
            Language language4,
            Language language5,
            DateTimeOffset? dateStarted,
            User requester,
            DateTimeOffset? dateEnded
            )
        {
            this.liveTranslationId = liveTranslationId;
            this.dateCreated = dateCreated;
            this.provider = provider;
            this.pricePerHour = pricePerHour;
            this.language1 = language1;
            this.language2 = language2;
            this.language3 = language3;
            this.language4 = language4;
            this.language5 = language5;
            this.dateStarted = dateStarted;
            this.requester = requester;
            this.dateEnded = dateEnded;
        }

        //getters and setters
        [DataMember]
        internal int liveTranslationId
        {
            get { return p_liveTranslationId; }
            set { p_liveTranslationId = value; }
        }
        [DataMember]
        internal DateTimeOffset dateCreated
        {
            get { return p_dateCreated; }
            set { p_dateCreated = value; }
        }
        [DataMember]
        internal User provider
        {
            get { return p_provider; }
            set { p_provider = value; }
        }
        [DataMember]
        internal decimal pricePerHour
        {
            get { return p_pricePerHour; }
            set { p_pricePerHour = value; }
        }
        [DataMember]
        internal Language language1
        {
            get { return p_language1; }
            set { p_language1 = value; }
        }
        [DataMember]
        internal Language language2
        {
            get { return p_language2; }
            set { p_language2 = value; }
        }
        [DataMember]
        internal Language language3
        {
            get { return p_language3; }
            set { p_language3 = value; }
        }
        [DataMember]
        internal Language language4
        {
            get { return p_language4; }
            set { p_language4 = value; }
        }
        [DataMember]
        internal Language language5
        {
            get { return p_language5; }
            set { p_language5 = value; }
        }
        [DataMember]
        internal DateTimeOffset? dateStarted
        {
            get { return p_dateStarted; }
            set { p_dateStarted = value; }
        }
        [DataMember]
        internal User requester
        {
            get { return p_requester; }
            set { p_requester = value; }
        }
        [DataMember]
        internal DateTimeOffset? dateEnded
        {
            get { return p_dateEnded; }
            set { p_dateEnded = value; }
        }
    }
}
