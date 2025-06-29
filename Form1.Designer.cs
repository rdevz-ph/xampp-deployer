namespace XamppDeployer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnDeploy;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            btnDeploy = new Button();
            progressBar1 = new ProgressBar();
            lblProgress = new Label();
            lblTitle = new Label();
            lblDeveloper = new Label();

            LinkLabel linkGitHub = new LinkLabel();

            SuspendLayout();

            // 
            // btnDeploy
            // 
            btnDeploy.Font = new Font("Segoe UI", 10F);
            btnDeploy.Location = new Point(90, 70);
            btnDeploy.Name = "btnDeploy";
            btnDeploy.Size = new Size(150, 40);
            btnDeploy.TabIndex = 0;
            btnDeploy.Text = "Deploy Website";
            btnDeploy.UseVisualStyleBackColor = true;
            btnDeploy.Click += btnDeploy_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(30, 130);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(270, 23);
            progressBar1.TabIndex = 1;
            // 
            // lblProgress
            // 
            lblProgress.Font = new Font("Segoe UI", 9F);
            lblProgress.Location = new Point(30, 160);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(270, 23);
            lblProgress.TabIndex = 2;
            lblProgress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "XAMPP Web Project Deployer";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDeveloper
            // 
            lblDeveloper.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblDeveloper.Location = new Point(12, 191);
            lblDeveloper.Name = "lblDeveloper";
            lblDeveloper.Size = new Size(310, 30);
            lblDeveloper.TabIndex = 3;
            lblDeveloper.Text = "Romel Brosas - Freelance Full-Stack Developer" + Environment.NewLine +
                     "https://github.com/rdevz-ph";
            lblDeveloper.TextAlign = ContentAlignment.MiddleCenter;


            // 
            // lblDeveloper (name + title)
            lblDeveloper.Text = "Romel Brosas - Freelance Full-Stack Developer";
            lblDeveloper.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            lblDeveloper.Location = new Point(10, 190);
            lblDeveloper.Size = new Size(310, 20);
            lblDeveloper.TextAlign = ContentAlignment.MiddleCenter;

            // GitHub link
            linkGitHub.Text = "https://github.com/rdevz-ph";
            linkGitHub.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            linkGitHub.Location = new Point(10, 210);
            linkGitHub.Size = new Size(310, 20);
            linkGitHub.TextAlign = ContentAlignment.MiddleCenter;
            linkGitHub.LinkClicked += new LinkLabelLinkClickedEventHandler(linkGitHub_LinkClicked);

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 230);
            Controls.Add(lblTitle);
            Controls.Add(btnDeploy);
            Controls.Add(progressBar1);
            Controls.Add(lblProgress);
            Controls.Add(lblDeveloper);
            Controls.Add(linkGitHub);

            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "XAMPP Deployer";
            ResumeLayout(false);
        }
        private Label lblTitle;
        private Label lblDeveloper;

        private void linkGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/rdevz-ph",
                UseShellExecute = true
            });
        }

    }
}
