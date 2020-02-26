using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLite;
using System.Security.Cryptography;
using System.Media;


namespace MusicTrainer
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>


        public static Form loginScreen;
        public static Form signUpScreen;
        public static Form selectionScreen;
        public static Form keySignatureIdentificationScreen;
        public static Form keySignatureConstructionScreen;
        public static Form perfectPitchScreen;
        public static Program program;
        public static Dictionary<string, SoundPlayer> tonePlayers;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            initialize();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
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


            tonePlayers = new Dictionary<string, SoundPlayer>();
            string noteSoundsPath = getMusicTrainerPath() + "\\MusicTrainer\\noteSounds\\";
            tonePlayers.Add("C3", new SoundPlayer(noteSoundsPath + "C3.wav"));
            tonePlayers.Add("D3", new SoundPlayer(noteSoundsPath + "D3.wav"));
            tonePlayers.Add("E3", new SoundPlayer(noteSoundsPath + "E3.wav"));
            tonePlayers.Add("F3", new SoundPlayer(noteSoundsPath + "F3.wav"));
            tonePlayers.Add("G3", new SoundPlayer(noteSoundsPath + "G3.wav"));
            tonePlayers.Add("A3", new SoundPlayer(noteSoundsPath + "A3.wav"));
            tonePlayers.Add("B3", new SoundPlayer(noteSoundsPath + "B3.wav"));
            
            //SoundPlayer s = new SoundPlayer(@"C:\Users\Bruger\Documents\GitHub\MusicTrainer\MusicTrainer\noteSounds\C3.wav");
            //s.Play();


            connectToDB();
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

            public int Score1 { get; set; }

            public int Score2 { get; set; }

            public int Score3 { get; set; }

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
