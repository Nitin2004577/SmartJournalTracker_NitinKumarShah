using smart_journal.Models;
using SQLite;

namespace smart_journal.Data
{
    public class AppDatabase
    {
        private SQLiteAsyncConnection _db;

        // The "Init" method ensures the database exists before using it
        private async Task Init()
        {
            if (_db is not null) return;

            // This sets the path to the internal hidden folder of the app
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "journal_v3.db3");

            _db = new SQLiteAsyncConnection(dbPath);

            // This creates the table if it doesn't exist
            await _db.CreateTableAsync<JournalEntry>();
        }

        // 1. CREATE / UPDATE
        public async Task SaveEntryAsync(JournalEntry entry)
        {
            await Init();
            if (entry.Id != 0)
                await _db.UpdateAsync(entry);
            else
                await _db.InsertAsync(entry);
        }

        // 2. READ (Single Entry)
        public async Task<JournalEntry> GetEntryByDateAsync(DateTime date)
        {
            await Init();

            // Calculate the start and end of the target day
            var startOfDay = date.Date;
            var endOfDay = date.Date.AddDays(1);

            // Use simple comparisons that SQLite-net can easily translate to SQL
            return await _db.Table<JournalEntry>()
                            .FirstOrDefaultAsync(x => x.Date >= startOfDay && x.Date < endOfDay);
        }

        // 3. READ (All Entries)
        public async Task<List<JournalEntry>> GetAllEntriesAsync()
        {
            await Init();
            return await _db.Table<JournalEntry>().OrderByDescending(x => x.Date).ToListAsync();
        }

        // 4. DELETE
        public async Task DeleteEntryAsync(DateTime date)
        {
            await Init();
            var entry = await GetEntryByDateAsync(date);
            if (entry != null)
                await _db.DeleteAsync(entry);
        }

        public async Task<List<JournalEntry>> GetEntriesAsync()
        {
            await Init();
            // This fetches all entries from the table and returns them as a list
            return await _db.Table<JournalEntry>().ToListAsync();
        }

        public async Task<int> DeleteEntryAsync(JournalEntry entry)
        {
            return await _db.DeleteAsync(entry);
        }
    }
}