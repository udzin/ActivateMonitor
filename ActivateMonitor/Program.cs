using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using CommandLine.Text;
using AcivateMonitor;

namespace ActivateMonitor
{
	class Program
	{
		static void Main(string[] args)
		{
			var options = new Options();
			HelpText helpText = HelpText.AutoBuild(options);
			Console.WriteLine(helpText.ToString());

			var result = CommandLine.Parser.Default.ParseArguments(args, options);
			if (result)
			{
				Program program = new Program();
				if (options.Internal)
				{
					program.InternalDisplay();
				}
				if (options.External)
				{
					program.ExternalDisplay();
				}
				if (options.Clone)
				{
					program.CloneDisplays();
				}
				if (options.Extend)
				{
					program.ExtendDisplays();
				}
			}
		}

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern long SetDisplayConfig(uint numPathArrayElements,
		IntPtr pathArray, uint numModeArrayElements, IntPtr modeArray, uint flags);

		UInt32 SDC_TOPOLOGY_INTERNAL = 0x00000001;
		UInt32 SDC_TOPOLOGY_CLONE = 0x00000002;
		UInt32 SDC_TOPOLOGY_EXTEND = 0x00000004;
		UInt32 SDC_TOPOLOGY_EXTERNAL = 0x00000008;
		UInt32 SDC_APPLY = 0x00000080;

		public void CloneDisplays()
		{
			SetDisplayConfig(0, IntPtr.Zero, 0, IntPtr.Zero, (SDC_APPLY | SDC_TOPOLOGY_CLONE));
		}

		public void ExtendDisplays()
		{
			SetDisplayConfig(0, IntPtr.Zero, 0, IntPtr.Zero, (SDC_APPLY | SDC_TOPOLOGY_EXTEND));
		}

		public void ExternalDisplay()
		{
			SetDisplayConfig(0, IntPtr.Zero, 0, IntPtr.Zero, (SDC_APPLY | SDC_TOPOLOGY_EXTERNAL));
		}

		public void InternalDisplay()
		{
			SetDisplayConfig(0, IntPtr.Zero, 0, IntPtr.Zero, (SDC_APPLY | SDC_TOPOLOGY_INTERNAL));
		}
	}
}
