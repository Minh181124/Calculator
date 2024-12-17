namespace Maytinh.View
{
    partial class LichSu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LichSu));
            lst_history = new ListBox();
            btn_clear = new Button();
            SuspendLayout();
            // 
            // lst_history
            // 
            lst_history.FormattingEnabled = true;
            lst_history.ItemHeight = 15;
            lst_history.Location = new Point(12, 19);
            lst_history.Name = "lst_history";
            lst_history.Size = new Size(425, 229);
            lst_history.TabIndex = 0;
            lst_history.SelectedIndexChanged += lst_history_SelectedIndexChanged;
            // 
            // btn_clear
            // 
            btn_clear.BackColor = SystemColors.ButtonFace;
            btn_clear.Location = new Point(363, 3);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(75, 23);
            btn_clear.TabIndex = 1;
            btn_clear.Text = "Clear";
            btn_clear.UseVisualStyleBackColor = false;
            btn_clear.Click += btn_clear_Click;
            // 
            // LichSu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 256);
            ControlBox = false;
            Controls.Add(btn_clear);
            Controls.Add(lst_history);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "LichSu";
            Text = "History";
            Load += LichSu_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lst_history;
        private Button btn_clear;
    }
}