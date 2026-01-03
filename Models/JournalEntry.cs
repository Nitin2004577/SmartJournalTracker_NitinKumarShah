using SQLite;

namespace smart_journal.Models
{
    public class JournalEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public DateTime Date { get; set; } // The user-selected date for the entry

        public string Title { get; set; }

        public string Content { get; set; }

        public string Mood { get; set; } // "Happy", "Sad", "Neutral", etc.

        // ERD Best Practice: Audit fields
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}