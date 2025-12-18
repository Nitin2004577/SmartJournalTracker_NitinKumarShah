using SQLite;
using smart_journal.Models;  // your AppSettings model

namespace smart_journal.Data
{
    public class AppDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public AppDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<AppSettings>().Wait();
        }

        // Get the single app settings row
        public async Task<AppSettings> GetSettingsAsync()
        {
            return await _database.Table<AppSettings>().FirstOrDefaultAsync();
        }

        // Save or update the app settings
        public async Task SaveSettingsAsync(AppSettings settings)
        {
            await _database.InsertOrReplaceAsync(settings);
        }
    }
}
