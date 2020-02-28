﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLite;
using System.Security.Cryptography;
using System.Media;
using WMPLib;


namespace MusicTrainer
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>


        public static loginScreen loginScreen;
        public static SignUpScreen signUpScreen;
        public static selectionScreen selectionScreen;
        public static keySignatureIdentificationScreen keySignatureIdentificationScreen;
        public static keySignatureConstructionScreen keySignatureConstructionScreen;
        public static perfectPitchScreen perfectPitchScreen;
        public static List<string> notes = new List<string>() { "C3", "D3", "E3", "F3", "G3", "A3", "B3" };
        public static WindowsMediaPlayer notePlayer;
        public static Program program;
        public static int userId;
        //public static Dictionary<string, WindowsMediaPlayer> notePlayers;
        
        

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            initialize();
            Application.Run(loginScreen);

        }
        
        static void initialize()
        {
            loginScreen = new loginScreen();
            program = new Program();
            signUpScreen = new SignUpScreen();
            selectionScreen = new selectionScreen();
            perfectPitchScreen = new perfectPitchScreen();
            keySignatureConstructionScreen = new keySignatureConstructionScreen();
            keySignatureIdentificationScreen = new keySignatureIdentificationScreen();
            notePlayer = new WindowsMediaPlayer();
            connectToDB();
        }

        public static string getNoteFile(string note)
        {
            string noteSoundsPath = getMusicTrainerPath() + "\\MusicTrainer\\noteSounds\\";
            return noteSoundsPath + note + ".wav";
        }

        static string getMusicTrainerPath()
        {
            var fullBasePath = Directory.GetCurrentDirectory();
            var musicTrainerPath = fullBasePath.Substring(0, fullBasePath.IndexOf("MusicTrainer") + "MusicTrainer".Length);
            return musicTrainerPath;
        }

        public static SQLiteConnection db;
        static void connectToDB()
        {
            db = new SQLiteConnection(getMusicTrainerPath()+"\\MusicTrainer\\database\\users.db");
            db.CreateTable<User>();
        }

        static public int AddUserToDB(User user)
        {
            int result = db.Insert(user);
            return result;
        }

        [Table("Users")]
        public class User
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            [Unique]
            public string Email { get; set; }
            [Unique]
            public string Username { get; set; }

            public string Hashed_pw { get; set; }

            public byte[] Salt { get; set; }

            public int PerfectPitchLevel { get; set; }

            public int SignatureIdentificationLevel { get; set; }

            public int SignatureConstructionLevel { get; set; }

        }

        public static byte[] GetSalt(int maxiumumSaltLength = 128/8)
        {
            var salt = new byte[maxiumumSaltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }


    }
}
