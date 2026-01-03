using SQLite;

namespace smart_journal.Models
{
    public class JournalEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Indexed]
        public DateTime Date { get; set; }

        public string Title { get; set; }

        // This stores the HTML content from the editor
        public string Content { get; set; }

        // Mood System
        public string PrimaryMood { get; set; }
        public string SecondaryMood1 { get; set; }
        public string SecondaryMood2 { get; set; }
        public string MoodCategory { get; set; } // Positive, Neutral, Negative

        public string Category { get; set; } // Work, Health, etc.
        public string Tags { get; set; } // Stored as "Work,Project,Self-care"

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}