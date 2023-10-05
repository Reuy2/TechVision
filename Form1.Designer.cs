
namespace _6_Lab_4_Sem
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.imgBut = new System.Windows.Forms.Button();
            this.videoBut = new System.Windows.Forms.Button();
            this.webCamBut = new System.Windows.Forms.Button();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cameraParamsBut = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cameraPixelsNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cameraRightNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cameraForwardNum = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.deleteMarkerBut = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.markerOrientationNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.markerCodeNum = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.markerYNum = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.markerXNum = new System.Windows.Forms.NumericUpDown();
            this.addMarkerNum = new System.Windows.Forms.Button();
            this.fieldBox = new System.Windows.Forms.PictureBox();
            this.saveTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPixelsNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraRightNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraForwardNum)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.markerOrientationNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.markerCodeNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.markerYNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.markerXNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBut
            // 
            this.imgBut.Location = new System.Drawing.Point(171, 12);
            this.imgBut.Name = "imgBut";
            this.imgBut.Size = new System.Drawing.Size(121, 23);
            this.imgBut.TabIndex = 5;
            this.imgBut.Text = "Изображение";
            this.imgBut.UseVisualStyleBackColor = true;
            this.imgBut.Click += new System.EventHandler(this.imgBut_Click);
            // 
            // videoBut
            // 
            this.videoBut.Location = new System.Drawing.Point(90, 12);
            this.videoBut.Name = "videoBut";
            this.videoBut.Size = new System.Drawing.Size(75, 23);
            this.videoBut.TabIndex = 4;
            this.videoBut.Text = "Видео";
            this.videoBut.UseVisualStyleBackColor = true;
            this.videoBut.Click += new System.EventHandler(this.videoBut_Click);
            // 
            // webCamBut
            // 
            this.webCamBut.Location = new System.Drawing.Point(9, 12);
            this.webCamBut.Name = "webCamBut";
            this.webCamBut.Size = new System.Drawing.Size(75, 23);
            this.webCamBut.TabIndex = 3;
            this.webCamBut.Text = "Вебка";
            this.webCamBut.UseVisualStyleBackColor = true;
            this.webCamBut.Click += new System.EventHandler(this.webCamBut_Click);
            // 
            // mainTimer
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Interval = 20;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cameraParamsBut
            // 
            this.cameraParamsBut.Location = new System.Drawing.Point(3, 3);
            this.cameraParamsBut.Name = "cameraParamsBut";
            this.cameraParamsBut.Size = new System.Drawing.Size(156, 47);
            this.cameraParamsBut.TabIndex = 6;
            this.cameraParamsBut.Text = "Загрузить параметры камеры";
            this.cameraParamsBut.UseVisualStyleBackColor = true;
            this.cameraParamsBut.Click += new System.EventHandler(this.cameraParamsBut_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cameraPixelsNum);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cameraRightNum);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cameraForwardNum);
            this.panel1.Controls.Add(this.cameraParamsBut);
            this.panel1.Location = new System.Drawing.Point(9, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 223);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "кол во пикселей";
            // 
            // cameraPixelsNum
            // 
            this.cameraPixelsNum.Location = new System.Drawing.Point(3, 169);
            this.cameraPixelsNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.cameraPixelsNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cameraPixelsNum.Name = "cameraPixelsNum";
            this.cameraPixelsNum.Size = new System.Drawing.Size(120, 22);
            this.cameraPixelsNum.TabIndex = 11;
            this.cameraPixelsNum.Value = new decimal(new int[] {
            59,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Сдвиг вправо";
            // 
            // cameraRightNum
            // 
            this.cameraRightNum.Location = new System.Drawing.Point(3, 123);
            this.cameraRightNum.Name = "cameraRightNum";
            this.cameraRightNum.Size = new System.Drawing.Size(120, 22);
            this.cameraRightNum.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Сдвиг вперед";
            // 
            // cameraForwardNum
            // 
            this.cameraForwardNum.Location = new System.Drawing.Point(3, 77);
            this.cameraForwardNum.Name = "cameraForwardNum";
            this.cameraForwardNum.Size = new System.Drawing.Size(120, 22);
            this.cameraForwardNum.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.deleteMarkerBut);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.markerOrientationNum);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.markerCodeNum);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.markerYNum);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.markerXNum);
            this.panel2.Controls.Add(this.addMarkerNum);
            this.panel2.Location = new System.Drawing.Point(178, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(163, 282);
            this.panel2.TabIndex = 13;
            // 
            // deleteMarkerBut
            // 
            this.deleteMarkerBut.Location = new System.Drawing.Point(3, 247);
            this.deleteMarkerBut.Name = "deleteMarkerBut";
            this.deleteMarkerBut.Size = new System.Drawing.Size(156, 23);
            this.deleteMarkerBut.TabIndex = 15;
            this.deleteMarkerBut.Text = "Удалить маркер";
            this.deleteMarkerBut.UseVisualStyleBackColor = true;
            this.deleteMarkerBut.Click += new System.EventHandler(this.deleteMarkerBut_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ориентация";
            // 
            // markerOrientationNum
            // 
            this.markerOrientationNum.Location = new System.Drawing.Point(3, 218);
            this.markerOrientationNum.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.markerOrientationNum.Name = "markerOrientationNum";
            this.markerOrientationNum.Size = new System.Drawing.Size(120, 22);
            this.markerOrientationNum.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Код";
            // 
            // markerCodeNum
            // 
            this.markerCodeNum.Location = new System.Drawing.Point(3, 169);
            this.markerCodeNum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.markerCodeNum.Name = "markerCodeNum";
            this.markerCodeNum.Size = new System.Drawing.Size(120, 22);
            this.markerCodeNum.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Y, см";
            // 
            // markerYNum
            // 
            this.markerYNum.Location = new System.Drawing.Point(3, 123);
            this.markerYNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.markerYNum.Name = "markerYNum";
            this.markerYNum.Size = new System.Drawing.Size(120, 22);
            this.markerYNum.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "X, см";
            // 
            // markerXNum
            // 
            this.markerXNum.Location = new System.Drawing.Point(3, 77);
            this.markerXNum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.markerXNum.Name = "markerXNum";
            this.markerXNum.Size = new System.Drawing.Size(120, 22);
            this.markerXNum.TabIndex = 7;
            // 
            // addMarkerNum
            // 
            this.addMarkerNum.Location = new System.Drawing.Point(3, 3);
            this.addMarkerNum.Name = "addMarkerNum";
            this.addMarkerNum.Size = new System.Drawing.Size(156, 47);
            this.addMarkerNum.TabIndex = 6;
            this.addMarkerNum.Text = "Загрузить параметры маркера";
            this.addMarkerNum.UseVisualStyleBackColor = true;
            this.addMarkerNum.Click += new System.EventHandler(this.addMarkerNum_Click);
            // 
            // fieldBox
            // 
            this.fieldBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fieldBox.Location = new System.Drawing.Point(347, 41);
            this.fieldBox.Name = "fieldBox";
            this.fieldBox.Size = new System.Drawing.Size(400, 200);
            this.fieldBox.TabIndex = 14;
            this.fieldBox.TabStop = false;
            // 
            // saveTimer
            // 
            this.saveTimer.Enabled = true;
            this.saveTimer.Interval = 1000;
            this.saveTimer.Tick += new System.EventHandler(this.saveTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 450);
            this.Controls.Add(this.fieldBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.imgBut);
            this.Controls.Add(this.videoBut);
            this.Controls.Add(this.webCamBut);
            this.Name = "Form1";
            this.Text = "Инженерный проект Волошин.М.В.";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPixelsNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraRightNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraForwardNum)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.markerOrientationNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markerCodeNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markerYNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markerXNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button imgBut;
        private System.Windows.Forms.Button videoBut;
        private System.Windows.Forms.Button webCamBut;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button cameraParamsBut;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown cameraForwardNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown cameraPixelsNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown cameraRightNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown markerCodeNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown markerYNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown markerXNum;
        private System.Windows.Forms.Button addMarkerNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown markerOrientationNum;
        private System.Windows.Forms.Button deleteMarkerBut;
        private System.Windows.Forms.PictureBox fieldBox;
        private System.Windows.Forms.Timer saveTimer;
    }
}

