﻿using LibShared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.System.Profile;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace TestUwp {
	/// <summary>
	/// 可用于自身或导航至 Frame 内部的空白页。
	/// </summary>
	public sealed partial class MainPage : Page {
		public MainPage() {
			this.InitializeComponent();
		}

		private void Page_Loaded(object sender, RoutedEventArgs e) {
			btnInfo_Click(btnInfo, null);
		}

		private void btnInfo_Click(object sender, RoutedEventArgs e) {
			StringBuilder sb = new StringBuilder();
			LibSharedUtil.AppendCommon(sb, "TestUwp");
			AppendInfo(sb);
			// show.
			txtOut.Text = sb.ToString();
		}

		/// <summary>
		/// 添加信息.
		/// </summary>
		/// <param name="sb">String buffer (字符串缓冲区).</param>
		public static void AppendInfo(StringBuilder sb) {
			// AnalyticsVersionInfo
			sb.AppendLine("[AnalyticsVersionInfo]");
			AnalyticsVersionInfo ai = AnalyticsInfo.VersionInfo;
			sb.AppendLine(string.Format("DeviceFamily:\t{0}", ai.DeviceFamily));
			sb.AppendLine(string.Format("DeviceFamilyVersion:\t{0}", ai.DeviceFamilyVersion));
			sb.AppendLine(string.Format("DeviceFamilyVersion$:\t{0}", LibSharedUtil.VersionFromInt(ulong.Parse(ai.DeviceFamilyVersion)) ));
			sb.AppendLine();
			// Package
			sb.AppendLine("[Package]");
			Package package = Package.Current;
			sb.AppendLine(string.Format("Description:\t{0}", package.Description));
			sb.AppendLine(string.Format("DisplayName:\t{0}", package.DisplayName));
			//sb.AppendLine(string.Format("InstallDate:\t{0}", package.InstallDate));	// Exception
			//sb.AppendLine(string.Format("InstalledDate:\t{0}", package.InstalledDate));
			//sb.AppendLine(string.Format("InstalledLocation:\t{0}", package.InstalledLocation));
			sb.AppendLine(string.Format("InstalledLocation:\t{0}", package.InstalledLocation.Path));
			sb.AppendLine(string.Format("PublisherDisplayName:\t{0}", package.PublisherDisplayName));
			//sb.AppendLine(string.Format("Id:\t{0}", package.Id));
			sb.AppendLine(string.Format("Id.Architecture:\t{0}", package.Id.Architecture));
			////sb.AppendLine(string.Format("Id.Author:\t{0}", package.Id.Author)); // System.InvalidCastException:“Unable to cast object of type 'Windows.ApplicationModel.PackageId' to type 'Windows.ApplicationModel.IPackageIdWithMetadata'.”
			//sb.AppendLine(string.Format("Id.FamilyName:\t{0}", package.Id.FamilyName));
			//sb.AppendLine(string.Format("Id.FullName:\t{0}", package.Id.FullName));
			//sb.AppendLine(string.Format("Id.Name:\t{0}", package.Id.Name));
			////sb.AppendLine(string.Format("Id.ProductId:\t{0}", package.Id.ProductId));   // System.InvalidCastException:“Unable to cast object of type 'Windows.ApplicationModel.PackageId' to type 'Windows.ApplicationModel.IPackageIdWithMetadata'.”
			//sb.AppendLine(string.Format("Id.Publisher:\t{0}", package.Id.Publisher));
			//sb.AppendLine(string.Format("Id.PublisherId:\t{0}", package.Id.PublisherId));
			//sb.AppendLine(string.Format("Id.ResourceId:\t{0}", package.Id.ResourceId));
			//sb.AppendLine(string.Format("Id.Version:\t{0}", package.Id.Version));
			PackageVersion pv = package.Id.Version;
			string pvs = string.Format("{0}.{1}.{2}.{3}", pv.Major, pv.Minor, pv.Revision, pv.Build);
			sb.AppendLine(string.Format("Id.Version:\t{0}", pvs));
			sb.AppendLine();
			// EasClientDeviceInformation
			sb.AppendLine("[EasClientDeviceInformation]");
			EasClientDeviceInformation eas = new EasClientDeviceInformation();
			sb.AppendLine(string.Format("FriendlyName:\t{0}", eas.FriendlyName));
			sb.AppendLine(string.Format("Id:\t{0}", eas.Id));
			sb.AppendLine(string.Format("OperatingSystem:\t{0}", eas.OperatingSystem));
			sb.AppendLine(string.Format("SystemFirmwareVersion:\t{0}", eas.SystemFirmwareVersion));
			sb.AppendLine(string.Format("SystemHardwareVersion:\t{0}", eas.SystemHardwareVersion));
			sb.AppendLine(string.Format("SystemManufacturer:\t{0}", eas.SystemManufacturer));
			sb.AppendLine(string.Format("SystemProductName:\t{0}", eas.SystemProductName));
			sb.AppendLine(string.Format("SystemSku:\t{0}", eas.SystemSku));
			sb.AppendLine();
		}

	}
}
