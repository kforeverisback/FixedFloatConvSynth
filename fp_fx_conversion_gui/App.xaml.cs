using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace fp_fx_conversion_gui
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			WpfSingleInstanceByEventWaitHandle.WpfSingleInstance.Make("<Float>Astalavista<Fixed>", this);
			base.OnStartup(e);
		}
	}
}
