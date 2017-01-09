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
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SEOMacroscope
{

	internal sealed class Program
	{

		public static void Exit () {
			debug_msg( "Exiting" );
			Application.Exit();
		}

		#if BUILD_TEXT_VERSION
		
		public static void Main( string[] args )
		{
			debug_msg( "SEO Macroscope" );
			MacroscopeJob msJob = new MacroscopeJob ();

			string sPathExcelHrefLangs = Environment.GetEnvironmentVariable( "TEMP" ).ToString();

			msJob.start_url = Environment.GetEnvironmentVariable( "seomacroscope_scan_url" ).ToString();

			msJob.depth = 5;
			msJob.page_limit = 10;
			msJob.probe_hreflangs = false;

			msJob.run();

			msJob.list_results();

			MacroscopeExcelReports msExcelReports = new MacroscopeExcelReports();

			msExcelReports.write_xslx_file_overview(
				msJob,
				string.Join(
					"",
					sPathExcelHrefLangs,
					System.IO.Path.DirectorySeparatorChar,
					"excel_overview"
				)
			);

			msExcelReports.write_xslx_file_hreflang(
				msJob,
				string.Join(
					"",
					sPathExcelHrefLangs,
					System.IO.Path.DirectorySeparatorChar,
					"excel_hreflang"
				)
			);

		}

		#else

		[STAThread]
		private static void Main( string[] args )
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new MacroscopeMainForm () );
		}

		#endif

		static void debug_msg( String sMsg )
		{
			System.Diagnostics.Debug.WriteLine( sMsg );
		}

		static void debug_msg( String sMsg, int iOffset )
		{
			String sMsgPadded = new String ( ' ', iOffset * 2 ) + sMsg;
			System.Diagnostics.Debug.WriteLine( sMsgPadded );
		}

	}

}