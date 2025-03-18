#pragma warning disable CS8602

using System.Text.Json;
using System.Text.Json.Serialization;
using JCompany;
using static James_Company.PresetForm;

namespace James_Company
{
    public partial class PresetForm : Form
    {
        public static int prescount;

        public class Preset
        {
            public string Name { get; set; }

            public string Data { get; set; }
        }

        private bool changing = false;

        public PresetForm()
        {
            InitializeComponent();

            FormClosing += close;

            LoadFromSave();
        }
        private List<Preset> presets = new List<Preset>();
        private void LoadFromSave()
        {
            string pathToSave = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "preset.json");
            if (File.Exists(pathToSave))
            {
                string jsonContent = File.ReadAllText(pathToSave);
                presets = JsonSerializer.Deserialize<List<Preset>>(jsonContent) ?? new List<Preset>();

                if (PresetDisplay.InvokeRequired)
                {
                    PresetDisplay.Invoke(new Action(() =>
                    {
                        foreach (var preset in presets)
                        {
                            var pdo = new ListViewItem(preset.Name);
                            pdo.Tag = preset;
                            PresetDisplay.Items.Add(pdo);
                        }
                    }));
                }
                else
                {
                    foreach (var preset in presets)
                    {
                        if (preset != null && !string.IsNullOrEmpty(preset.Name))
                        {
                            var pdo = new ListViewItem(preset.Name);
                            pdo.Tag = preset;
                            PresetDisplay.Items.Add(pdo);
                        }
                    }
                }
            }
            else
            {
                presets = new()
                {
                    new() {Name = "Warzone", Data = "2892928153, 2969405156, 2892928378, 2586467317, 2640079237"},
                    new() {Name = "Rime", Data = "3209270207"},
                    new() {Name = "Downgun", Data = "3327793772"},
                    new() {Name = "Roez", Data = "2584541726"}
                };
                SaveAll();
                Thread.Sleep(50);
                LoadFromSave();
            }

        }

        private void close(object? sender, FormClosingEventArgs e)
        {
            FormClosing -= close;

            SaveAll();
        }

        private void AddPreset_Click(object sender, EventArgs e)
        {
            int count = presets.Count();
            string name = $"Preset_{count + 1}";
            var set = new Preset() { Name = name, Data = "" };
            presets.Add(set);

            var pdo = new ListViewItem(name);
            pdo.Tag = set;

            PresetDisplay.Items.Add(pdo);
        }

        private void PresetDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (changing)
                return;
            if (PresetDisplay.SelectedItems.Count > 0)
            {
                ListViewItem selected = PresetDisplay.SelectedItems[0];


                Preset? preset = selected.Tag as Preset;
                Sselectedpreset = preset;

                textBox1.Text = preset.Data;
            }
        }

        private Preset? Sselectedpreset { get; set; }

        private ListViewItem SselectedPresetList { get; set; }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (changing)
            {
                return;
            }

            if (Sselectedpreset == null || SselectedPresetList == null)
            {
                return;
            }

            SaveAll();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                e.SuppressKeyPress = true;
                SaveAll();
            }
        }
        
        private void SaveAll()
        {
            if (Sselectedpreset != null)
                presets.Find(x => x == Sselectedpreset).Data = textBox1.Text;

            string json = JsonSerializer.Serialize(presets, new JsonSerializerOptions() { WriteIndented = true});
            string pathToSave = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "preset.json");

            File.WriteAllText(pathToSave, json);
        }

        private void DeletePreset_Click(object sender, EventArgs e)
        {
            if (Sselectedpreset != null)
            {
                presets.Remove(Sselectedpreset);
                SaveAll();
                Sselectedpreset = null;
            }
        }

        private void RunPreset_Click_1(object sender, EventArgs e)
        {
            string[] splits = Sselectedpreset.Data.Split(',');
            for (int i = 0; i < splits.Length; i++)
            {
                string intd = splits[i];

                //this is my super jank way to check if its a full path or a workshop ID path
                if (intd.Skip(1) == ":")
                {
                    Extractor.ExtractAll(intd, false);
                }
                else
                {
                    Extractor.ExtractAll(Path.Combine(ItemStudio.instance.Workshop, intd), false);
                }
            }
        }
    }
}