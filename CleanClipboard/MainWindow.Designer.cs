namespace CleanClipboard
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyMenuDelayItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delayMenuOffItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delayMenuTenSecItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delayMenuTwentySecItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delayMenuThirtySecItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyMenuExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyContextMenu.SuspendLayout();
            this.delayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Clean Clipboard";
            this.notifyIcon.Visible = true;
            // 
            // notifyContextMenu
            // 
            this.notifyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifyMenuDelayItem,
            this.notifyMenuExitItem});
            this.notifyContextMenu.Name = "notifyContextMenu";
            this.notifyContextMenu.Size = new System.Drawing.Size(181, 70);
            // 
            // notifyMenuDelayItem
            // 
            this.notifyMenuDelayItem.DropDown = this.delayContextMenu;
            this.notifyMenuDelayItem.Name = "notifyMenuDelayItem";
            this.notifyMenuDelayItem.Size = new System.Drawing.Size(180, 22);
            this.notifyMenuDelayItem.Text = "Delay";
            // 
            // delayContextMenu
            // 
            this.delayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delayMenuOffItem,
            this.delayMenuTenSecItem,
            this.delayMenuTwentySecItem,
            this.delayMenuThirtySecItem});
            this.delayContextMenu.Name = "delayContextMenu";
            this.delayContextMenu.OwnerItem = this.notifyMenuDelayItem;
            this.delayContextMenu.Size = new System.Drawing.Size(133, 92);
            // 
            // delayMenuOffItem
            // 
            this.delayMenuOffItem.Name = "delayMenuOffItem";
            this.delayMenuOffItem.Size = new System.Drawing.Size(132, 22);
            this.delayMenuOffItem.Text = "Off";
            // 
            // delayMenuTenSecItem
            // 
            this.delayMenuTenSecItem.Name = "delayMenuTenSecItem";
            this.delayMenuTenSecItem.Size = new System.Drawing.Size(132, 22);
            this.delayMenuTenSecItem.Text = "10 seconds";
            // 
            // delayMenuTwentySecItem
            // 
            this.delayMenuTwentySecItem.Name = "delayMenuTwentySecItem";
            this.delayMenuTwentySecItem.Size = new System.Drawing.Size(132, 22);
            this.delayMenuTwentySecItem.Text = "20 seconds";
            // 
            // delayMenuThirtySecItem
            // 
            this.delayMenuThirtySecItem.Name = "delayMenuThirtySecItem";
            this.delayMenuThirtySecItem.Size = new System.Drawing.Size(132, 22);
            this.delayMenuThirtySecItem.Text = "30 seconds";
            // 
            // notifyMenuExitItem
            // 
            this.notifyMenuExitItem.Name = "notifyMenuExitItem";
            this.notifyMenuExitItem.Size = new System.Drawing.Size(180, 22);
            this.notifyMenuExitItem.Text = "Close application";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Clean Clipboard";
            this.notifyContextMenu.ResumeLayout(false);
            this.delayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem notifyMenuDelayItem;
        private System.Windows.Forms.ContextMenuStrip delayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem delayMenuOffItem;
        private System.Windows.Forms.ToolStripMenuItem delayMenuTenSecItem;
        private System.Windows.Forms.ToolStripMenuItem delayMenuTwentySecItem;
        private System.Windows.Forms.ToolStripMenuItem delayMenuThirtySecItem;
        private System.Windows.Forms.ToolStripMenuItem notifyMenuExitItem;
    }
}

