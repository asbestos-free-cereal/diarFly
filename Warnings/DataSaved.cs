using Avalonia.Controls;

namespace diarFly;

public class DataSaved : RestartWarning
{
    public async void ShowWarning(Window Owner)
    {
        Restart(Owner, "Data Saved", "Data saved.\nThe application will now restart.");
    }
}