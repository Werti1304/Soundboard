using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

      SoundBoard soundBoard = new SoundBoard(buttonSelectMusicDirectory, textBoxMusicDirectory, listBoxMusicFiles);

      soundBoard
        .SetVolumeBar(vScrollBarVolume)
        .SetLabel(labelVolume)
        .SetPlayAndPauseButton(buttonPlayAndPause)
        .SetProgressBar(progressBar)
        .SetCurrentTimeLabel(labelCurrentTime)
        .SetEndTimeLabel(labelEndTime);
    }
  }
}
