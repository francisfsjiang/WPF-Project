using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MyProject
{
    public class TeacherType : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int _teacher_id;
        public string _teacher_name;
        public string _account;
        public string _password;
        public SexType _sex;
        public Boolean _checkd;

        public TeacherType()
        {
            this._teacher_id = -1;
            this._teacher_name = "";
            this._account = "";
            this._password = "";
            this._sex = SexType.male;
            this._checkd = false;
        }
        public TeacherType(int teacher_id, string teacher_name, string account, string password, SexType sex, Boolean checkd)
        {
            this._teacher_id = teacher_id;
            this._teacher_name = teacher_name;
            this._account = account;
            this._password = password;
            this._sex = sex;
            this._checkd = checkd;
        }
        public int teacher_id {
            get
            {
                return _teacher_id;
            }
            set
            {
                _teacher_id = value;
                NotifyPropertyChanged();
            }
        }
        public string teacher_name
        {
            get
            {
                return _teacher_name;
            }
            set
            {
                _teacher_name = value;
                NotifyPropertyChanged();
            }
        }
        public string account
        {
            get
            {
                return _account;
            }
            set
            {
                _account = value;
                NotifyPropertyChanged();
            }
        }
        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }
        //public int? SexId { get; set; }

        public SexType sex 
        {
            get
            {
                return _sex;
            }
            set
            {
                _sex = value;
                NotifyPropertyChanged();
            }
        }

        public Boolean checkd
        {
            get
            {
                return _checkd;
            }
            set
            {
                _checkd = value;
                NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
