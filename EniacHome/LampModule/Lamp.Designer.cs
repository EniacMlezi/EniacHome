namespace LampModule
{
    partial class Lamp
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
            this.chkLamp = new System.Windows.Forms.CheckBox();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkLamp
            // 
            this.chkLamp.AutoSize = true;
            this.chkLamp.Location = new System.Drawing.Point(21, 12);
            this.chkLamp.Name = "chkLamp";
            this.chkLamp.Size = new System.Drawing.Size(76, 21);
            this.chkLamp.TabIndex = 0;
            this.chkLamp.Text = "Lampje";
            this.chkLamp.UseVisualStyleBackColor = true;
            this.chkLamp.CheckedChanged += new System.EventHandler(this.chkLamp_CheckedChanged);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(21, 50);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
            this.lblError.TabIndex = 1;
            this.lblError.Click += new System.EventHandler(this.lblError_Click);
            // 
            // Lamp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.chkLamp);
            this.Name = "Lamp";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkLamp;
        private System.Windows.Forms.Label lblError;
    }
}

