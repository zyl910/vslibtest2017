using LibDNCore;
using LibDNStd;
using LibShared;
using System;
using System.Text;

namespace TestConsoleNCore {
	class Program
    {
        static void Main(string[] args)
        {
			StringBuilder sb = new StringBuilder();
			LibSharedUtil.OutputCommon(sb, "TestConsoleNCore");
			LibDNCoreUtil.OutputInfo(sb, "TestConsoleNCore");
			LibDNStdUtil.OutputInfo(sb, "TestConsoleNCore");
			// show.
			Console.WriteLine(sb.ToString());
		}
	}
}