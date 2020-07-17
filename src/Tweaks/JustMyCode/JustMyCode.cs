﻿//using System.ComponentModel.Design;
//using Microsoft;
//using Microsoft.VisualStudio.Settings;
//using Microsoft.VisualStudio.Shell;
//using Microsoft.VisualStudio.Shell.Settings;
//using Task = System.Threading.Tasks.Task;

//namespace Tweakster
//{
//    internal sealed class JustMyCode
//    {
//        private const string _collectionPath = "Debugger";
//        private const string _propertyName = "JustMyCode";
//        private static ShellSettingsManager _settingsManager;

//        public static async Task InitializeAsync(AsyncPackage package)
//        {
//            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);

//            var commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
//            Assumes.Present(commandService);

//            _settingsManager = new ShellSettingsManager(package);

//            var cmdId = new CommandID(PackageGuids.guidCommands, PackageIds.JustMyCode);
//            var menuItem = new OleMenuCommand((s, e) => Execute((OleMenuCommand)s), cmdId);
//            menuItem.BeforeQueryStatus += (s, e) => OnBeforeQueryStatus((OleMenuCommand)s);
//            commandService.AddCommand(menuItem);
//        }

//        private static void OnBeforeQueryStatus(OleMenuCommand menuItem)
//        {
//            SettingsStore store = _settingsManager.GetReadOnlySettingsStore(SettingsScope.UserSettings);

//            if (store.CollectionExists(_collectionPath))
//            {
//                menuItem.Checked = store.GetBoolean(_collectionPath, _propertyName, true);
//                menuItem.Enabled = true; // Enable on package load
//            }
//        }

//        private static void Execute(OleMenuCommand menuItem)
//        {
//            WritableSettingsStore store = _settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);

//            if (store.CollectionExists(_collectionPath))
//            {
//                store.SetBoolean(_collectionPath, _propertyName, !menuItem.Checked);
//            }
//        }
//    }
//}
