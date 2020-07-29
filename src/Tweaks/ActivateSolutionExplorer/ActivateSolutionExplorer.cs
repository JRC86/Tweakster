﻿using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Events;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace Tweakster.Tweaks.ActivateSolutionExplorer
{
    internal sealed class ActivateSolutionExplorer
    {
        private static AsyncPackage _package;
        private static IVsUIShell _uiShell;

        public static async Task InitializeAsync(AsyncPackage package)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            _package = package;
            _uiShell = await package.GetServiceAsync<SVsUIShell, IVsUIShell>();

            if (await IsSolutionLoadedAsync())
            {
                Execute();
            }

            SolutionEvents.OnAfterBackgroundSolutionLoadComplete += Execute;
        }

        private static void Execute(object sender = null, EventArgs e = null)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            Guid guid = typeof(VSConstants.VSStd97CmdID).GUID;
            uint id = 0xea;

            _uiShell.PostExecCommand(guid, id, 0, null);
        }

        private static async Task<bool> IsSolutionLoadedAsync()
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            IVsSolution solService = await _package.GetServiceAsync<SVsSolution, IVsSolution>();

            ErrorHandler.ThrowOnFailure(solService.GetProperty((int)__VSPROPID.VSPROPID_IsSolutionOpen, out var value));

            return value is bool isSolOpen && isSolOpen;
        }
    }
}
