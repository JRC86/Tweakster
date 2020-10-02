﻿using System.ComponentModel.Composition;
using System.Windows;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Commanding;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.Commanding.Commands;
using Microsoft.VisualStudio.Utilities;

namespace Tweakster.Tweaks.Editor
{
    [Export(typeof(ICommandHandler))]
    [Name(nameof(WarnOnPaste))]
    [ContentType("text")]
    [TextViewRole(PredefinedTextViewRoles.PrimaryDocument)]
    public class WarnOnPaste : ICommandHandler<PasteCommandArgs> // Replace EditorCommandArgs with more specific CommandArgs class
    {
        [Import]
        public SVsServiceProvider ServiceProvider { get; private set; }

        public string DisplayName => nameof(WarnOnPaste);

        public bool ExecuteCommand(PasteCommandArgs args, CommandExecutionContext executionContext)
        {
            if (!Options.Instance.WarnOnPaste)
            {
                return false;
            }

            var length = Clipboard.GetText(TextDataFormat.Text).Length;

            if (length < 10000)
            {
                return false;
            }

            var proceed = VsShellUtilities.ShowMessageBox(
                ServiceProvider,
                $"Are you sure you want to paste {length:N0} characters into the editor?",
                Vsix.Name,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OKCANCEL,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);

            return proceed != (int)VSConstants.MessageBoxResult.IDOK;
        }

        public CommandState GetCommandState(PasteCommandArgs args)
        {
            return CommandState.Unspecified;
        }
    }
}