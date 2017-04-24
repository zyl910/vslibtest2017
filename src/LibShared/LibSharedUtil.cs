using System;
using System.Collections.Generic;
using System.Text;

namespace LibShared {
	/// <summary>
	/// VS Class Library test util（VS类库项目测试工具）.
	/// </summary>
	public class LibSharedUtil {

		/// <summary>
		/// Append common info (添加公用信息).
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="name">Project name (项目名).</param>
		public static void AppendCommon(StringBuilder sb, string name) {
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
		}
	}
}
