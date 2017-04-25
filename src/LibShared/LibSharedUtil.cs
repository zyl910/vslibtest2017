using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

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
			sb.AppendLine(name);
			sb.AppendLine();
#if (!NETFX_CORE)
			sb.AppendLine(string.Format("Environment.Is64BitOperatingSystem: {0}", Environment.Is64BitOperatingSystem));
			sb.AppendLine(string.Format("Environment.Is64BitProcess: {0}", Environment.Is64BitProcess));
			sb.AppendLine(string.Format("Environment.OSVersion: {0}", Environment.OSVersion));
#endif
			sb.AppendLine(string.Format("ProcessorCount: {0}", Environment.ProcessorCount));
#if (!NETFX_CORE)
			sb.AppendLine(string.Format("Version: {0}", Environment.Version));
#endif
			sb.AppendLine(string.Format("typeof(Environment).AssemblyQualifiedName: {0}", typeof(Environment).AssemblyQualifiedName));
#if (NETFX_CORE)
			Assembly assembly = typeof(Environment).GetTypeInfo().Assembly;
#else
			Assembly assembly = typeof(Environment).Assembly;
#endif
			sb.AppendLine(string.Format("typeof(Environment).Assembly.FullName: {0}", assembly.FullName));
#if (!NETFX_CORE)
			sb.AppendLine(string.Format("typeof(Environment).Assembly.ImageRuntimeVersion: {0}", assembly.ImageRuntimeVersion));
			sb.AppendLine(string.Format("typeof(Environment).Assembly.Location: {0}", assembly.Location));
#endif
			sb.AppendLine();
		}
	}
}
