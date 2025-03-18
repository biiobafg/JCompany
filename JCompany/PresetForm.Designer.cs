namespace James_Company
{
    partial class PresetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PresetForm));
            label1 = new Label();
            PresetDisplay = new ListView();
            textBox1 = new TextBox();
            AddPreset = new Button();
            DeletePreset = new Button();
            label2 = new Label();
            RunPreset = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 7);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 1;
            label1.Text = "Presets:";
            // 
            // PresetDisplay
            // 
            PresetDisplay.Activation = ItemActivation.TwoClick;
            PresetDisplay.Alignment = ListViewAlignment.Left;
            PresetDisplay.FullRowSelect = true;
            PresetDisplay.Location = new Point(10, 25);
            PresetDisplay.Name = "PresetDisplay";
            PresetDisplay.RightToLeft = RightToLeft.No;
            PresetDisplay.Size = new Size(140, 346);
            PresetDisplay.TabIndex = 2;
            PresetDisplay.UseCompatibleStateImageBehavior = false;
            PresetDisplay.View = View.List;
            PresetDisplay.SelectedIndexChanged += PresetDisplay_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(156, 25);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(241, 346);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // AddPreset
            // 
            AddPreset.Location = new Point(12, 376);
            AddPreset.Name = "AddPreset";
            AddPreset.Size = new Size(116, 54);
            AddPreset.TabIndex = 4;
            AddPreset.Text = "Add";
            AddPreset.UseVisualStyleBackColor = true;
            AddPreset.Click += AddPreset_Click;
            // 
            // DeletePreset
            // 
            DeletePreset.Location = new Point(134, 377);
            DeletePreset.Name = "DeletePreset";
            DeletePreset.Size = new Size(116, 53);
            DeletePreset.TabIndex = 5;
            DeletePreset.Text = "Delete";
            DeletePreset.UseVisualStyleBackColor = true;
            DeletePreset.Click += DeletePreset_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(156, 7);
            label2.Name = "label2";
            label2.Size = new Size(189, 15);
            label2.TabIndex = 6;
            label2.Text = "Add mod ids seperated by comma";
            // 
            // RunPreset
            // 
            RunPreset.Location = new Point(256, 377);
            RunPreset.Name = "RunPreset";
            RunPreset.Size = new Size(141, 54);
            RunPreset.TabIndex = 7;
            RunPreset.Text = "Run";
            RunPreset.UseVisualStyleBackColor = true;
            RunPreset.Click += RunPreset_Click_1;
            // 
            // PresetForm
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            ClientSize = new Size(409, 442);
            Controls.Add(RunPreset);
            Controls.Add(label2);
            Controls.Add(DeletePreset);
            Controls.Add(AddPreset);
            Controls.Add(textBox1);
            Controls.Add(PresetDisplay);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(425, 481);
            MinimumSize = new Size(425, 481);
            Name = "PresetForm";
            Text = "Presets";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        public ListView PresetDisplay;
        private TextBox textBox1;
        private Button AddPreset;
        private Button DeletePreset;
        private Label label2;
        private Button RunPreset;
    }
}