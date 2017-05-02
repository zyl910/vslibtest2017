using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibShared;
using LibDNFx;

namespace TestConsole {
	class Program {
		static void Main(string[] args) {
			StringBuilder sb = new StringBuilder();
			LibSharedUtil.OutputCommon(sb, "TestConsole");
			LibDNFxUtil.OutputInfo(sb, "TestConsole");
			// show.
			Console.WriteLine(sb.ToString());
		}
	}
}
