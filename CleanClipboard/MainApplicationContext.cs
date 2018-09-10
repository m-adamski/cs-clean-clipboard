using CleanClipboard.Properties;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace CleanClipboard
{
    class MainApplicationContext : ApplicationContext
    {

        // Define components
        private NotifyIcon notifyIcon;
        private ContextMenuStrip notifyContextMenu;
        private ToolStripMenuItem notifyMenuDelayItem;
        private ContextMenuStrip delayContextMenu;
        private ToolStripMenuItem delayMenuOffItem;
        private ToolStripMenuItem delayMenuTenSecItem;
        private ToolStripMenuItem delayMenuTwentySecItem;
        private ToolStripMenuItem delayMenuThirtySecItem;
        private ToolStripMenuItem notifyMenuExitItem;

        // Define private Notification Form
        private NotificationForm _form;

        public MainApplicationContext()
        {
            InitializeComponent();
            CheckSettings();

            this._form = new NotificationForm(this.notifyIcon);
        }

        private void InitializeComponent()
        {

            this.notifyIcon = new NotifyIcon();
            this.notifyContextMenu = new ContextMenuStrip();
            this.notifyMenuDelayItem = new ToolStripMenuItem();
            this.delayContextMenu = new ContextMenuStrip();
            this.delayMenuOffItem = new ToolStripMenuItem();
            this.delayMenuTenSecItem = new ToolStripMenuItem();
            this.delayMenuTwentySecItem = new ToolStripMenuItem();
            this.delayMenuThirtySecItem = new ToolStripMenuItem();
            this.notifyMenuExitItem = new ToolStripMenuItem();

            // Configure notifyIcon component
            this.notifyIcon.ContextMenuStrip = this.notifyContextMenu;
            this.notifyIcon.Icon = Resources.appIcon;
            this.notifyIcon.Text = "Clean Clipboard";
            this.notifyIcon.Visible = true;

            // Configure notifyContextMenu component
            this.notifyContextMenu.Items.AddRange(new ToolStripItem[] {
                this.notifyMenuDelayItem,
                this.notifyMenuExitItem
            });
            this.notifyContextMenu.Name = "notifyContextMenu";
            this.notifyContextMenu.Size = new System.Drawing.Size(181, 70);

            // Configure notifyMenuDelayItem component
            this.notifyMenuDelayItem.DropDown = this.delayContextMenu;
            this.notifyMenuDelayItem.Name = "notifyMenuDelayItem";
            this.notifyMenuDelayItem.Size = new System.Drawing.Size(180, 22);
            this.notifyMenuDelayItem.Text = "Delay";

            // Configure delayContextMenu component
            this.delayContextMenu.Items.AddRange(new ToolStripItem[] {
                this.delayMenuOffItem,
                this.delayMenuTenSecItem,
                this.delayMenuTwentySecItem,
                this.delayMenuThirtySecItem
            });
            this.delayContextMenu.Name = "delayContextMenu";
            this.delayContextMenu.OwnerItem = this.notifyMenuDelayItem;
            this.delayContextMenu.Size = new System.Drawing.Size(133, 92);

            // Configure delayMenuOffItem component
            this.delayMenuOffItem.Name = "delayMenuOffItem";
            this.delayMenuOffItem.Size = new System.Drawing.Size(132, 22);
            this.delayMenuOffItem.Text = "Off";
            this.delayMenuOffItem.Click += this.HandleDelayChange;

            // Configure delayMenuTenSecItem component
            this.delayMenuTenSecItem.Name = "delayMenuTenSecItem";
            this.delayMenuTenSecItem.Size = new System.Drawing.Size(132, 22);
            this.delayMenuTenSecItem.Text = "10 seconds";
            this.delayMenuTenSecItem.Click += this.HandleDelayChange;

            // Configure delayMenuTwentySecItem component
            this.delayMenuTwentySecItem.Name = "delayMenuTwentySecItem";
            this.delayMenuTwentySecItem.Size = new System.Drawing.Size(132, 22);
            this.delayMenuTwentySecItem.Text = "20 seconds";
            this.delayMenuTwentySecItem.Click += this.HandleDelayChange;

            // Configure delayMenuThirtySecItem component
            this.delayMenuThirtySecItem.Name = "delayMenuThirtySecItem";
            this.delayMenuThirtySecItem.Size = new System.Drawing.Size(132, 22);
            this.delayMenuThirtySecItem.Text = "30 seconds";
            this.delayMenuThirtySecItem.Click += this.HandleDelayChange;

            // Configure notifyMenuExitItem component
            this.notifyMenuExitItem.Name = "notifyMenuExitItem";
            this.notifyMenuExitItem.Size = new System.Drawing.Size(180, 22);
            this.notifyMenuExitItem.Text = "Close application";
            this.notifyMenuExitItem.Click += this.HandleExit;
        }

        private void CheckSettings()
        {

            ToolStripMenuItem selectedOption = null;

            // Assign correct component
            switch (Settings.Default.delayTime)
            {
                case 0: selectedOption = this.delayMenuOffItem; break;
                case 10: selectedOption = this.delayMenuTenSecItem; break;
                case 20: selectedOption = this.delayMenuTwentySecItem; break;
                case 30: selectedOption = this.delayMenuThirtySecItem; break;
            }

            // Uncheck all items
            this.delayMenuOffItem.Checked = false;
            this.delayMenuOffItem.CheckState = CheckState.Unchecked;
            this.delayMenuTenSecItem.Checked = false;
            this.delayMenuTenSecItem.CheckState = CheckState.Unchecked;
            this.delayMenuTwentySecItem.Checked = false;
            this.delayMenuTwentySecItem.CheckState = CheckState.Unchecked;
            this.delayMenuThirtySecItem.Checked = false;
            this.delayMenuThirtySecItem.CheckState = CheckState.Unchecked;

            if (null != selectedOption)
            {
                selectedOption.Checked = true;
                selectedOption.CheckState = CheckState.Checked;
            }
            else
            {
                this.delayMenuOffItem.Checked = true;
                this.delayMenuOffItem.CheckState = CheckState.Checked;

                // Save default settings
                Settings.Default.delayTime = 0;
                Settings.Default.Save();
            }
        }

        private void HandleExit(object sender, EventArgs eventArgs)
        {
            this.notifyIcon.Visible = false;
            Application.Exit();
        }

        private void HandleDelayChange(object sender, EventArgs eventArgs)
        {
            if (sender.Equals(this.delayMenuTenSecItem))
            {

                // Change settings
                Settings.Default.delayTime = 10;
                Settings.Default.Save();

                this.CheckSettings();
            }
            else if (sender.Equals(this.delayMenuTwentySecItem))
            {

                // Change settings
                Settings.Default.delayTime = 20;
                Settings.Default.Save();

                this.CheckSettings();
            }
            else if (sender.Equals(this.delayMenuThirtySecItem))
            {

                // Change settings
                Settings.Default.delayTime = 30;
                Settings.Default.Save();

                this.CheckSettings();
            }
            else
            {

                // Change settings
                Settings.Default.delayTime = 0;
                Settings.Default.Save();

                this.CheckSettings();
            }
        }

        private class NotificationForm : Form
        {

            private NotifyIcon notifyIcon;

            public NotificationForm(NotifyIcon notifyIcon)
            {
                this.notifyIcon = notifyIcon;

                // Register Clipboard Listener
                NativeMethods.SetParent(Handle, NativeMethods.HWND_MESSAGE);
                NativeMethods.AddClipboardFormatListener(Handle);
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == NativeMethods.WM_CLIPBOARDUPDATE)
                {
                    this.HandleClipboardChange();
                }
                base.WndProc(ref m);
            }

            private void HandleClipboardChange()
            {

                // Check if Clipboard is not already empty
                if (Clipboard.GetText() != "")
                {
                    // Get stored delay time
                    int delayTime = Settings.Default.delayTime;

                    // Check if delayTime is not set to zero = Off
                    if (delayTime != 0)
                    {
                        Thread timeoutThread = new Thread(delegate ()
                        {
                            Thread.Sleep(delayTime * 1000);
                            Clipboard.Clear();

                            // Show notification
                            this.notifyIcon.ShowBalloonTip(1000, "Clean Clipboard", "The clipboard has been cleaned", ToolTipIcon.Info);
                        });
                        timeoutThread.SetApartmentState(ApartmentState.STA);
                        timeoutThread.Start();
                        timeoutThread.Join();
                    }
                }
            }
        }
    }
}

/// <summary>
/// See https://gist.github.com/glombard/7986317
/// </summary>
internal static class NativeMethods
{
    public const int WM_CLIPBOARDUPDATE = 0x031D;
    public static IntPtr HWND_MESSAGE = new IntPtr(-3);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool AddClipboardFormatListener(IntPtr hwnd);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
}
