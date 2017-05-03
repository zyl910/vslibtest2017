using LibShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibPortable {
	/// <summary>
	/// 输出信息.
	/// </summary>
	/// <param name="sb">String buffer (字符串缓冲区).</param>
	/// <param name="onproject">On project (所处项目)</param>
	public class LibPortableUtil {

		/// <summary>
		/// 输出信息.
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputInfo(StringBuilder sb, string onproject) {
			string myproject = "LibPortable on " + onproject;
			LibSharedUtil.OutputCommon(sb, myproject);
		}
	}
}
