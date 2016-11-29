using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace RODHE.Tools
{
     public class Email
    {
        private string _html;
        private string _to;
        private string _from;
        private string _subject;
        private string _host;
        private string _user;
        private string _password;
        private int _timeout;
        private int _port;
        private bool _enableSsl;

        public string Html
        {
            get { return _html; }
            set { _html = value; }
        }
        public string To
        {
            get { return _to; }
            set { _to = value; }
        }
        public string From
        {
            get { return _from; }
            set { _from = value; }
        }
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public int TimeOut
        {
            get { return _timeout; }
            set { _timeout = value; }
        }
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }
        public bool EnableSsl
        {
            get { return _enableSsl; }
            set { _enableSsl = value; }
        }


    }
}

