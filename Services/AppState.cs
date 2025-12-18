using System;

namespace smart_journal.Services
{
    public class AppState
    {
        private bool isUnlocked = false;
        private bool isDarkMode = false;

        public bool IsUnlocked
        {
            get => isUnlocked;
            private set
            {
                isUnlocked = value;
                NotifyStateChanged();
            }
        }

        public bool IsDarkMode
        {
            get => isDarkMode;
            set
            {
                if (isDarkMode != value)
                {
                    isDarkMode = value;
                    NotifyStateChanged();
                }
            }
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void Unlock() => IsUnlocked = true;
        public void Lock() => IsUnlocked = false;

        public void ToggleTheme() => IsDarkMode = !IsDarkMode;
    }
}
