﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.WindowsAPICodePack.Dialogs;
using WMPLib;

namespace Soundboard
{

  class SoundBoard
  {
    private readonly Button _buttonDirectorySelect;
    private readonly TextBox _textBox;
    private readonly ListBox _fileListBox;

    // See https://support.microsoft.com/de-at/help/316992/file-types-supported-by-windows-media-player
    private static List<string> SupportedFormats;

    private readonly WindowsMediaPlayer _player = new WindowsMediaPlayer();

    private Directory directory;

    private ScrollBar _volumeBar;
    private Label _volumeLabel;
    private Button _playAndPauseButton;
    private ProgressBar _progressBar;

    private Label _currentTimeLabel;
    private Label _endTimeLabel;

    private bool _volumeLabelSet = false;

    private WMPPlayState _currentPlayState;

    public SoundBoard(Button buttonDirectorySelect, TextBox textBox, ListBox fileListBox)
    {
      _buttonDirectorySelect = buttonDirectorySelect;
      _textBox = textBox;
      _fileListBox = fileListBox;
      SupportedFormats = new List<string>()
      {
        ".asf", ".wma", ".wmv", ".wm",
        ".asx", ".wax", ".wvx", ".wmx", ".wpl",
        ".dvr-ms",
        ".wmd",
        ".avi",
        ".mpg", ".mpeg", ".m1v", ".mp2", ".mp3", ".mpa", ".mpe", ".m3u",
        ".mid", ".midi", ".rmi",
        ".aif", ".aifc", ".aiff",
        ".", ".snd",
        ".wav",
        ".cda",
        ".ivf",
        ".wmz", ".wms",
        ".mov",
        ".m4a",
        ".mp4", ".m4v", ".mp4v", ".3g2", ".3gp2", ".3gp", ".3gpp",
        ".aac", ".adt", ".adts",
        ".m2ts"
      };

      directory = new Directory(buttonDirectorySelect, textBox, fileListBox);

      _player.PlayStateChange += PlayerOnPlayStateChange;

      _fileListBox.SelectedIndexChanged += FileListBoxOnSelectedIndexChanged;
    }

    private void PlayerOnPlayStateChange(int newstate)
    {
      _currentPlayState = (WMPPlayState) newstate;

      switch (_currentPlayState)
      {
        case WMPPlayState.wmppsUndefined:
          break;
        case WMPPlayState.wmppsStopped:
          _progressBar.Value = _progressBar.Maximum;
          _playAndPauseButton.Text = "▶";
          break;
        case WMPPlayState.wmppsPaused:
          _playAndPauseButton.Text = "▶";
          break;
        case WMPPlayState.wmppsPlaying:
          _progressBar.Maximum = (int)(100 * _player.controls.currentItem.duration);
          _playAndPauseButton.Text = "⏸";

          if (_endTimeLabel != null)
          {
            _endTimeLabel.Text = _player.currentMedia.durationString;
          }
          break;
        case WMPPlayState.wmppsScanForward:
          break;
        case WMPPlayState.wmppsScanReverse:
          break;
        case WMPPlayState.wmppsBuffering:
          break;
        case WMPPlayState.wmppsWaiting:
          break;
        case WMPPlayState.wmppsMediaEnded:
          break;
        case WMPPlayState.wmppsTransitioning:
          break;
        case WMPPlayState.wmppsReady:
          break;
        case WMPPlayState.wmppsReconnecting:
          break;
        case WMPPlayState.wmppsLast:
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    public SoundBoard SetLabel(Label label)
    {
      _volumeLabel = label;
      _volumeLabelSet = true;

      UpdateVolumeLabel();

      return this;
    }

    public SoundBoard SetVolumeBar(ScrollBar scrollBar)
    {
      _volumeBar = scrollBar;
      _volumeBar.Maximum = 100 + _volumeBar.LargeChange - 1;
      _volumeBar.Scroll += OnVolumeBarScroll;
      _player.settings.volume = scrollBar.Value;

      UpdateVolumeLabel();

      return this;
    }

    public SoundBoard SetPlayAndPauseButton(Button button)
    {
      _playAndPauseButton = button;
      _playAndPauseButton.Click += OnPlayAndPauseButtonClick;

      return this;
    }

    public SoundBoard SetProgressBar(ProgressBar progressBar)
    {
      _progressBar = progressBar;

      SetProgressBarUpdateTimer();

      return this;
    }

    public SoundBoard SetCurrentTimeLabel(Label currentTimeLabel)
    {
      _currentTimeLabel = currentTimeLabel;

      return this;
    }

    public SoundBoard SetEndTimeLabel(Label endTimeLabel)
    {
      _endTimeLabel = endTimeLabel;

      return this;
    }

    #region Events

    private void FileListBoxOnSelectedIndexChanged(object sender, EventArgs e)
    {
      _player.URL = (_fileListBox.SelectedItem as SoundData)?.Value;
    }

    public void OnVolumeBarScroll(object sender, ScrollEventArgs e)
    {
      UpdateVolumeLabel();
    }

    public void OnPlayAndPauseButtonClick(object sender, EventArgs e)
    {
      if (_player.playState == WMPPlayState.wmppsPlaying)
      {
        PausePlayback();
      }
      else
      {
        StartPlayblack();
      }
    }

    private void UpdateProgressBar(object sender, EventArgs e)
    {
      if (_player.playState != WMPPlayState.wmppsPlaying)
      {
        return;
      }

      double currentPosition = 100 * _player.controls.currentPosition;

      if (currentPosition < _progressBar.Maximum)
      {
        _progressBar.Value = (int)(currentPosition);
      }

      string currentPositionStr = _player.controls.currentPositionString;

      _currentTimeLabel.Text = currentPositionStr == "" ? "00:00" : _player.controls.currentPositionString;
    }

    #endregion

    private void SetProgressBarUpdateTimer()
    {
      Timer timer = new Timer();
      timer.Tick += UpdateProgressBar;
      timer.Interval = 100; //ms
      timer.Start();
    }

    private void StartPlayblack()
    {
      if (_fileListBox.SelectedItem != null)
      {
        _player.controls.play();
      }
    }

    private void PausePlayback()
    {
      _player.controls.pause();
    }

    private void StopPlayback()
    {
      _player.controls.stop();
      _playAndPauseButton.Text = "▶";
    }

    private void NextTitle()
    {
      if (_fileListBox.SelectedIndex < _fileListBox.Items.Count - 1)
      {
        _fileListBox.SelectedIndex = _fileListBox.SelectedIndex + 1;
      }
    }

    private void PreviousTitle()
    {
      if (_fileListBox.SelectedIndex > 0)
      {
        _fileListBox.SelectedIndex = _fileListBox.SelectedIndex - 1;
      }
    }

    private void UpdateVolumeLabel()
    {
      _player.settings.volume = 100 - _volumeBar.Value;

      if (_volumeLabelSet)
      {
        _volumeLabel.Text = $"({100 - _volumeBar.Value}/100)";
      }
    }

    public class Directory
    {
      private CommonOpenFileDialog _folderDialog;

      private FlowLayoutPanel _flowLayoutPanel;
      private ListBox _fileListBox;
      private TextBox _textBox;
      private Button _button;

      private readonly bool _textBoxUsed = false;

      private string _selectedDirectory;

      internal Directory(Button button, TextBox textBox, ListBox fileListBox)
      {
        _button = button;
        _textBox = textBox;
        _fileListBox = fileListBox;
        _textBoxUsed = true;

        Init();
      }

      public Directory(Button button, ListBox fileListBox)
      {
        _button = button;
        _fileListBox = fileListBox;

        Init();
      }

      private string SelectedSelectedDirectory
      {
        get => _selectedDirectory;
        set
        {
          if (value == _selectedDirectory)
          {
            return;
          }

          _selectedDirectory = value;

          _fileListBox.DataSource = null;

          foreach (var filePath in System.IO.Directory.GetFiles(_selectedDirectory))
          {
            if (Path.HasExtension(filePath) &&
                SupportedFormats.Contains(Path.GetExtension(filePath)))
            {
              _fileListBox.Items.Add(new SoundData
              {
                Value = filePath,
                Text = Path.GetFileNameWithoutExtension(filePath)
              });
            }
          }

          _fileListBox.DisplayMember = "Text";
        }
      }

      private void Init()
      {
        _folderDialog = new CommonOpenFileDialog
        {
          InitialDirectory = _textBox.Text,
          IsFolderPicker = true
        };

        _button.Click += FetchDirectory; 
        if (_textBoxUsed)
        {
          _textBox.KeyDown += OnTextKeyPress;
        }
      }

      public void FetchDirectory(object sender, EventArgs e)
      {
        if (_folderDialog.ShowDialog() != CommonFileDialogResult.Ok)
        {
          return;
        }

        SelectedSelectedDirectory = _folderDialog.FileName;

        if (_textBoxUsed)
        {
          _textBox.Text = SelectedSelectedDirectory;
        }
      }

      private void OnTextKeyPress(object sender, KeyEventArgs e)
      {
        if (e.KeyCode == Keys.Enter)
        {
          OnTextEnter(sender, e);

          e.Handled = true;
          e.SuppressKeyPress = true;
        }
      }

      private void OnTextEnter(object sender, EventArgs e)
      {
        if (SelectedSelectedDirectory == _textBox.Text)
        {
          return;
        }

        if (System.IO.Directory.Exists(_textBox.Text))
        {
          SelectedSelectedDirectory = _textBox.Text;
          DialogDisplay(DialogType.Info, $"Directory \"{SelectedSelectedDirectory}\" has been selected!");
        }
        else
        {
          DialogResult CreateFolder = FetchDialogResult("Create Directory",
            $"Directory doesn't exist. Should \"{_textBox.Text}\" be created?",
            MessageBoxButtons.YesNo);

          if (CreateFolder == DialogResult.Yes)
          {
            DirectoryInfo directoryInfo = System.IO.Directory.CreateDirectory(_textBox.Text);

            if (directoryInfo.Exists)
            {
              return;
            }

            DialogDisplay(DialogType.Error, $"Directory \"{_textBox.Text}\" couldn't be created!");
            _textBox.Text = SelectedSelectedDirectory;
          }
        }
      }

      public string Get()
      {
        return SelectedSelectedDirectory;
      }

      public DialogResult FetchDialogResult(string windowName, string title, MessageBoxButtons type)
      {
        return MessageBox.Show(title, windowName, type);
      }

      enum DialogType
      {
        Error,
        Info
      }

      private void DialogDisplay(DialogType dialogType, string text)
      {
        MessageBox.Show(text, dialogType.ToString(), MessageBoxButtons.OK);
      }
    }
  }

  public class SoundData
  {
    public string Value { get; set; }
    public string Text { get; set; }
  }
}
