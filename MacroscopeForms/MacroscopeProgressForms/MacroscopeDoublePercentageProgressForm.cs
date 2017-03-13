﻿/*

  This file is part of SEOMacroscope.

  Copyright 2017 Jason Holland.

  The GitHub repository may be found at:

    https://github.com/nazuke/SEOMacroscope

  Foobar is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  Foobar is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with Foobar.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace SEOMacroscope
{
  
  /// <summary>
  /// Description of MacroscopeDoublePercentageProgressForm.
  /// </summary>

  public partial class MacroscopeDoublePercentageProgressForm : Form, IMacroscopeProgressForm
  {

    /**************************************************************************/

    private Boolean IsCancelled;

    /**************************************************************************/

    public MacroscopeDoublePercentageProgressForm ()
    {
      InitializeComponent(); // The InitializeComponent() call is required for Windows Forms designer support.
    }

    /**************************************************************************/
    
    void MacroscopeDoublePercentageProgressFormFormClosing ( object sender, FormClosingEventArgs e )
    {
      this.Cancel();
    }
    
    /**************************************************************************/

    public void UpdatePercentages (
      string Title,
      string Message,
      decimal MajorPercentage,
      string ProgressLabelMajor
    )
    {
    }

    /**************************************************************************/
    
    public void UpdatePercentages (
      string Title,
      string Message,
      decimal MajorPercentage,
      string ProgressLabelMajor,
      decimal MinorPercentage,
      string ProgressLabelMinor
    )
    {

      if( Title != null )
      {
        this.Text = Title;
      }
      
      if( Message != null )
      {
        this.labelMessage.Text = Message;
      }
      
      if( MajorPercentage >= 0 )
      {
        this.progressBarMajor.Value = (int)MajorPercentage;
      }
      
      if( ProgressLabelMajor != null )
      {
        this.labelProgressLabelMajor.Text = ProgressLabelMajor;
      }
      
      if( MinorPercentage >= 0 )
      {
        this.progressBarMinor.Value = (int)MinorPercentage;
      }
      
      if( ProgressLabelMinor != null )
      {
        this.labelProgressLabelMinor.Text = ProgressLabelMinor;
      }
      
      this.Refresh();
      
      return;
            
    }

    /**************************************************************************/

    public void UpdatePercentages (
      string Title,
      string Message,
      decimal MajorPercentage,
      string ProgressLabelMajor,
      decimal MinorPercentage,
      string ProgressLabelMinor,
      decimal SubMinorPercentage,
      string SubProgressLabelMinor
    )
    {
    }
    
    /**************************************************************************/

    public void Reset ()
    {
      this.Text = "Processing";
      this.labelMessage.Text = "";
      this.progressBarMajor.Value = 0;
      this.labelProgressLabelMajor.Text = "";
      this.progressBarMinor.Value = 0;
      this.labelProgressLabelMinor.Text = "";
    }

    /**************************************************************************/

    public void Cancel ()
    {
      this.IsCancelled = true;
    }

    /**************************************************************************/

    public Boolean Cancelled ()
    {
      return( this.IsCancelled );
    }
    
    /**************************************************************************/
    
  }

}
