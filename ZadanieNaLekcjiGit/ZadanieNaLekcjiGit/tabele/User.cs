﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ZadanieNaLekcjiGit.tabele
{
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Surname {  get; set; }
        public string Login {  get; set; }
        public string Password { get; set; }
        public bool IsTeacher { get; set; }

    }
}
