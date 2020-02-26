using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace UI
{
    using System.IO;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var wnd = new MainWindow();
            wnd.Show();

            if (e.Args.Length == 1)
            {
                wnd.StartWatching(e.Args[0]);
            }
            else
            {
                if (IsValidGitRepository(Environment.CurrentDirectory))
                {
                    wnd.StartWatching(Environment.CurrentDirectory);
                }
            }
        }

        static Boolean IsBareGitRepository(String path) 
        {
            String configFileForBareRepository = Path.Combine(path, "config"); 
            return File.Exists(configFileForBareRepository) &&
                  Regex.IsMatch(File.ReadAllText(configFileForBareRepository), @"bare\s*=\s*true", RegexOptions.IgnoreCase);
        }

        static bool IsValidGitRepository(string path)
        {
            return !string.IsNullOrEmpty(path)
                && Directory.Exists(path)
                && (Directory.Exists(Path.Combine(path, ".git")) ||
                 IsBareGitRepository(path));
        }
    }
}
