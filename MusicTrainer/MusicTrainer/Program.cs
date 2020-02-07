using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQLite;


namespace MusicTrainer
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new loginScreen());

            Program p = new Program();
            p.connectToDB();
        }

        SQLiteConnection db;
        public void connectToDB()
        {
            db = new SQLiteConnection("C:\\Users\\Computer\\source\\repos\\MusicTrainer\\database\\users.db");
            db.CreateTable<Message>();
        }

        public int AddMessageToDB(Message cm)
        {
            int result = db.Insert(cm);
            return result;
        }

        public List<Message> getAllMessages()
        {
            List<Message> messages = db.Table<Message>().ToList();
            return messages;
        }

        [Table("Users")]
        public class Message
        {
            [PrimaryKey, AutoIncrement, Column("user_id")]
            public int Id { get; set; }

            public string Hashed_pw { get; set; }

            public string Salt { get; set; }

            public int Score1 { get; set; }

            public int Score2 { get; set; }

            public int Score3 { get; set; }

        }


    }
}
