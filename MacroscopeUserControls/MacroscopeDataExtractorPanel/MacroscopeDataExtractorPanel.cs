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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SEOMacroscope
{

  /// <summary>
  /// Description of MacroscopeDataExtractorPanel.
  /// </summary>

  public partial class MacroscopeDataExtractorPanel : UserControl
  {

    /**************************************************************************/
        
    protected Macroscope ms;

    protected Boolean EnableValidation;
        
    /**************************************************************************/

    public MacroscopeDataExtractorPanel ()
    {

      InitializeComponent(); // The InitializeComponent() call is required for Windows Forms designer support.

      this.ms = new Macroscope ();

      this.SetEnableValidation( State: true );
            
    }

    /**************************************************************************/

    protected void SetEnableValidation ( Boolean State )
    {
      this.EnableValidation = State;
    }

    protected Boolean GetEnableValidation ()
    {
      return( this.EnableValidation );
    }

    /** Overridable Validators ************************************************/
    
    protected virtual Boolean ValidateLabel ( TextBox TextBoxObject, Boolean ShowErrorDialogue )
    {
      return( true );
    }

    protected virtual Boolean ValidateExpression ( TextBox TextBoxObject, Boolean ShowErrorDialogue )
    {
      return( true );
    }

    /** Label Event Handlers **************************************************/

    protected void CallbackTextBoxLabelTextChanged ( object sender, EventArgs e )
    {

      TextBox TextBoxObject = ( TextBox )sender;
      Boolean IsValid = false;

      TextBoxObject.Text = MacroscopeStringTools.StripNewLines( Text: TextBoxObject.Text );
            
      IsValid = this.ValidateLabel( TextBoxObject: TextBoxObject, ShowErrorDialogue: false );
            
      if( IsValid )
      {
        TextBoxObject.ForeColor = Color.Green;
      }
      else
      {
        TextBoxObject.ForeColor = Color.Red;
      }

    }

    /** Expression Event Handlers *********************************************/

    protected void CallbackTextBoxExpressionTextChanged ( object sender, EventArgs e )
    {

      TextBox TextBoxObject = ( TextBox )sender;
      Boolean IsValid = false;

      TextBoxObject.Text = MacroscopeStringTools.StripNewLines( Text: TextBoxObject.Text );

      IsValid = this.ValidateExpression( TextBoxObject: TextBoxObject, ShowErrorDialogue: false );

      if( IsValid )
      {
        TextBoxObject.ForeColor = Color.Green;
      }
      else
      {
        TextBoxObject.ForeColor = Color.Red;
      }
      
    }

    /** Keypress Event Handlers ***********************************************/
        
    protected void CallbackTextBoxKeyUp ( object sender, KeyEventArgs e )
    {

      TextBox TextBoxObject = ( TextBox )sender;

      if( e.Control && ( e.KeyCode == Keys.A ) )
      {
        TextBoxObject.SelectAll();
        TextBoxObject.Focus();
      }

    }

    /**************************************************************************/

    protected void DialogueBoxError ( string AlertTitle, string AlertMessage )
    {
      MessageBox.Show(
        AlertMessage,
        AlertTitle,
        MessageBoxButtons.OK,
        MessageBoxIcon.Error,
        MessageBoxDefaultButton.Button1
      );
    }

    /**************************************************************************/

  }

}
