using LibShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUwp {
	/// <summary>
	/// Class Library (Universal Windows) util (UWP类库工具).
	/// </summary>
	public class LibUwpUtil {
		/// <summary>
		/// 输出信息.
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputInfo(StringBuilder sb, string onproject) {
			string myproject = "LibUwp on " + onproject;
			LibSharedUtil.OutputDefineConstants(sb, myproject);
		}
	}
}
