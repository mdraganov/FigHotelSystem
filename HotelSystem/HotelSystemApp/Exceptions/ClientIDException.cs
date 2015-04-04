namespace HotelSystemApp.Exceptions
{
    using System;

    public class ClientIDException : ApplicationException
    {
        private string clientID;

        public ClientIDException(string msg)
            : base(msg)
        {
        }

        public ClientIDException(string msg, string clientID, Exception innerEx)
            : base(msg, innerEx)
        {
            this.clientID = clientID;
        }

        public ClientIDException(string msg, string clientID)
            : this(msg, clientID, null)
        {
        }

        public override string Message
        {
            get
            {
                return "Invalid Client ID " + this.clientID;
            }
        }
    }
}
