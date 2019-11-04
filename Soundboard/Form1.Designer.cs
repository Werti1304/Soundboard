namespace Soundboard
{
  partial class Form1
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.folderBrowserDialogMusic = new System.Windows.Forms.FolderBrowserDialog();
      this.textBoxMusicDirectory = new System.Windows.Forms.TextBox();
      this.buttonSelectMusicDirectory = new System.Windows.Forms.Button();
      this.listBoxMusicFiles = new System.Windows.Forms.ListBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.labelVolume = new System.Windows.Forms.Label();
      this.buttonPlayAndPause = new System.Windows.Forms.Button();
      this.progressBar = new System.Windows.Forms.ProgressBar();
      this.vScrollBarVolume = new System.Windows.Forms.VScrollBar();
      this.labelVolumeText = new System.Windows.Forms.Label();
      this.labelEndTime = new System.Windows.Forms.Label();
      this.labelCurrentTime = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // textBoxMusicDirectory
      // 
      this.textBoxMusicDirectory.Location = new System.Drawing.Point(6, 198);
      this.textBoxMusicDirectory.Name = "textBoxMusicDirectory";
      this.textBoxMusicDirectory.Size = new System.Drawing.Size(163, 20);
      this.textBoxMusicDirectory.TabIndex = 0;
      // 
      // buttonSelectMusicDirectory
      // 
      this.buttonSelectMusicDirectory.Location = new System.Drawing.Point(6, 224);
      this.buttonSelectMusicDirectory.Name = "buttonSelectMusicDirectory";
      this.buttonSelectMusicDirectory.Size = new System.Drawing.Size(163, 23);
      this.buttonSelectMusicDirectory.TabIndex = 1;
      this.buttonSelectMusicDirectory.Text = "Select Folder";
      this.buttonSelectMusicDirectory.UseVisualStyleBackColor = true;
      // 
      // listBoxMusicFiles
      // 
      this.listBoxMusicFiles.FormattingEnabled = true;
      this.listBoxMusicFiles.Location = new System.Drawing.Point(6, 19);
      this.listBoxMusicFiles.Name = "listBoxMusicFiles";
      this.listBoxMusicFiles.Size = new System.Drawing.Size(163, 173);
      this.listBoxMusicFiles.TabIndex = 2;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.textBoxMusicDirectory);
      this.groupBox1.Controls.Add(this.listBoxMusicFiles);
      this.groupBox1.Controls.Add(this.buttonSelectMusicDirectory);
      this.groupBox1.Location = new System.Drawing.Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(186, 262);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Music Directory";
      // 
      // labelVolume
      // 
      this.labelVolume.AutoSize = true;
      this.labelVolume.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelVolume.Location = new System.Drawing.Point(218, 31);
      this.labelVolume.Name = "labelVolume";
      this.labelVolume.Size = new System.Drawing.Size(72, 18);
      this.labelVolume.TabIndex = 5;
      this.labelVolume.Text = "(XX/100)";
      // 
      // buttonPlayAndPause
      // 
      this.buttonPlayAndPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.buttonPlayAndPause.Location = new System.Drawing.Point(12, 280);
      this.buttonPlayAndPause.Name = "buttonPlayAndPause";
      this.buttonPlayAndPause.Size = new System.Drawing.Size(72, 31);
      this.buttonPlayAndPause.TabIndex = 6;
      this.buttonPlayAndPause.Text = "▶";
      this.buttonPlayAndPause.UseVisualStyleBackColor = true;
      // 
      // progressBar
      // 
      this.progressBar.Location = new System.Drawing.Point(63, 415);
      this.progressBar.MarqueeAnimationSpeed = 10;
      this.progressBar.Name = "progressBar";
      this.progressBar.Size = new System.Drawing.Size(671, 23);
      this.progressBar.Step = 1;
      this.progressBar.TabIndex = 7;
      // 
      // vScrollBarVolume
      // 
      this.vScrollBarVolume.Location = new System.Drawing.Point(223, 60);
      this.vScrollBarVolume.Name = "vScrollBarVolume";
      this.vScrollBarVolume.Size = new System.Drawing.Size(59, 214);
      this.vScrollBarVolume.SmallChange = 5;
      this.vScrollBarVolume.TabIndex = 8;
      this.vScrollBarVolume.Value = 70;
      // 
      // labelVolumeText
      // 
      this.labelVolumeText.AutoSize = true;
      this.labelVolumeText.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelVolumeText.Location = new System.Drawing.Point(221, 13);
      this.labelVolumeText.Name = "labelVolumeText";
      this.labelVolumeText.Size = new System.Drawing.Size(56, 18);
      this.labelVolumeText.TabIndex = 9;
      this.labelVolumeText.Text = "Volume";
      // 
      // labelEndTime
      // 
      this.labelEndTime.AutoSize = true;
      this.labelEndTime.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelEndTime.Location = new System.Drawing.Point(740, 417);
      this.labelEndTime.Name = "labelEndTime";
      this.labelEndTime.Size = new System.Drawing.Size(48, 18);
      this.labelEndTime.TabIndex = 11;
      this.labelEndTime.Text = "--:--";
      // 
      // labelCurrentTime
      // 
      this.labelCurrentTime.AutoSize = true;
      this.labelCurrentTime.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelCurrentTime.Location = new System.Drawing.Point(9, 417);
      this.labelCurrentTime.Name = "labelCurrentTime";
      this.labelCurrentTime.Size = new System.Drawing.Size(48, 18);
      this.labelCurrentTime.TabIndex = 12;
      this.labelCurrentTime.Text = "00:00";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.labelCurrentTime);
      this.Controls.Add(this.labelEndTime);
      this.Controls.Add(this.labelVolumeText);
      this.Controls.Add(this.vScrollBarVolume);
      this.Controls.Add(this.progressBar);
      this.Controls.Add(this.buttonPlayAndPause);
      this.Controls.Add(this.labelVolume);
      this.Controls.Add(this.groupBox1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogMusic;
    private System.Windows.Forms.TextBox textBoxMusicDirectory;
    private System.Windows.Forms.Button buttonSelectMusicDirectory;
    private System.Windows.Forms.ListBox listBoxMusicFiles;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label labelVolume;
    private System.Windows.Forms.Button buttonPlayAndPause;
    private System.Windows.Forms.ProgressBar progressBar;
    private System.Windows.Forms.VScrollBar vScrollBarVolume;
    private System.Windows.Forms.Label labelVolumeText;
    private System.Windows.Forms.Label labelEndTime;
    private System.Windows.Forms.Label labelCurrentTime;
  }
}

