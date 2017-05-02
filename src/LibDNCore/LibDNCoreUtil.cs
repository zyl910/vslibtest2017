using LibShared;
using System;
using System.Text;

namespace LibDNCore
{
	/// <summary>
	/// Class Library (.NET Core) util (.NET Core类库工具).
	/// </summary>
	public class LibDNCoreUtil {
		/// <summary>
		/// 输出信息.
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputInfo(StringBuilder sb, string onproject) {
			string myproject = "LibDNCore on " + onproject;
			LibSharedUtil.OutputDefineConstants(sb, myproject);
		}
	}
}
