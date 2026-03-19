namespace View
{
    /// <summary>
    /// Класс FilterForm
    /// </summary>
    partial class FilterForm
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
            _groupBoxFilterType = new GroupBox();
            _checkBoxFindHelicopter = new CheckBox();
            _checkBoxFindHybridCar = new CheckBox();
            _checkBoxFindCar = new CheckBox();
            _groupBoxFilterData = new GroupBox();
            _labelInsertRange = new Label();
            label1 = new Label();
            _labelPowerRange = new Label();
            _textBoxMaxWeight = new TextBox();
            _textBoxMinWeight = new TextBox();
            _textBoxMaxPower = new TextBox();
            _textBoxMinPower = new TextBox();
            _checkBoxWeight = new CheckBox();
            _checkBoxPower = new CheckBox();
            _buttonAgree = new Button();
            _groupBoxFilterType.SuspendLayout();
            _groupBoxFilterData.SuspendLayout();
            SuspendLayout();
            // 
            // _groupBoxFilterType
            // 
            _groupBoxFilterType.Controls.Add(_checkBoxFindHelicopter);
            _groupBoxFilterType.Controls.Add(_checkBoxFindHybridCar);
            _groupBoxFilterType.Controls.Add(_checkBoxFindCar);
            _groupBoxFilterType.Location = new Point(10, 9);
            _groupBoxFilterType.Margin = new Padding(3, 2, 3, 2);
            _groupBoxFilterType.Name = "_groupBoxFilterType";
            _groupBoxFilterType.Padding = new Padding(3, 2, 3, 2);
            _groupBoxFilterType.Size = new Size(294, 92);
            _groupBoxFilterType.TabIndex = 0;
            _groupBoxFilterType.TabStop = false;
            _groupBoxFilterType.Text = "Тип транспорта";
            // 
            // _checkBoxFindHelicopter
            // 
            _checkBoxFindHelicopter.AutoSize = true;
            _checkBoxFindHelicopter.Location = new Point(18, 64);
            _checkBoxFindHelicopter.Margin = new Padding(3, 2, 3, 2);
            _checkBoxFindHelicopter.Name = "_checkBoxFindHelicopter";
            _checkBoxFindHelicopter.Size = new Size(76, 19);
            _checkBoxFindHelicopter.TabIndex = 0;
            _checkBoxFindHelicopter.Text = "Вертолет";
            _checkBoxFindHelicopter.UseVisualStyleBackColor = true;
            // 
            // _checkBoxFindHybridCar
            // 
            _checkBoxFindHybridCar.AutoSize = true;
            _checkBoxFindHybridCar.Location = new Point(18, 42);
            _checkBoxFindHybridCar.Margin = new Padding(3, 2, 3, 2);
            _checkBoxFindHybridCar.Name = "_checkBoxFindHybridCar";
            _checkBoxFindHybridCar.Size = new Size(134, 19);
            _checkBoxFindHybridCar.TabIndex = 0;
            _checkBoxFindHybridCar.Text = "Гибридная машина";
            _checkBoxFindHybridCar.UseVisualStyleBackColor = true;
            // 
            // _checkBoxFindCar
            // 
            _checkBoxFindCar.AutoSize = true;
            _checkBoxFindCar.Location = new Point(18, 20);
            _checkBoxFindCar.Margin = new Padding(3, 2, 3, 2);
            _checkBoxFindCar.Name = "_checkBoxFindCar";
            _checkBoxFindCar.Size = new Size(74, 19);
            _checkBoxFindCar.TabIndex = 0;
            _checkBoxFindCar.Text = "Машина";
            _checkBoxFindCar.UseVisualStyleBackColor = true;
            // 
            // _groupBoxFilterData
            // 
            _groupBoxFilterData.Controls.Add(_labelInsertRange);
            _groupBoxFilterData.Controls.Add(label1);
            _groupBoxFilterData.Controls.Add(_labelPowerRange);
            _groupBoxFilterData.Controls.Add(_textBoxMaxWeight);
            _groupBoxFilterData.Controls.Add(_textBoxMinWeight);
            _groupBoxFilterData.Controls.Add(_textBoxMaxPower);
            _groupBoxFilterData.Controls.Add(_textBoxMinPower);
            _groupBoxFilterData.Controls.Add(_checkBoxWeight);
            _groupBoxFilterData.Controls.Add(_checkBoxPower);
            _groupBoxFilterData.Location = new Point(10, 106);
            _groupBoxFilterData.Margin = new Padding(3, 2, 3, 2);
            _groupBoxFilterData.Name = "_groupBoxFilterData";
            _groupBoxFilterData.Padding = new Padding(3, 2, 3, 2);
            _groupBoxFilterData.Size = new Size(294, 86);
            _groupBoxFilterData.TabIndex = 0;
            _groupBoxFilterData.TabStop = false;
            _groupBoxFilterData.Text = "Характеристики транспорта";
            // 
            // _labelInsertRange
            // 
            _labelInsertRange.AutoSize = true;
            _labelInsertRange.Location = new Point(18, 17);
            _labelInsertRange.Name = "_labelInsertRange";
            _labelInsertRange.Size = new Size(104, 15);
            _labelInsertRange.TabIndex = 3;
            _labelInsertRange.Text = "Введите диапазон";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(213, 59);
            label1.Name = "label1";
            label1.Size = new Size(12, 15);
            label1.TabIndex = 2;
            label1.Text = "-";
            // 
            // _labelPowerRange
            // 
            _labelPowerRange.AutoSize = true;
            _labelPowerRange.Location = new Point(213, 37);
            _labelPowerRange.Name = "_labelPowerRange";
            _labelPowerRange.Size = new Size(12, 15);
            _labelPowerRange.TabIndex = 2;
            _labelPowerRange.Text = "-";
            // 
            // _textBoxMaxWeight
            // 
            _textBoxMaxWeight.Location = new Point(228, 57);
            _textBoxMaxWeight.Margin = new Padding(3, 2, 3, 2);
            _textBoxMaxWeight.Name = "_textBoxMaxWeight";
            _textBoxMaxWeight.Size = new Size(54, 23);
            _textBoxMaxWeight.TabIndex = 1;
            // 
            // _textBoxMinWeight
            // 
            _textBoxMinWeight.Location = new Point(158, 57);
            _textBoxMinWeight.Margin = new Padding(3, 2, 3, 2);
            _textBoxMinWeight.Name = "_textBoxMinWeight";
            _textBoxMinWeight.Size = new Size(54, 23);
            _textBoxMinWeight.TabIndex = 1;
            // 
            // _textBoxMaxPower
            // 
            _textBoxMaxPower.Location = new Point(228, 34);
            _textBoxMaxPower.Margin = new Padding(3, 2, 3, 2);
            _textBoxMaxPower.Name = "_textBoxMaxPower";
            _textBoxMaxPower.Size = new Size(54, 23);
            _textBoxMaxPower.TabIndex = 1;
            // 
            // _textBoxMinPower
            // 
            _textBoxMinPower.Location = new Point(158, 34);
            _textBoxMinPower.Margin = new Padding(3, 2, 3, 2);
            _textBoxMinPower.Name = "_textBoxMinPower";
            _textBoxMinPower.Size = new Size(54, 23);
            _textBoxMinPower.TabIndex = 1;
            // 
            // _checkBoxWeight
            // 
            _checkBoxWeight.AutoSize = true;
            _checkBoxWeight.Location = new Point(18, 57);
            _checkBoxWeight.Margin = new Padding(3, 2, 3, 2);
            _checkBoxWeight.Name = "_checkBoxWeight";
            _checkBoxWeight.Size = new Size(77, 19);
            _checkBoxWeight.TabIndex = 0;
            _checkBoxWeight.Text = "Масса (т)";
            _checkBoxWeight.UseVisualStyleBackColor = true;
            // 
            // _checkBoxPower
            // 
            _checkBoxPower.AutoSize = true;
            _checkBoxPower.Location = new Point(18, 34);
            _checkBoxPower.Margin = new Padding(3, 2, 3, 2);
            _checkBoxPower.Name = "_checkBoxPower";
            _checkBoxPower.Size = new Size(116, 19);
            _checkBoxPower.TabIndex = 0;
            _checkBoxPower.Text = "Мощность (л.с.)";
            _checkBoxPower.UseVisualStyleBackColor = true;
            // 
            // _buttonAgree
            // 
            _buttonAgree.Location = new Point(222, 196);
            _buttonAgree.Margin = new Padding(3, 2, 3, 2);
            _buttonAgree.Name = "_buttonAgree";
            _buttonAgree.Size = new Size(82, 22);
            _buttonAgree.TabIndex = 1;
            _buttonAgree.Text = "ОК";
            _buttonAgree.UseVisualStyleBackColor = true;
            _buttonAgree.Click += ButtonAgreeClick;
            // 
            // FilterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(315, 222);
            Controls.Add(_buttonAgree);
            Controls.Add(_groupBoxFilterData);
            Controls.Add(_groupBoxFilterType);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "FilterForm";
            Text = "Найти";
            _groupBoxFilterType.ResumeLayout(false);
            _groupBoxFilterType.PerformLayout();
            _groupBoxFilterData.ResumeLayout(false);
            _groupBoxFilterData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox _groupBoxFilterType;
        private CheckBox _checkBoxFindHelicopter;
        private CheckBox _checkBoxFindHybridCar;
        private CheckBox _checkBoxFindCar;
        private GroupBox _groupBoxFilterData;
        private CheckBox _checkBoxWeight;
        private CheckBox _checkBoxPower;
        private TextBox _textBoxMinWeight;
        private TextBox _textBoxMinPower;
        private Button _buttonAgree;
        private Label _labelPowerRange;
        private Label label1;
        private TextBox _textBoxMaxWeight;
        private TextBox _textBoxMaxPower;
        private Label _labelInsertRange;
    }
}