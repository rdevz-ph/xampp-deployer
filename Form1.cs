using IWshRuntimeLibrary; // Add COM reference manually
using System.Diagnostics;
using System.IO.Compression;
using System.Reflection;
using System.IO;

namespace XamppDeployer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var assembly = Assembly.GetExecutingAssembly();
            using Stream iconStream = assembly.GetManifestResourceStream("WebDeployX.WebDeployX.ico");
            if (iconStream != null)
            {
                this.Icon = new Icon(iconStream);
            }
            else
            {
                MessageBox.Show("Failed to load icon from embedded resources.");
            }

        }

        private void btnDeploy_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ZIP files (*.zip)|*.zip";
            openFileDialog.Title = "Select Web Project ZIP File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string zipFilePath = openFileDialog.FileName;
                string projectName = Path.GetFileNameWithoutExtension(zipFilePath);
                string targetDir = Path.Combine(@"C:\xampp\htdocs\", projectName);

                try
                {
                    if (Directory.Exists(targetDir))
                        Directory.Delete(targetDir, true);

                    using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
                    {
                        int totalEntries = archive.Entries.Count;
                        int count = 0;

                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = totalEntries;
                        progressBar1.Value = 0;
                        lblProgress.Text = "Extracting files...";

                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            string destinationPath = Path.Combine(targetDir, entry.FullName);
                            string directoryPath = Path.GetDirectoryName(destinationPath);

                            if (!string.IsNullOrEmpty(directoryPath))
                                Directory.CreateDirectory(directoryPath);

                            if (!string.IsNullOrEmpty(entry.Name)) // not a folder
                                entry.ExtractToFile(destinationPath, true);

                            count++;
                            progressBar1.Value = count;
                            lblProgress.Text = $"Extracted {count} of {totalEntries}";
                            Application.DoEvents(); // refresh UI
                        }
                    }

                    string chromePath = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
                    string localUrl = $"http://localhost/{projectName}";

                    // Ask user for shortcut name before anything
                    string shortcutName = Microsoft.VisualBasic.Interaction.InputBox(
                        "Enter a name for the desktop shortcut:",
                        "Shortcut Name",
                        projectName // default
                    );

                    if (string.IsNullOrWhiteSpace(shortcutName))
                    {
                        MessageBox.Show("Shortcut creation canceled.");
                        return;
                    }

                    // Create shortcut first
                    CreateDesktopShortcut(shortcutName, chromePath, localUrl);

                    // Then open in Chrome
                    if (System.IO.File.Exists(chromePath))
                    {
                        Process.Start(chromePath, localUrl);
                        MessageBox.Show($"Website launched and shortcut \"{shortcutName}\" created on desktop!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Google Chrome not found.");
                    }


                }
                catch (Exception ex)
                {
                    lblProgress.Text = "Error during extraction.";
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void CreateDesktopShortcut(string name, string chromePath, string url)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string shortcutLocation = Path.Combine(desktop, $"{name}.lnk");

            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
            shortcut.Description = "Open Local Website";
            shortcut.TargetPath = chromePath;
            shortcut.Arguments = url;
            shortcut.Save();
        }
    }
}
