using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace fp_fx_conversion_gui.Helpers
{
	static class Utility
	{
		public static string ToBitString(this BitArray bits)
		{
			var sb = new StringBuilder();

			for (int i = bits.Count - 1; i >= 0; i--)
			{
				char c = bits[i] ? '1' : '0';
				sb.Append(c);
			}

			return sb.ToString();
		}

		public static string ToBitString(this BitArray bits, int bit_count)
		{
			var sb = new StringBuilder();

			int bit_index = bit_count - 1;
			for (int i = bit_index; i >= 0 ;i--)
			{
				char c = bits[i] ? '1' : '0';
				sb.Append(c);
			}

			return sb.ToString();
		}

		public static bool ExistsOnPath(string fileName)
		{
			return GetFullPath(fileName) != null;
		}

		public static string GetFullSystemPath(string fileName)
		{
			if (File.Exists(fileName))
				return Path.GetFullPath(fileName);

			var values = Environment.GetEnvironmentVariable("PATH");
			foreach (var path in values.Split(';'))
			{
				var fullPath = Path.Combine(path, fileName);
				if (File.Exists(fullPath))
					return fullPath;
			}
			return null;
		}
		static public void ShowInfo(string txt)
		{
			System.Windows.MessageBox.Show(txt, "Successful", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
		}
		static public void ShowError(string txt)
		{
			System.Windows.MessageBox.Show(txt, "!!Error!!", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
		}
		static public void ShowWarning(string txt)
		{
			System.Windows.MessageBox.Show(txt, "!!WARNING!!", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
		}
		public static bool IsTextAllowed(string text)
		{
			Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
			return !regex.IsMatch(text);
		}

		public static string GetFullPath(string pathInApplication, Assembly assembly = null)
		{
			if (assembly == null)
			{
				assembly = Assembly.GetCallingAssembly();
			}

			if (pathInApplication[0] == '/')
			{
				pathInApplication = pathInApplication.Substring(1);
			}
			return new Uri(@"pack://application:,,,/" + assembly.GetName().Name + ";component/" + pathInApplication, UriKind.Absolute).ToString();
		}
	}
}
