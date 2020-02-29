using System;
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

        public static LoginScreen loginScreen;
        public static SignUpScreen signUpScreen;
        public static SelectionScreen selectionScreen;
        public static KeySignatureIdentificationScreen keySignatureIdentificationScreen;
        public static KeySignatureConstructionScreen keySignatureConstructionScreen;
        public static PerfectPitchScreen perfectPitchScreen;
        public static List<string> notes = new List<string>() { "C3", "D3", "E3", "F3", "G3", "A3", "B3" };
        public static List<string> signatures = new List<string>() { "F_Major", "C_Major", "G_Major", "D_Major", "A_Major", "E_Major", "B_Major" };
        public static WindowsMediaPlayer notePlayer;
        public static int userId;
        public static SQLiteConnection db;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitializeVariables();
            ConnectToDB();
            Application.Run(loginScreen);
        }
        
        static void InitializeVariables()
        {
            loginScreen = new LoginScreen();
            signUpScreen = new SignUpScreen();
            selectionScreen = new SelectionScreen();
            perfectPitchScreen = new PerfectPitchScreen();
            keySignatureConstructionScreen = new KeySignatureConstructionScreen();
            keySignatureIdentificationScreen = new KeySignatureIdentificationScreen();
            notePlayer = new WindowsMediaPlayer();
        }

        public static string GetNoteFile(string note)
        {
            string noteSoundsPath = GetMusicTrainerPath() + "\\MusicTrainer\\noteSounds\\";
            return noteSoundsPath + note + ".wav";
        }

        public static string GetSignatureFile(string signature)
        {
            string imagesPath = GetMusicTrainerPath() + "\\MusicTrainer\\images\\";
            return imagesPath + signature + ".png";
        }

        static string GetMusicTrainerPath()
        {
            var fullBasePath = Directory.GetCurrentDirectory();
            var musicTrainerPath = fullBasePath.Substring(0, fullBasePath.IndexOf("MusicTrainer") + "MusicTrainer".Length);
            return musicTrainerPath;
        }

        static void ConnectToDB()
        {
            db = new SQLiteConnection(GetMusicTrainerPath()+"\\MusicTrainer\\database\\users.db");
            db.CreateTable<User>();
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
