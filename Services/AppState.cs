using System;

namespace smart_journal.Services
{
    public class AppState
    {
        private bool isUnlocked = false;

        public bool IsUnlocked
        {
            get => isUnlocked;
            private set
            {
                isUnlocked = value;
                NotifyStateChanged();
            }
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void Unlock() => IsUnlocked = true;

        public void Lock() => IsUnlocked = false;
    }
}
