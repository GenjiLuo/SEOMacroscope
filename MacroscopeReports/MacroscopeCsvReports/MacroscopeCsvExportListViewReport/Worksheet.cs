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
using CsvHelper;

namespace SEOMacroscope
{

  public partial class MacroscopeCsvExportListViewReport : MacroscopeCsvReports
  {

    /**************************************************************************/

    private void BuildWorksheetListView (
      MacroscopeJobMaster JobMaster,
      CsvWriter ws
    )
    {

      for( int i = 0 ; i < this.TargetListView.Columns.Count ; i++ )
      {

        string ColumnName = this.TargetListView.Columns[ i ].Text;

        ws.WriteField( ColumnName );

      }
        
      ws.NextRecord();

      for( int j = 0 ; j < this.TargetListView.Items.Count ; j++ )
      {

        for( int k = 0 ; k < this.TargetListView.Items[ j ].SubItems.Count ; k++ )
        {
      
          string CellValue = this.TargetListView.Items[ j ].SubItems[ k ].Text;
          
          this.InsertAndFormatContentCell( ws, CellValue );
      
        }
      
        ws.NextRecord();

      }
      
    }

    /**************************************************************************/

  }

}
