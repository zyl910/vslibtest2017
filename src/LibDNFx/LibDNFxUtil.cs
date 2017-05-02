using LibShared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDNFx {
	/// <summary>
	/// Class Library (.NET Framework) util (.NET Framework 类库工具).
	/// </summary>
	public class LibDNFxUtil {

		/// <summary>
		/// 输出信息.
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		/// <param name="onproject">On project (所处项目)</param>
		public static void OutputInfo(StringBuilder sb, string onproject) {
			string myproject = "LibDNFx on " + onproject;
			LibSharedUtil.OutputDefineConstants(sb, myproject);
		}
	}
}
