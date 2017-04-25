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
		/// 将64位整数转为版本字符串.
		/// </summary>
		/// <param name="v">整数值.</param>
		/// <returns>返回版本字符串.</returns>
		public static string VersionFromInt(ulong v) {
			ulong v1 = (v & 0xFFFF000000000000L) >> 48;
			ulong v2 = (v & 0x0000FFFF00000000L) >> 32;
			ulong v3 = (v & 0x00000000FFFF0000L) >> 16;
			ulong v4 = (v & 0x000000000000FFFFL);
			return string.Format("{0}.{1}.{2}.{3}", v1, v2, v3, v4);
		}

		/// <summary>
		/// Append common info (添加公用信息).
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="name">Project name (项目名).</param>
		public static void AppendCommon(StringBuilder sb, string name) {
			sb.AppendLine(name);
			sb.AppendLine();
			// Environment
			sb.AppendLine("[Environment]");
#if (!NETFX_CORE)
			sb.AppendLine(string.Format("Is64BitOperatingSystem:\t{0}", Environment.Is64BitOperatingSystem));
			sb.AppendLine(string.Format("Is64BitProcess:\t{0}", Environment.Is64BitProcess));
			sb.AppendLine(string.Format("OSVersion:\t{0}", Environment.OSVersion));
#endif
			sb.AppendLine(string.Format("ProcessorCount:\t{0}", Environment.ProcessorCount));
#if (!NETFX_CORE)
			sb.AppendLine(string.Format("Version:\t{0}", Environment.Version));
#endif
			sb.AppendLine(string.Format("AssemblyQualifiedName:\t{0}", typeof(Environment).AssemblyQualifiedName));
#if (NETFX_CORE)
			Assembly assembly = typeof(Environment).GetTypeInfo().Assembly;
#else
			Assembly assembly = typeof(Environment).Assembly;
#endif
			sb.AppendLine(string.Format("Assembly.FullName:\t{0}", assembly.FullName));
#if (!NETFX_CORE)
			sb.AppendLine(string.Format("Assembly.ImageRuntimeVersion:\t{0}", assembly.ImageRuntimeVersion));
			sb.AppendLine(string.Format("Assembly.Location:\t{0}", assembly.Location));
#endif
			sb.AppendLine();
		}
	}
}
