using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GaiMobileApp
{
    public class EventDtp : INotifyPropertyChanged
    {
        private string date;
        private int kolvozhertv;
        private string classification;
        private int kolvoYthastnikov;

        public string Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    OnPropertyChanged("date");
                }
            }
        }
        public int KolvoZhertv
        {
            get { return kolvozhertv; }
            set
            {
                if (kolvozhertv != value)
                {
                    kolvozhertv = value;
                    OnPropertyChanged("kolvozhertv");
                }
            }
        }
        public string Classification
        {
            get { return classification; }
            set
            {
                if (classification != value)
                {
                    classification = value;
                    OnPropertyChanged("classification");
                }
            }
        }
        public int KolvoYthastnikov
        {
            get { return kolvoYthastnikov; }
            set
            {
                if (kolvoYthastnikov != value)
                {
                    kolvoYthastnikov = value;
                    OnPropertyChanged("kolvoYthastnikov");
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
