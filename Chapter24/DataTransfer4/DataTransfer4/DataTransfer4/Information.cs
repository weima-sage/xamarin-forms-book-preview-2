﻿using System;

namespace DataTransfer4
{
    public class Information
    {
        public Information()
        {
            Date = DateTime.Today;
        }
        
        public string Name { set; get; }

        public string Email { set; get; }

        public string Language { set; get; }

        public DateTime Date { set; get; }

        public override string ToString()
        {
            return String.Format("{0} / {1} / {2} / {3:d}",
                                 String.IsNullOrWhiteSpace(Name) ? "???" : Name,
                                 String.IsNullOrWhiteSpace(Email) ? "???" : Email,
                                 String.IsNullOrWhiteSpace(Language) ? "???" : Language,
                                 Date);
        }
    }
}
