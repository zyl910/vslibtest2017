using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole {
	class Program {
		static void Main(string[] args) {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("TestConsole");
			sb.AppendLine();
			sb.AppendLine(string.Format("Is64BitOperatingSystem: {0}", Environment.Is64BitOperatingSystem));
			sb.AppendLine(string.Format("Is64BitProcess: {0}", Environment.Is64BitProcess));
			sb.AppendLine(string.Format("OSVersion: {0}", Environment.OSVersion));
			sb.AppendLine(string.Format("ProcessorCount: {0}", Environment.ProcessorCount));
			sb.AppendLine(string.Format("Version: {0}", Environment.Version));
			sb.AppendLine(string.Format("[CLR] AssemblyQualifiedName: {0}", typeof(Environment).AssemblyQualifiedName));
			sb.AppendLine(string.Format("[CLR] Assembly.ImageRuntimeVersion: {0}", typeof(Environment).Assembly.ImageRuntimeVersion));
			sb.AppendLine(string.Format("[CLR] Assembly.Location: {0}", typeof(Environment).Assembly.Location));
			sb.AppendLine();
			// show.
			Console.WriteLine(sb.ToString());
		}
	}
}
