using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace LibShared {
	/// <summary>
	/// VS Class Library test util（VS类库项目测试工具）.
	/// </summary>
	internal class LibSharedUtil {
		/// <summary>
		/// Define constants(Conditional compilation symbols) field (定义的常量(条件编译符号)字段) .
		/// </summary>
		private static readonly string[] m_DefineConstants = {
#if DEBUG
			"DEBUG",
#endif
#if TRACE
			"TRACE",
#endif
#if RELEASE
			"RELEASE",
#endif
#if CODE_ANALYSIS
			"CODE_ANALYSIS",
#endif
#if UNSAFE
			"UNSAFE",
#endif
#if NETFX_CORE
			"NETFX_CORE",
#endif
#if WINDOWS_UWP
			"WINDOWS_UWP",
#endif
#if NETSTANDARD
			"NETSTANDARD",
#endif
#if NET20
			"NET20",
#endif
#if NET30
			"NET30",
#endif
#if NET35
			"NET35",
#endif
#if NET40
			"NET40",
#endif
#if NET45
			"NET45",
#endif
#if NET451
			"NET451",
#endif
#if NET452
			"NET452",
#endif
#if NET46
			"NET46",
#endif
#if NET461
			"NET461",
#endif
#if NET462
			"NET462",
#endif
#if NET47
			"NET47",
#endif
#if NETCOREAPP1_0
			"NETCOREAPP1_0",
#endif
#if NETCOREAPP1_1
			"NETCOREAPP1_1",
#endif
#if NETCOREAPP2_0
			"NETCOREAPP2_0",
#endif
#if NETSTANDARD1_0
			"NETSTANDARD1_0",
#endif
#if NETSTANDARD1_1
			"NETSTANDARD1_1",
#endif
#if NETSTANDARD1_2
			"NETSTANDARD1_2",
#endif
#if NETSTANDARD1_3
			"NETSTANDARD1_3",
#endif
#if NETSTANDARD1_4
			"NETSTANDARD1_4",
#endif
#if NETSTANDARD1_5
			"NETSTANDARD1_5",
#endif
#if NETSTANDARD1_6
			"NETSTANDARD1_6",
#endif
#if NETSTANDARD2_0
			"NETSTANDARD2_0",
#endif
		};

		/// <summary>
		/// Define constants(Conditional compilation symbols) (定义的常量(条件编译符号)) .
		/// </summary>
		public static string[] DefineConstants {
			get {
				return m_DefineConstants;
			}
		}

		/// <summary>
		/// 将64位整数转为版本字符串.
		/// </summary>
		/// <param name="v">整数值.</param>
		/// <returns>返回版本字符串.</returns>
		public static string VersionFromInt(ulong v) {
			ulong v1 = (v & 0xFFFF000000000000UL) >> 48;
			ulong v2 = (v & 0x0000FFFF00000000UL) >> 32;
			ulong v3 = (v & 0x00000000FFFF0000UL) >> 16;
			ulong v4 = (v & 0x000000000000FFFFUL);
			return string.Format("{0}.{1}.{2}.{3}", v1, v2, v3, v4);
		}

		/// <summary>
		/// Output common info (输出公用信息).
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputCommon(StringBuilder sb, string onproject) {
			sb.AppendLine(onproject);
			sb.AppendLine();
			// Environment
			sb.AppendLine("[Environment]");
#if (NETFX_CORE || NETSTANDARD1_0 || NETSTANDARD1_1 || NETSTANDARD1_2 || NETSTANDARD1_3 || NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6 || NETSTANDARD2_0)
#else
			sb.AppendLine(string.Format("Is64BitOperatingSystem:\t{0}", Environment.Is64BitOperatingSystem));
			sb.AppendLine(string.Format("Is64BitProcess:\t{0}", Environment.Is64BitProcess));
			sb.AppendLine(string.Format("OSVersion:\t{0}", Environment.OSVersion));
#endif
			sb.AppendLine(string.Format("ProcessorCount:\t{0}", Environment.ProcessorCount));
#if (NETFX_CORE || NETSTANDARD1_0 || NETSTANDARD1_1 || NETSTANDARD1_2 || NETSTANDARD1_3 || NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6 || NETSTANDARD2_0)
#else
			sb.AppendLine(string.Format("Version:\t{0}", Environment.Version));
#endif
			sb.AppendLine(string.Format("AssemblyQualifiedName:\t{0}", typeof(Environment).AssemblyQualifiedName));
#if (NETFX_CORE || NETSTANDARD1_0 || NETSTANDARD1_1 || NETSTANDARD1_2 || NETSTANDARD1_3 || NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6 || NETSTANDARD2_0)
			Assembly assembly = typeof(Environment).GetTypeInfo().Assembly;
#else
			Assembly assembly = typeof(Environment).Assembly;
#endif
			sb.AppendLine(string.Format("Assembly.FullName:\t{0}", assembly.FullName));
#if (NETFX_CORE || NETSTANDARD1_0 || NETSTANDARD1_1 || NETSTANDARD1_2 || NETSTANDARD1_3 || NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6 || NETSTANDARD2_0)
#else
			sb.AppendLine(string.Format("Assembly.ImageRuntimeVersion:\t{0}", assembly.ImageRuntimeVersion));
			sb.AppendLine(string.Format("Assembly.Location:\t{0}", assembly.Location));
#endif
			sb.AppendLine();
			// DefineConstants.
			OutputDefineConstants(sb, onproject);
		}

		/// <summary>
		/// Output define constants(Conditional compilation symbols) (输出定义常量(条件编译符号)).
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputDefineConstants(StringBuilder sb, string onproject) {
			string str = "[DefineConstants]\t# Conditional compilation symbols";
			if (!string.IsNullOrEmpty(str)) str += " on " + onproject;
			sb.AppendLine(str);
			foreach(string s in DefineConstants) {
				sb.AppendLine(s);
			}
			sb.AppendLine();
		}

	}
}
