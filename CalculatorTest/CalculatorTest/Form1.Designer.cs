namespace CalculatorTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNumber = new TextBox();
            btnCancel = new Button();
            btnSeven = new Button();
            btnFour = new Button();
            btnOne = new Button();
            btnZero = new Button();
            btnEight = new Button();
            btnNine = new Button();
            btnPlus = new Button();
            btnMinus = new Button();
            btnSix = new Button();
            btnFive = new Button();
            btnMul = new Button();
            btnThree = new Button();
            btnTwo = new Button();
            btnDiv = new Button();
            btnEqual = new Button();
            btnDot = new Button();
            SuspendLayout();
            // 
            // txtNumber
            // 
            txtNumber.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtNumber.Location = new Point(12, 12);
            txtNumber.Multiline = true;
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(198, 42);
            txtNumber.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(12, 60);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(45, 45);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "C";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSeven
            // 
            btnSeven.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSeven.Location = new Point(12, 111);
            btnSeven.Name = "btnSeven";
            btnSeven.Size = new Size(45, 45);
            btnSeven.TabIndex = 2;
            btnSeven.Text = "7";
            btnSeven.UseVisualStyleBackColor = true;
            btnSeven.Click += btnNumber_Click;
            // 
            // btnFour
            // 
            btnFour.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFour.Location = new Point(12, 162);
            btnFour.Name = "btnFour";
            btnFour.Size = new Size(45, 45);
            btnFour.TabIndex = 3;
            btnFour.Text = "4";
            btnFour.UseVisualStyleBackColor = true;
            btnFour.Click += btnNumber_Click;
            // 
            // btnOne
            // 
            btnOne.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOne.Location = new Point(12, 213);
            btnOne.Name = "btnOne";
            btnOne.Size = new Size(45, 45);
            btnOne.TabIndex = 4;
            btnOne.Text = "1";
            btnOne.UseVisualStyleBackColor = true;
            btnOne.Click += btnNumber_Click;
            // 
            // btnZero
            // 
            btnZero.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnZero.Location = new Point(12, 264);
            btnZero.Name = "btnZero";
            btnZero.Size = new Size(45, 45);
            btnZero.TabIndex = 5;
            btnZero.Text = "0";
            btnZero.UseVisualStyleBackColor = true;
            btnZero.Click += btnNumber_Click;
            // 
            // btnEight
            // 
            btnEight.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEight.Location = new Point(63, 111);
            btnEight.Name = "btnEight";
            btnEight.Size = new Size(45, 45);
            btnEight.TabIndex = 6;
            btnEight.Text = "8";
            btnEight.UseVisualStyleBackColor = true;
            btnEight.Click += btnNumber_Click;
            // 
            // btnNine
            // 
            btnNine.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNine.Location = new Point(114, 111);
            btnNine.Name = "btnNine";
            btnNine.Size = new Size(45, 45);
            btnNine.TabIndex = 7;
            btnNine.Text = "9";
            btnNine.UseVisualStyleBackColor = true;
            btnNine.Click += btnNumber_Click;
            // 
            // btnPlus
            // 
            btnPlus.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPlus.Location = new Point(165, 111);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(45, 45);
            btnPlus.TabIndex = 8;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = true;
            btnPlus.Click += btnOperator_Click;
            // 
            // btnMinus
            // 
            btnMinus.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinus.Location = new Point(165, 162);
            btnMinus.Name = "btnMinus";
            btnMinus.Size = new Size(45, 45);
            btnMinus.TabIndex = 11;
            btnMinus.Text = "-";
            btnMinus.UseVisualStyleBackColor = true;
            btnMinus.Click += btnOperator_Click;
            // 
            // btnSix
            // 
            btnSix.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSix.Location = new Point(114, 162);
            btnSix.Name = "btnSix";
            btnSix.Size = new Size(45, 45);
            btnSix.TabIndex = 10;
            btnSix.Text = "6";
            btnSix.UseVisualStyleBackColor = true;
            btnSix.Click += btnNumber_Click;
            // 
            // btnFive
            // 
            btnFive.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFive.Location = new Point(63, 162);
            btnFive.Name = "btnFive";
            btnFive.Size = new Size(45, 45);
            btnFive.TabIndex = 9;
            btnFive.Text = "5";
            btnFive.UseVisualStyleBackColor = true;
            btnFive.Click += btnNumber_Click;
            // 
            // btnMul
            // 
            btnMul.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMul.Location = new Point(165, 213);
            btnMul.Name = "btnMul";
            btnMul.Size = new Size(45, 45);
            btnMul.TabIndex = 14;
            btnMul.Text = "*";
            btnMul.UseVisualStyleBackColor = true;
            btnMul.Click += btnOperator_Click;
            // 
            // btnThree
            // 
            btnThree.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThree.Location = new Point(114, 213);
            btnThree.Name = "btnThree";
            btnThree.Size = new Size(45, 45);
            btnThree.TabIndex = 13;
            btnThree.Text = "3";
            btnThree.UseVisualStyleBackColor = true;
            btnThree.Click += btnNumber_Click;
            // 
            // btnTwo
            // 
            btnTwo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTwo.Location = new Point(63, 213);
            btnTwo.Name = "btnTwo";
            btnTwo.Size = new Size(45, 45);
            btnTwo.TabIndex = 12;
            btnTwo.Text = "2";
            btnTwo.UseVisualStyleBackColor = true;
            btnTwo.Click += btnNumber_Click;
            // 
            // btnDiv
            // 
            btnDiv.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDiv.Location = new Point(165, 264);
            btnDiv.Name = "btnDiv";
            btnDiv.Size = new Size(45, 45);
            btnDiv.TabIndex = 17;
            btnDiv.Text = ":";
            btnDiv.UseVisualStyleBackColor = true;
            btnDiv.Click += btnOperator_Click;
            // 
            // btnEqual
            // 
            btnEqual.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEqual.Location = new Point(114, 264);
            btnEqual.Name = "btnEqual";
            btnEqual.Size = new Size(45, 45);
            btnEqual.TabIndex = 16;
            btnEqual.Text = "=";
            btnEqual.UseVisualStyleBackColor = true;
            btnEqual.Click += btnEqual_Click;
            // 
            // btnDot
            // 
            btnDot.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDot.Location = new Point(63, 264);
            btnDot.Name = "btnDot";
            btnDot.Size = new Size(45, 45);
            btnDot.TabIndex = 15;
            btnDot.Text = ".";
            btnDot.UseVisualStyleBackColor = true;
            btnDot.Click += btnNumber_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(222, 321);
            Controls.Add(btnDiv);
            Controls.Add(btnEqual);
            Controls.Add(btnDot);
            Controls.Add(btnMul);
            Controls.Add(btnThree);
            Controls.Add(btnTwo);
            Controls.Add(btnMinus);
            Controls.Add(btnSix);
            Controls.Add(btnFive);
            Controls.Add(btnPlus);
            Controls.Add(btnNine);
            Controls.Add(btnEight);
            Controls.Add(btnZero);
            Controls.Add(btnOne);
            Controls.Add(btnFour);
            Controls.Add(btnSeven);
            Controls.Add(btnCancel);
            Controls.Add(txtNumber);
            Name = "Form1";
            Text = "Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNumber;
        private Button btnCancel;
        private Button btnSeven;
        private Button btnFour;
        private Button btnOne;
        private Button btnZero;
        private Button btnEight;
        private Button btnNine;
        private Button btnPlus;
        private Button btnMinus;
        private Button btnSix;
        private Button btnFive;
        private Button btnMul;
        private Button btnThree;
        private Button btnTwo;
        private Button btnDiv;
        private Button btnEqual;
        private Button btnDot;
    }
}
