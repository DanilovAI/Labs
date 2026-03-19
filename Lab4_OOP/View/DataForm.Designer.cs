namespace View
{
    partial class DataForm
    {
        /// <summary>
        /// Необходимая переменная дизайнера
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Метод для явного освобождения ресурсов
        /// </summary>
        /// <param name="disposing">true если ресурсы необходимо
        /// удалить,иначе false</param>
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
        /// Метод инициализации компонентов
        /// </summary>
        private void InitializeComponent()
        {
            _labelTransportType = new Label();
            _labelFuel = new Label();
            _labelPower = new Label();
            _labelWeight = new Label();
            _labelHybridPower = new Label();
            _groupBoxData = new GroupBox();
            _textBoxWeight = new TextBox();
            _textBoxPower = new TextBox();
            _comboBoxFuel = new ComboBox();
            _groupBoxDataHybridCar = new GroupBox();
            _textBoxHybridPower = new TextBox();
            _comboBoxTransportType = new ComboBox();
            _buttonAgree = new Button();
            _buttonRandom = new Button();
            _groupBoxData.SuspendLayout();
            _groupBoxDataHybridCar.SuspendLayout();
            SuspendLayout();
            // 
            // _labelTransportType
            // 
            _labelTransportType.AutoSize = true;
            _labelTransportType.Location = new Point(44, 18);
            _labelTransportType.Name = "_labelTransportType";
            _labelTransportType.Size = new Size(94, 15);
            _labelTransportType.TabIndex = 0;
            _labelTransportType.Text = "Тип транспорта";
            // 
            // _labelFuel
            // 
            _labelFuel.AutoSize = true;
            _labelFuel.Location = new Point(13, 36);
            _labelFuel.Name = "_labelFuel";
            _labelFuel.Size = new Size(55, 15);
            _labelFuel.TabIndex = 0;
            _labelFuel.Text = "Топливо";
            // 
            // _labelPower
            // 
            _labelPower.AutoSize = true;
            _labelPower.Location = new Point(46, 138);
            _labelPower.Name = "_labelPower";
            _labelPower.Size = new Size(97, 15);
            _labelPower.TabIndex = 0;
            _labelPower.Text = "Мощность (л.с.)";
            // 
            // _labelWeight
            // 
            _labelWeight.AutoSize = true;
            _labelWeight.Location = new Point(46, 182);
            _labelWeight.Name = "_labelWeight";
            _labelWeight.Size = new Size(58, 15);
            _labelWeight.TabIndex = 0;
            _labelWeight.Text = "Масса (т)";
            // 
            // _labelHybridPower
            // 
            _labelHybridPower.AutoSize = true;
            _labelHybridPower.Location = new Point(13, 54);
            _labelHybridPower.Name = "_labelHybridPower";
            _labelHybridPower.Size = new Size(97, 15);
            _labelHybridPower.TabIndex = 0;
            _labelHybridPower.Text = "Мощность (л.с.)";
            // 
            // _groupBoxData
            // 
            _groupBoxData.Controls.Add(_labelFuel);
            _groupBoxData.Controls.Add(_textBoxWeight);
            _groupBoxData.Controls.Add(_textBoxPower);
            _groupBoxData.Controls.Add(_comboBoxFuel);
            _groupBoxData.Location = new Point(32, 61);
            _groupBoxData.Margin = new Padding(3, 2, 3, 2);
            _groupBoxData.Name = "_groupBoxData";
            _groupBoxData.Padding = new Padding(3, 2, 3, 2);
            _groupBoxData.Size = new Size(228, 171);
            _groupBoxData.TabIndex = 1;
            _groupBoxData.TabStop = false;
            _groupBoxData.Text = "Данные о двигателе и массе";
            // 
            // _textBoxWeight
            // 
            _textBoxWeight.Location = new Point(13, 138);
            _textBoxWeight.Margin = new Padding(3, 2, 3, 2);
            _textBoxWeight.Name = "_textBoxWeight";
            _textBoxWeight.Size = new Size(182, 23);
            _textBoxWeight.TabIndex = 3;
            _textBoxWeight.KeyPress += TextBoxKeyPress;
            // 
            // _textBoxPower
            // 
            _textBoxPower.Location = new Point(13, 94);
            _textBoxPower.Margin = new Padding(3, 2, 3, 2);
            _textBoxPower.Name = "_textBoxPower";
            _textBoxPower.Size = new Size(182, 23);
            _textBoxPower.TabIndex = 3;
            _textBoxPower.KeyPress += TextBoxKeyPress;
            // 
            // _comboBoxFuel
            // 
            _comboBoxFuel.DropDownStyle = ComboBoxStyle.DropDownList;
            _comboBoxFuel.FormattingEnabled = true;
            _comboBoxFuel.Location = new Point(13, 53);
            _comboBoxFuel.Margin = new Padding(3, 2, 3, 2);
            _comboBoxFuel.Name = "_comboBoxFuel";
            _comboBoxFuel.Size = new Size(182, 23);
            _comboBoxFuel.TabIndex = 2;
            // 
            // _groupBoxDataHybridCar
            // 
            _groupBoxDataHybridCar.Controls.Add(_textBoxHybridPower);
            _groupBoxDataHybridCar.Controls.Add(_labelHybridPower);
            _groupBoxDataHybridCar.Location = new Point(291, 61);
            _groupBoxDataHybridCar.Margin = new Padding(3, 2, 3, 2);
            _groupBoxDataHybridCar.Name = "_groupBoxDataHybridCar";
            _groupBoxDataHybridCar.Padding = new Padding(3, 2, 3, 2);
            _groupBoxDataHybridCar.Size = new Size(158, 171);
            _groupBoxDataHybridCar.TabIndex = 1;
            _groupBoxDataHybridCar.TabStop = false;
            _groupBoxDataHybridCar.Text = "Данные об электрическом двигателе";
            // 
            // _textBoxHybridPower
            // 
            _textBoxHybridPower.Location = new Point(13, 72);
            _textBoxHybridPower.Margin = new Padding(3, 2, 3, 2);
            _textBoxHybridPower.Name = "_textBoxHybridPower";
            _textBoxHybridPower.Size = new Size(133, 23);
            _textBoxHybridPower.TabIndex = 3;
            _textBoxHybridPower.KeyPress += TextBoxKeyPress;
            // 
            // _comboBoxTransportType
            // 
            _comboBoxTransportType.DropDownStyle = ComboBoxStyle.DropDownList;
            _comboBoxTransportType.FormattingEnabled = true;
            _comboBoxTransportType.Location = new Point(46, 35);
            _comboBoxTransportType.Margin = new Padding(3, 2, 3, 2);
            _comboBoxTransportType.Name = "_comboBoxTransportType";
            _comboBoxTransportType.Size = new Size(182, 23);
            _comboBoxTransportType.TabIndex = 2;
            _comboBoxTransportType.SelectedIndexChanged += AddGroupBoxDataHybridCar;
            // 
            // _buttonAgree
            // 
            _buttonAgree.Location = new Point(178, 238);
            _buttonAgree.Margin = new Padding(3, 2, 3, 2);
            _buttonAgree.Name = "_buttonAgree";
            _buttonAgree.Size = new Size(82, 22);
            _buttonAgree.TabIndex = 3;
            _buttonAgree.Text = "Добавить";
            _buttonAgree.UseVisualStyleBackColor = true;
            _buttonAgree.Click += ButtonAgreeClick;
            // 
            // _buttonRandom
            // 
            _buttonRandom.Location = new Point(32, 238);
            _buttonRandom.Margin = new Padding(3, 2, 3, 2);
            _buttonRandom.Name = "_buttonRandom";
            _buttonRandom.Size = new Size(82, 22);
            _buttonRandom.TabIndex = 3;
            _buttonRandom.Text = "Заполнить";
            _buttonRandom.UseVisualStyleBackColor = true;
            _buttonRandom.Click += ButtonRandomClick;
            // 
            // DataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 268);
            Controls.Add(_buttonRandom);
            Controls.Add(_buttonAgree);
            Controls.Add(_comboBoxTransportType);
            Controls.Add(_labelWeight);
            Controls.Add(_labelPower);
            Controls.Add(_labelTransportType);
            Controls.Add(_groupBoxDataHybridCar);
            Controls.Add(_groupBoxData);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 2, 3, 2);
            Name = "DataForm";
            Text = "Добавить транспорт";
            _groupBoxData.ResumeLayout(false);
            _groupBoxData.PerformLayout();
            _groupBoxDataHybridCar.ResumeLayout(false);
            _groupBoxDataHybridCar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label _labelTransportType;
        private Label _labelFuel;
        private Label _labelPower;
        private Label _labelWeight;
        private Label _labelHybridPower;
        private GroupBox _groupBoxData;
        private ComboBox _comboBoxFuel;
        private GroupBox _groupBoxDataHybridCar;
        private ComboBox _comboBoxTransportType;
        private TextBox _textBoxWeight;
        private TextBox _textBoxPower;
        private TextBox _textBoxHybridPower;
        private Button _buttonAgree;
#if DEBUG
        private Button _buttonRandom;
#endif
    }
}