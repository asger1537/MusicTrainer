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
        public static LoginScreen loginScreen;
        public static SignUpScreen signUpScreen;
        public static SelectionScreen selectionScreen;
        public static KeySignatureIdentificationScreen keySignatureIdentificationScreen;
        public static KeySignatureConstructionScreen keySignatureConstructionScreen;
        public static PerfectPitchScreen perfectPitchScreen;
        public static List<string> notes = new List<string>() { "C3", "D3", "E3", "F3", "G3", "A3", "B3" };
        public static WindowsMediaPlayer notePlayer;
        public static int userId;
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginScreen = new LoginScreen();
            signUpScreen = new SignUpScreen();
            selectionScreen = new SelectionScreen();
            perfectPitchScreen = new PerfectPitchScreen();
            keySignatureConstructionScreen = new KeySignatureConstructionScreen();
            keySignatureIdentificationScreen = new KeySignatureIdentificationScreen();
            notePlayer = new WindowsMediaPlayer();
            ConnectToDB();
            Application.Run(loginScreen);

        }
        
        public static string GetNoteFile(string note)
        {
            string noteSoundsPath = GetMusicTrainerPath() + "\\MusicTrainer\\noteSounds\\";
            return noteSoundsPath + note + ".wav";
        }

        static string GetMusicTrainerPath()
        {
            var fullBasePath = Directory.GetCurrentDirectory();
            var musicTrainerPath = fullBasePath.Substring(0, fullBasePath.IndexOf("MusicTrainer") + "MusicTrainer".Length);
            return musicTrainerPath;
        }

        public static SQLiteConnection DB;
        static void ConnectToDB()
        {
            DB = new SQLiteConnection(GetMusicTrainerPath() + "\\MusicTrainer\\database\\users.db");
            DB.CreateTable<User>();
        }

        static public int AddUserToDB(User user)
        {
            int result = DB.Insert(user);
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
