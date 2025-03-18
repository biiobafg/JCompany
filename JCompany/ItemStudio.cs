using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using James_Company;
using JCompany.Model;
using JCompany.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
namespace JCompany
{
    public partial class ItemStudio : Form
    {
        public static ItemStudio instance;
        public ItemStudio()
        {
            instance = this;
            InitializeComponent();
        }

        private void btn_setUnturnedDir(object sender, EventArgs e)
        {
            using FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string pathToSet = dialog.SelectedPath;
                if (string.IsNullOrEmpty(pathToSet))
                {
                    MessageBox.Show("Invalid unturned directory!");
                    return;
                }
                bool unturnedExists = File.Exists(Path.Combine(pathToSet, "Unturned.exe"));
                if (!unturnedExists)
                {
                    MessageBox.Show("Missing Unturned.exe");
                    return;
                }

                Settings.Default.UnturnedDir = pathToSet;
                Settings.Default.Save();
            }
        }

        string unturnedDir => Settings.Default.UnturnedDir;
        string Icons => Path.Combine(unturnedDir, "Extras", "Icons");
        private string? _cacheThatShit;
        public string Workshop
        {
            get
            {
                if (string.IsNullOrEmpty(_cacheThatShit))
                {
                    DirectoryInfo inf = new(unturnedDir);
                    // this SHOULD bring it to steamapps
                    DirectoryInfo? trg = inf?.Parent?.Parent;
                    _cacheThatShit = Path.Combine(trg!.FullName, "workshop", "content", "304930");
                }
                return _cacheThatShit;
            }
        }


        void Show(string str) => MessageBox.Show(str, "ERR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        void ShowSetDir() => Show("Set unturned directory first!");

        private void btn_openWrkshop(object sender, EventArgs e)
        {
            if (!Directory.Exists(unturnedDir))
            {
                ShowSetDir();
                return;
            }


            if (!Directory.Exists(Workshop))
            {
                ShowSetDir();
            }
            else
            {
                OpenExporer(Workshop);
            }
        }

        private void btn_openIcons(object sender, EventArgs e)
        {
            if (!Directory.Exists(Icons))
            {
                ShowSetDir();
            }
            else
            {
                OpenExporer(Icons);
            }
        }

        private void btn_openUnturnedDir(object sender, EventArgs e)
        {
            if (!Directory.Exists(unturnedDir))
            {
                ShowSetDir();
            }
            else
            {
                OpenExporer(unturnedDir);
            }
        }


        private void OpenExporer(string args)
        {
            if (string.IsNullOrEmpty(args))
                return;
            ProcessStartInfo info = new();
            {
                info.Arguments = args;
                info.FileName = "explorer.exe";
            }
            Process.Start(info);
        }

        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Extractor.ExtractAll(dialog.SelectedPath, false);
            }
        }

        private void loadFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Extractor.ExtractAll(dialog.SelectedPath, true);
            }

        }

        public void AskClearList()
        {
            lv_Items.Items.Clear();
            txt_datEditor.Text = "";
            txt_engEditor.Text = "";
            pxb_ItemIcon.ImageLocation = "";
        }
        public HashSet<string> CanBeFiltered = new();
        internal void AskUpdateList(List<Model.Item> _items)
        {
            AskClearList();

            foreach (var item in _items)
            {
                ListViewItem item2 = new ListViewItem(item.Id);
                item2.SubItems.Add(item.Type);
                item2.SubItems.Add(item.Name);
                if (item.Overlap != null)
                    item2.BackColor = Color.Red;
                item2.Tag = item.DatPath;
                lv_Items.Items.Add(item2);
            }
        }
        private ListViewItem _active;
        private Item _activeItem;
        private void lv_Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (changing)
                return;
            if (lv_Items.SelectedItems.Count > 0)
            {
                ListViewItem selected = lv_Items.SelectedItems[0];

                // now i should really add something here to prompt the user guy to save the file if they havent saved it already,
                // but that's on them if they fuck up lolz

                Item Match = Extractor.Getitem(selected.Text, selected.SubItems[1].Text, selected.SubItems[2].Text, selected.Tag);
                if (Match != null)
                {
                    _active = selected;
                    _activeItem = Match;

                    ChangeText(Match);
                    ChangeIcon(Match);
                }
            }
        }

        string getIcon(Item match)
        {
            string Iconname = $"{match?.Name.Replace(" ", "_")}_{match?.Id}";
            if (string.IsNullOrEmpty(Iconname))
                return null;

            string file = Path.Combine(Icons, Iconname);
            if (File.Exists(file))
            {
                return file;
            }
            else
            {
                string loneName = Path.GetFileName(match.DatPath);

                file = Icons + "\\" + loneName.Replace(".dat", "").Trim() + $"_{match.Id}" + ".png";
                if (File.Exists(file))
                {
                    return file;
                }
                else
                {
                    return null;
                }
            }
        }
        private void ChangeIcon(Item match)
        {
            pxb_ItemIcon.ImageLocation = null;
            string Iconname = $"{match?.Name.Replace(" ", "_")}_{match?.Id}";
            if (string.IsNullOrEmpty(Iconname))
                return;

            string file = Path.Combine(Icons, Iconname);
            if (File.Exists(file))
            {
                pxb_ItemIcon.ImageLocation = file;
                txt_iconLocation.Text = file;
            }
            else
            {
                string loneName = Path.GetFileName(match.DatPath);

                file = Icons + "\\" + loneName.Replace(".dat", "").Trim() + $"_{match.Id}" + ".png";
                if (File.Exists(file))
                {
                    pxb_ItemIcon.ImageLocation = file;
                    txt_iconLocation.Text = file;
                }
                else
                {
                    txt_iconLocation.Text = "Icon not found, Try regenerating https://unturned.info/Modding/ItemIcons/";
                }
            }
        }

        bool changing = false;
        private void ChangeText(Item match)
        {
            changing = true;
            txt_datEditor.Text = File.ReadAllText(match.DatPath).Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
            try
            {
                txt_engEditor.Text = match.EngPath != null ? File.ReadAllText(match.EngPath).Replace("\r\n", "\n").Replace("\n", Environment.NewLine) : "No English.dat available";

            }
            catch (FileNotFoundException)
            {
                txt_engEditor.Text = "No English.dat available";
            }

            UpdateComments();





            changing = false;
        }



        private void UpdateComments()
        {

            if (!btn_AutoComment.Checked)

                return;
            txt_datEditor.ReadOnly = true;

            string input = txt_datEditor.Text;

            string js = input.AddComments(_activeItem);


            txt_datEditor.Text = js;


            txt_datEditor.ReadOnly = false;

        }






        private void txt_datEditor_TextChanged(object sender, EventArgs e)
        {
            if (changing)
            {
                return;
            }
            if (_active == null || _activeItem == null)
            {
                return;
            }

            string currentText = File.ReadAllText(_activeItem.DatPath);
            if (string.IsNullOrEmpty(currentText))
                return;
            if (currentText == txt_datEditor.Text)
            {
                _active.Font = new Font(_active.Font, FontStyle.Regular);

                _activeItem.Modified = false;

                return;
            }

            _active.Font = new Font(_active.Font, FontStyle.Italic | FontStyle.Bold);
            _activeItem.Modified = true;
        }




        private void btn_OpenLocation_Click(object sender, EventArgs e)
        {
            if (_active == null && _activeItem == null)
            {
                txt_Msg.Text = "No item selected!";
                return;
            }
            else
            {
                OpenExporer(Directory.GetParent(_activeItem.DatPath)?.FullName);
            }
        }

        private void btn_OpenIconLocation_Click(object sender, EventArgs e)
        {
            if (_active == null && _activeItem == null)
            {
                txt_Msg.Text = "No item selected!";
                return;
            }
            else
            {
                string iconPath = getIcon(_activeItem);
                if (string.IsNullOrEmpty(iconPath))
                {
                    txt_Msg.Text = "No icon found!!";
                    return;

                }
                Process.Start("explorer.exe", $"/select,\"{iconPath}\"");
            }
        }

        private int columnToSort = -1;

        private SortOrder sortOrder = SortOrder.Ascending;




        private void lv_Items_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            sortOrder = e.Column == columnToSort ? sortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending : SortOrder.Ascending;

            columnToSort = e.Column;
            lv_Items.ListViewItemSorter = new ListViewItemComparer(e.Column, sortOrder);
        }

        private void txt_datEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                e.SuppressKeyPress = true;
                SaveActive();
            }
        }

        private void SaveActive()
        {
            if (_active == null && _activeItem == null)
            {
                txt_Msg.Text = "No item selected!";
                return;
            }
            string datScreen = txt_datEditor.Text;
            string engScreen = txt_engEditor.Text;

            File.WriteAllText(_activeItem.DatPath, datScreen.RemoveComments());
            File.WriteAllText(_activeItem.EngPath, engScreen);

            SetNotModified();
            UpdateComments();

            txt_Msg.Text = "Saved!!";
        }



        private void SetNotModified()
        {
            _active.Font = new Font(_active.Font, FontStyle.Regular);
            _activeItem.Modified = false;
        }

        private void loadVanillaItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(unturnedDir))
            {
                ShowSetDir();
            }
            else
            {
                Extractor.ExtractAll(Path.Combine(unturnedDir, "Bundles", "Items"), false);
            }
        }

        private void reloadAllAssetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AskClearList();
            txt_datEditor.Text = "";
            txt_engEditor.Text = "";

            AskUpdateList(Extractor._items);
        }
        private HashSet<string> activeFilters = new HashSet<string>();

        private void txt_SearchBox_TextChanged(object sender, EventArgs e)
        {
            lv_Items.Items.Clear();

            string searchText = txt_SearchBox.Text.ToLower();
            IEnumerable<Item> filtered = Extractor._items.Where(item =>
                (string.IsNullOrEmpty(searchText) ||
                 item.Id.ToLower().Contains(searchText) ||
                 item.Type.ToLower().Contains(searchText) ||
                 item.Name.ToLower().Contains(searchText)) &&
                (activeFilters.Count == 0 || activeFilters.Contains(item.Type)));

            foreach (Item item in filtered)
            {
                ListViewItem item2 = new ListViewItem(item.Id);
                item2.SubItems.Add(item.Type);
                item2.SubItems.Add(item.Name);

                if (item.Overlap != null)
                {
                    item2.BackColor = Color.Red;
                }
                item2.Tag = item.DatPath;
                lv_Items.Items.Add(item2);
            }
        }

        private void btn_ScrambleGUID_Click(object sender, EventArgs e)
        {
            if (_active == null && _activeItem == null)
            {
                txt_Msg.Text = "No item selected!";
                return;
            }


            if (_activeItem.SearchDat("GUID", out string? OLDGUID))
            {
                // me when i run a simple replace and hope it works

                Guid guid = Guid.NewGuid();

                _activeItem.ReplaceVal("GUID", guid.ToString());
                ChangeText(_activeItem);
            }
        }

        private void exportAllIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog folderBrowserDialog = new();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFolder = folderBrowserDialog.SelectedPath;

                Parallel.ForEach(Extractor._items, item =>
                {

                    string Iconname = $"{item.Name.Replace(" ", "_")}_{item.Id}";

                    string iconfile = Icons + "\\" + Iconname + ".png";

                    if (File.Exists(iconfile))
                    {
                        _ = Path.GetFileName(item.DatPath);

                        if (File.Exists(iconfile))
                        {
                            string destinationFile = Path.Combine(outputFolder, item.Id + ".png");
                            File.Copy(iconfile, destinationFile);
                        }
                    }
                    else
                    {
                        string lonename = Path.GetFileName(item.DatPath);

                        iconfile = Icons + "\\" + lonename.Replace(".dat", "").Trim() + $"_{item.Id}" + ".png";

                        if (File.Exists(iconfile))
                        {
                            string destinationFile = Path.Combine(outputFolder, item.Id + ".png");
                            File.Copy(iconfile, destinationFile, true);
                        }
                    }
                });
            }
        }

        private void clearListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lv_Items.Items.Clear();
            txt_datEditor.Text = "";
            txt_engEditor.Text = "";
            pxb_ItemIcon.ImageLocation = "";

        }

        private void openPresetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PresetForm();
            form.ShowDialog();
        }
    }
}
