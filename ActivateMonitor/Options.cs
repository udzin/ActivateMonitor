using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;

namespace AcivateMonitor
{
	class Options
	{
		[Option('c', "clone", HelpText = "Clone displays")]
		public bool Clone { get; set; }

		[Option('e', "external", HelpText = "External display only")]
		public bool External { get; set; }

		[Option('i', "internal", HelpText = "Internal display only")]
		public bool Internal { get; set; }

		[Option('x', "extend", HelpText = "Extend displays")]
		public bool Extend { get; set; }
	}
}
