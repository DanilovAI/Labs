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
            label1 = new Label();
            _labelPowerRange = new Label();
            _textBoxMaxWeight = new TextBox();
            _textBoxMinWeight = new TextBox();
            _textBoxMaxPower = new TextBox();
            _textBoxMinPower = new TextBox();
            _checkBoxWeight = new CheckBox();
            _checkBoxPower = new CheckBox();
            _buttonAgree = new Button();
            _labelInsertRange = new Label();
            _groupBoxFilterType.SuspendLayout();
            _groupBoxFilterData.SuspendLayout();
            SuspendLayout();
            // 
            // _groupBoxFilterType
            // 
            _groupBoxFilterType.Controls.Add(_checkBoxFindHelicopter);
            _groupBoxFilterType.Controls.Add(_checkBoxFindHybridCar);
            _groupBoxFilterType.Controls.Add(_checkBoxFindCar);
            _groupBoxFilterType.Location = new Point(12, 12);
            _groupBoxFilterType.Name = "_groupBoxFilterType";
            _groupBoxFilterType.Size = new Size(336, 123);
            _groupBoxFilterType.TabIndex = 0;
            _groupBoxFilterType.TabStop = false;
            _groupBoxFilterType.Text = "Тип транспорта";
            // 
            // _checkBoxFindHelicopter
            // 
            _checkBoxFindHelicopter.AutoSize = true;
            _checkBoxFindHelicopter.Location = new Point(20, 86);
            _checkBoxFindHelicopter.Name = "_checkBoxFindHelicopter";
            _checkBoxFindHelicopter.Size = new Size(94, 24);
            _checkBoxFindHelicopter.TabIndex = 0;
            _checkBoxFindHelicopter.Text = "Вертолет";
            _checkBoxFindHelicopter.UseVisualStyleBackColor = true;
            // 
            // _checkBoxFindHybridCar
            // 
            _checkBoxFindHybridCar.AutoSize = true;
            _checkBoxFindHybridCar.Location = new Point(20, 56);
            _checkBoxFindHybridCar.Name = "_checkBoxFindHybridCar";
            _checkBoxFindHybridCar.Size = new Size(168, 24);
            _checkBoxFindHybridCar.TabIndex = 0;
            _checkBoxFindHybridCar.Text = "Гибридная машина";
            _checkBoxFindHybridCar.UseVisualStyleBackColor = true;
            // 
            // _checkBoxFindCar
            // 
            _checkBoxFindCar.AutoSize = true;
            _checkBoxFindCar.Location = new Point(20, 26);
            _checkBoxFindCar.Name = "_checkBoxFindCar";
            _checkBoxFindCar.Size = new Size(90, 24);
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
            _groupBoxFilterData.Location = new Point(12, 141);
            _groupBoxFilterData.Name = "_groupBoxFilterData";
            _groupBoxFilterData.Size = new Size(336, 115);
            _groupBoxFilterData.TabIndex = 0;
            _groupBoxFilterData.TabStop = false;
            _groupBoxFilterData.Text = "Характеристики транспорта";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(243, 79);
            label1.Name = "label1";
            label1.Size = new Size(15, 20);
            label1.TabIndex = 2;
            label1.Text = "-";
            // 
            // _labelPowerRange
            // 
            _labelPowerRange.AutoSize = true;
            _labelPowerRange.Location = new Point(243, 49);
            _labelPowerRange.Name = "_labelPowerRange";
            _labelPowerRange.Size = new Size(15, 20);
            _labelPowerRange.TabIndex = 2;
            _labelPowerRange.Text = "-";
            // 
            // _textBoxMaxWeight
            // 
            _textBoxMaxWeight.Location = new Point(261, 76);
            _textBoxMaxWeight.Name = "_textBoxMaxWeight";
            _textBoxMaxWeight.Size = new Size(61, 27);
            _textBoxMaxWeight.TabIndex = 1;
            // 
            // _textBoxMinWeight
            // 
            _textBoxMinWeight.Location = new Point(180, 76);
            _textBoxMinWeight.Name = "_textBoxMinWeight";
            _textBoxMinWeight.Size = new Size(61, 27);
            _textBoxMinWeight.TabIndex = 1;
            // 
            // _textBoxMaxPower
            // 
            _textBoxMaxPower.Location = new Point(261, 46);
            _textBoxMaxPower.Name = "_textBoxMaxPower";
            _textBoxMaxPower.Size = new Size(61, 27);
            _textBoxMaxPower.TabIndex = 1;
            // 
            // _textBoxMinPower
            // 
            _textBoxMinPower.Location = new Point(180, 46);
            _textBoxMinPower.Name = "_textBoxMinPower";
            _textBoxMinPower.Size = new Size(61, 27);
            _textBoxMinPower.TabIndex = 1;
            // 
            // _checkBoxWeight
            // 
            _checkBoxWeight.AutoSize = true;
            _checkBoxWeight.Location = new Point(20, 76);
            _checkBoxWeight.Name = "_checkBoxWeight";
            _checkBoxWeight.Size = new Size(94, 24);
            _checkBoxWeight.TabIndex = 0;
            _checkBoxWeight.Text = "Масса (т)";
            _checkBoxWeight.UseVisualStyleBackColor = true;
            // 
            // _checkBoxPower
            // 
            _checkBoxPower.AutoSize = true;
            _checkBoxPower.Location = new Point(20, 46);
            _checkBoxPower.Name = "_checkBoxPower";
            _checkBoxPower.Size = new Size(139, 24);
            _checkBoxPower.TabIndex = 0;
            _checkBoxPower.Text = "Мощность (л.с.)";
            _checkBoxPower.UseVisualStyleBackColor = true;
            // 
            // _buttonAgree
            // 
            _buttonAgree.Location = new Point(254, 262);
            _buttonAgree.Name = "_buttonAgree";
            _buttonAgree.Size = new Size(94, 29);
            _buttonAgree.TabIndex = 1;
            _buttonAgree.Text = "ОК";
            _buttonAgree.UseVisualStyleBackColor = true;
            _buttonAgree.Click += ButtonAgreeClick;
            // 
            // _labelInsertRange
            // 
            _labelInsertRange.AutoSize = true;
            _labelInsertRange.Location = new Point(20, 23);
            _labelInsertRange.Name = "_labelInsertRange";
            _labelInsertRange.Size = new Size(136, 20);
            _labelInsertRange.TabIndex = 3;
            _labelInsertRange.Text = "Введите диапазон";
            // 
            // FilterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 296);
            Controls.Add(_buttonAgree);
            Controls.Add(_groupBoxFilterData);
            Controls.Add(_groupBoxFilterType);
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