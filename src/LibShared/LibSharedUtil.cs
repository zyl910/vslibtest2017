using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics;

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
		/// 取得属性值.
		/// </summary>
		/// <param name="typ">类型. 为空时自动根据obj来取类型.</param>
		/// <param name="obj">对象.</param>
		/// <param name="membername">成员名.</param>
		/// <param name="ishad">是否存在该属性.</param>
		/// <returns>返回属性值.</returns>
		public static object GetPropertyValue(Type typ, object obj, String membername, out bool ishad) {
			object rt = null;
			ishad = false;
			if (null == typ && null == obj) return rt;
			if (string.IsNullOrEmpty(membername)) return rt;
			if (null == typ) typ = obj.GetType();
			// Get Property.
			PropertyInfo pi = typ.GetRuntimeProperty(membername);
			if (null == pi) return rt;
			// Get Value.
			if (!pi.CanRead) return rt;
			try {
				rt = pi.GetValue(obj);
				ishad = true;
			}catch(Exception ex) {
				Debug.WriteLine(ex.ToString());
			}
			return rt;
		}

		/// <summary>
		/// 输出属性值.
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="typ">类型. 为空时自动根据obj来取类型.</param>
		/// <param name="obj">对象.</param>
		/// <param name="membername">成员名.</param>
		/// <param name="formatargidx">属性值的格式化参数索引. 默认为 0.</param>
		/// <param name="format">格式化串. 默认为 membername + ":\t{0}". </param>
		/// <param name="args">参数.</param>
		/// <returns>返回该属性是否成功输出.</returns>
		public static bool AppendProperty(StringBuilder sb, Type typ, object obj, String membername, int formatargidx = 0, string format=null, params object[] args) {
			bool rt = false;
			if (null == sb) return rt;
			bool ishad = false;
			object v = GetPropertyValue(typ, obj, membername, out ishad);
			if (!ishad) return rt;
			object[] args2 = args;
			if (null== format) {
				format = membername + ":\t{0}";
				args2 = new object[] { v };
			} else {
				if (null == args) {
					args2 = new object[] { };
				} else {
					if (formatargidx >= args.Length) {
						args2 = new object[formatargidx + 1];
						Array.Copy(args, args2, args.Length);
					}
					args2[formatargidx] = v;
				}
			}
			string str = string.Format(format, args2);
			sb.AppendLine(str);
			return rt;
		}

		/// <summary>
		/// Output head info (输出头信息).
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputHead(StringBuilder sb, string onproject) {
			sb.AppendLine(onproject);
			sb.AppendLine();
			// OutputCommon
			OutputCommon(sb, onproject);
		}

		/// <summary>
		/// Output common info (输出公用信息).
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputCommon(StringBuilder sb, string onproject) {
			// Environment
			OutputEnvironment(sb, onproject);
			// DefineConstants.
			OutputDefineConstants(sb, onproject);
		}

		/// <summary>
		/// Output Environment (输出环境信息).
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputEnvironment(StringBuilder sb, string onproject) {
			string str = "[Environment]\t# ";
			if (!string.IsNullOrEmpty(str)) str += " on " + onproject;
			sb.AppendLine(str);
			//sb.AppendLine(string.Format("Is64BitOperatingSystem:\t{0}", Environment.Is64BitOperatingSystem));
			//sb.AppendLine(string.Format("Is64BitProcess:\t{0}", Environment.Is64BitProcess));
			//sb.AppendLine(string.Format("OSVersion:\t{0}", Environment.OSVersion));
			//sb.AppendLine(string.Format("ProcessorCount:\t{0}", Environment.ProcessorCount));
			//sb.AppendLine(string.Format("Version:\t{0}", Environment.Version));
			Type typ = typeof(Environment);
			AppendProperty(sb, typ, null, "Is64BitOperatingSystem");
			AppendProperty(sb, typ, null, "Is64BitProcess");
			AppendProperty(sb, typ, null, "OSVersion");
			AppendProperty(sb, typ, null, "ProcessorCount");
			AppendProperty(sb, typ, null, "Version");
			sb.AppendLine(string.Format("AssemblyQualifiedName:\t{0}", typeof(Environment).AssemblyQualifiedName));
			// typeof(Environment).Assembly .
			sb.AppendLine("[Environment.Assembly]");
#if (NET20 || NET30 || NET35 || NET40)
			Assembly assembly = typeof(Environment).Assembly;
#else
			Assembly assembly = typeof(Environment).GetTypeInfo().Assembly;
#endif
			//sb.AppendLine(string.Format("Assembly.FullName:\t{0}", assembly.FullName));
			//sb.AppendLine(string.Format("Assembly.ImageRuntimeVersion:\t{0}", assembly.ImageRuntimeVersion));
			//sb.AppendLine(string.Format("Assembly.Location:\t{0}", assembly.Location));
			AppendProperty(sb, null, assembly, "FullName");
			AppendProperty(sb, null, assembly, "ImageRuntimeVersion");
			AppendProperty(sb, null, assembly, "Location");
			sb.AppendLine();
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
