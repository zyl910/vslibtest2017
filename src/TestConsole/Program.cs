﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibShared;

namespace TestConsole {
	class Program {
		static void Main(string[] args) {
			StringBuilder sb = new StringBuilder();
			LibSharedUtil.AppendCommon(sb, "TestConsole");
			// show.
			Console.WriteLine(sb.ToString());
		}
	}
}
