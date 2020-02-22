using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLite;
using System.Security.Cryptography;


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
        public static Program program;
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
            connectToDB();
        }


        public static SQLiteConnection db;
        static void connectToDB()
        {
            var fullBasePath = Directory.GetCurrentDirectory();
            var musicTrainerPath = fullBasePath.Substring(0, fullBasePath.IndexOf("MusicTrainer")+"MusicTrainer".Length);

            db = new SQLiteConnection(musicTrainerPath+"\\MusicTrainer\\database\\users.db");
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
