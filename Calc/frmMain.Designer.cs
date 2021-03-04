namespace Calc
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbFirstNumber = new System.Windows.Forms.TextBox();
            this.tbSecondNumber = new System.Windows.Forms.TextBox();
            this.cmbOperations = new System.Windows.Forms.ComboBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbFirstNumber
            // 
            this.tbFirstNumber.Location = new System.Drawing.Point(29, 32);
            this.tbFirstNumber.Name = "tbFirstNumber";
            this.tbFirstNumber.Size = new System.Drawing.Size(72, 20);
            this.tbFirstNumber.TabIndex = 0;
            this.tbFirstNumber.TextChanged += new System.EventHandler(this.setEnabledControl);
            this.tbFirstNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFirstNumber_KeyDown);
            this.tbFirstNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFirstNumber_KeyPress);
            // 
            // tbSecondNumber
            // 
            this.tbSecondNumber.Location = new System.Drawing.Point(198, 33);
            this.tbSecondNumber.Name = "tbSecondNumber";
            this.tbSecondNumber.Size = new System.Drawing.Size(72, 20);
            this.tbSecondNumber.TabIndex = 1;
            this.tbSecondNumber.TextChanged += new System.EventHandler(this.setEnabledControl);
            // 
            // cmbOperations
            // 
            this.cmbOperations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperations.FormattingEnabled = true;
            this.cmbOperations.Location = new System.Drawing.Point(117, 32);
            this.cmbOperations.Name = "cmbOperations";
            this.cmbOperations.Size = new System.Drawing.Size(63, 21);
            this.cmbOperations.TabIndex = 2;
            this.cmbOperations.SelectionChangeCommitted += new System.EventHandler(this.setEnabledControl);
            // 
            // btnCalc
            // 
            this.btnCalc.Enabled = false;
            this.btnCalc.Location = new System.Drawing.Point(198, 76);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 3;
            this.btnCalc.Text = "Посчитать";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 117);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.cmbOperations);
            this.Controls.Add(this.tbSecondNumber);
            this.Controls.Add(this.tbFirstNumber);
            this.Name = "frmMain";
            this.Text = "(◑_◑)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFirstNumber;
        private System.Windows.Forms.TextBox tbSecondNumber;
        private System.Windows.Forms.ComboBox cmbOperations;
        private System.Windows.Forms.Button btnCalc;
    }
}

