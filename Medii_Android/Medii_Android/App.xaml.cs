using System;
using Medii_Android.Data;
using System.IO;
namespace Medii_Android;

public partial class App : Application
{
    static ProgramariDatabase database;
    public static ProgramariDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               ProgramariDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "ProgramariDB.db3"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
